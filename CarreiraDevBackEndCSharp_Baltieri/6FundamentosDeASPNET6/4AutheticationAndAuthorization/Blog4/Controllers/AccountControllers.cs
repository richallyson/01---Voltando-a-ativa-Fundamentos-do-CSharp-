using Blog.Data;
using Blog.Extensions;
using Blog.Models;
using Blog.Services;
using Blog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;

namespace Blog.Controllers;

[ApiController]
public class AccountControllers : ControllerBase
{

    // = Registrando um novo usuário = 
    // Agora iremos registrar um usuário autenticado com uma senha gerada de forma automatica
    // Fizemos algumas modificações no UserMap.cs, tornando algumas propriedades como não-requeridas
    // Também criamos o RegisterViewModel para receber os dados do corpo da requisição, passar pra um User e salvar no banco
    // E depois disso criamos esse metodo Post que vai ser responsável pela criação do usuário

    // = Salvando senhas no banco de dados =
    // Iremos gerar uma senha forte, com caracteres especiais, letras, numeros, etc
    // Se a gente quisesse, poderiamos criar a prop password no RegisterVM, mas no nosso caso, a API msm vai gerar a senha
    // O cenário é: a própria API gera a senha, e manda essa senha pro usuário por email. Se ele quiser mudar dps, blz
    // Mas agr iremos ver apenas como salvamos senhas geradas no banco, sem enviar email ainda
    // E bem, como a senha vai ficar no nosso banco, e isso é uma responsabilidade grande, antes de armazenar essa senha, iremos encriptar ela
    // Isso é o minimo que podemos fazer para dar uma segurança ao nosso usuário
    // Por mais forte que a senha gerada seja, se a gente armazenar ela pura no banco, qualquer pessoa com acesso ao banco, pode dar uma query e ter acesso a senha de todos os usuários
    // E isso causaria um estrago enorme, tanto para a aplicação, quanto para o user, até pq tem gente que usa uma senha pra tudo
    // E bem, por mais seguro que pareça, ter uma senha forte e encriptada, não resolve o nosso problema
    // Computadores com alto poder de processamento, conseguiriam desencriptar essas senha em milesimos, independente do algoritmo de encriptação que a gente use
    // Ou seja, mesmo com a senha no banco, encriptada, é fácil na maioria dos casos desencriptar elas
    // Pra melhorar esse cenário, a gente vai usar um pacote do Balta, que é baseado na geração de senha do aspnet
    // Ele gera uma senha, um hash um pouco mais seguro, e a cada geração desse hash, ele é gerado de uma forma diferente
    // Sendo assim, a gente nunca armazena o mesmo hash. Se você tentar armazenar a mesma senha duas vezes no banco, ele vai gerar dois hashs diferentes
    // Basicamente, toda vez as informações são embaralhadas, gera códigos diferentes pra cada vez. Ou seja, a senha sempre será randomica
    // Desse jeito, se alguém tiver acesso a nossa tabela de senhas, essa pessoa nunca vai conseguir prever o conjunto de caracteres pois eles estão sempre mudando
    // Isso significa que as nossas senhas estão 100% seguras? Não kk Já hackiaram a Nasa, então pq n hackeariam a gente
    // Isso basicamente é um dos passos para ter mais segurança, caso alguém consiga invadir o banco. Ou seja, proteja seu banco
    // E bem, vamo adicionar o pacote usando o comando: dotnet add package SecureIdentity --version 1.0.2
    // E bem, depois de instalado a gente vai agora gerar a senha, pra depois hashear ela
    // A gente vai gerar a senha através do PasswordGenerator.Generate(), onde dentro dela a gente especifica o seu tamanho, e especificidades
    // No nosso caso, iremos definir apenas o length dela, e o resto deixar como padrão
    // Esse PasswordGenerator.Generate() é do pacote que acabamos de instalar
    // Depois de guardar essa senha gerada na variavel password, iremos hashear essa senha
    // Pra isso a gente vai chamar a propriedade passwordHash do user para aplicar a função
    // Dentro dessa propriedade iremos passar a função PasswordHasher.Hash(password)
    // E dessa forma, quando o nosso usuário for criado, teremos a nossa senha gerada já hasheada, ou seja, encriptada e pronta pra ser salva no banco
    // Depois disso é só o que a gente fez antes, salvar o user no banco e fazer tratamento de erro
    // Com o código pronto a gente vai debugar ele, e criar um novo usuário usando esse endpoint
    // Verifica no banco se teu usuário foi criado, e olha como as senhas ficaram no banco. No formato de hash que a gente queria

    [HttpPost("v1/accounts")]
    public async Task<IActionResult> Post([FromServices] BlogDataContext context, [FromBody] RegisterViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

        var user = new User
        {
            Name = model.Name,
            Email = model.Email,
            Slug = model.Name.Replace(" ", "-").ToLower()
        };

        var password = PasswordGenerator.Generate(25);
        user.PasswordHash = PasswordHasher.Hash(password);

        try
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            // Em tempo de compilação, supõem-se que um elemento que tem o tipo dynamic dá suporte a qualquer operação
            // Dessa forma, usando o dynamic, ao invés da gente criar uma view model nova pra esse tipo de retorno, o dynamic já resolve tudo pra gente
            // Iremos pra retornar o email do usuário criado, e a senha sem ta hasheada
            return Ok(new ResultViewModel<dynamic>(new
            {
                user = user.Email, password
            }));
        }
        catch (DbUpdateException ex)
        {
            // Em caso de criar algum usuário que já existe
            // Ta todx zuado isso, da pra deixar bem mais legal e tratar tudo melhor, mas fica pra outra hora
            return StatusCode(400, new ResultViewModel<string>("Este email já existe"));
        }
        catch
        {
            // Qualquer outro erro genérico vem pra cá
            return StatusCode(500, new ResultViewModel<string>("Falha interna no servidor!"));
        }
    }

    // Depois de ver que tu deu certo. Copia a senha que ele gerou no retorno, pra gente testar o login
    // Cria uma nova aba no postman de post pra gente logar, nela tu passa o email e a senha dentro do JSON
    // Mas pra isso a gente vai criar uma nova ViewModel especifica pra receber esses dados quando a gente for fazer o Login
    // Para isso criamos a LoginViewModel.cs na nossa pasta de ViewModels, onde nela iremos fazer a autenticação do usuário através da senha e do email
    // Depois de criado, a gente vai alterar nossa função de login, adicionando os parametros contex e o viewmodel criado, e tornando ela async
    // Depois a gente faz aquele velho tratamento pra ver se o modelo ta de boas pelo modelState
    // E depois disso vamos fazer a autenticação de fato
    // Primeiro, a gente recupera esse usuário do banco e compara a senha dele
    // Porém, na hora de buscar o usuário, a gente não vai poder incluir a senha
    // Nessa busca a gente usa o AsNoTracking pois a gente já sabe pra o que é
    // Depois a gente tem que dar um include nas roles, pois a gente vai precisar das roles pra gerar os claims que vão no nosso token
    // E por ultimo a gente compara apenas o email, no FirstOrDefaultAsync
    // A gente não pode comparar a senha, pois a senha que vai vir no nosso model é diferente da senha que tem no banco
    // A senha que vem pelo corpo da requisição é pura, enquanto a senha no nosso banco está hasheada, é diferente
    // E pra buscar o usuário a gente vai fazer só isso
    // Logo após a gente valida se esse usuário é válido, vamo pra dentro do escopo do código agora

    [HttpPost("v1/accounts/login")]
    public async Task<IActionResult> Login([FromServices] TokenService tokenService, 
        [FromServices] BlogDataContext context, [FromBody] LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

        var user = await context
            .Users
            .AsNoTracking()
            .Include(x => x.Roles)
            .FirstOrDefaultAsync(x => x.Email == model.Email);

        // Sempre omita a informação, do tipo: usuário não existe
        // Não é uma boa prática entregar esse tipo de coisa, sempre retorne: Usuário ou senha inválida
        // Pois se alguém tiver tentando forçar alguma coisa na nossa API, não tem como ela saber se realmente o usuário existe ou não
        
        if (user == null)
            return StatusCode(401, new ResultViewModel<string>("Usuário ou senha inválida"));
        
        // Se a gente fizer isso: var hash = PasswordHasher.Hash(model.Password);
        // E tentar comparar com o hash que tem no banco, vai retornar nulo, pois como eu disse, toda vez que uso o PasswordHasher.Hash(), ele gera uma hash nova
        // Ou seja, não tem como usar nesse formato, a gente tem que usar uma função chamada Verify para dar certo
        // Esse método Verify vai conseguir extrair a hash, ler o algoritmo que ele ta usando e fazer a comparação pra ver se o texto vindo do model...
        // pode ocasionar em uma chave encriptada do qual ele possui no algoritmo dele
        // Ou seja, pelo o que eu tendi: o Verify recebe dois argumentos, no nosso caso, uma hash e um password
        // Essa hash é a hash que está no banco relacionado ao usuário que pegamos acima, e o password é a senha que iremos mandar no corpo da requisição
        // Ele vai extrarir a hash do user, ler o algoritmo que ele ta usando e comparar com o password do model
        // E vai ver se esse password do model pode ocasionar em uma chave encriptada do qual ele possui no algoritmo dele
        // Ele vai ver se ele pode usar a mesma chave pra encriptar no password do model, se sim, é pq ta safe
        // Mas no nosso caso, a gente vai ver se da errado, pois se der errado, o código para aqui e retorna o que deve retornar
        // Porém, se ele passar daqui e ver que ta tudo certo, significa que realmente os dois passwords são os mesmos, o hash desencriptado e o password do model que poderia ser encriptado usando a mesma chave que usou pra encriptar a senha do user e transformado em hash
        // Basicamente, ele vai entender que o nosso password de model foi gerado baseado numa hash usando o nosso algoritmo

        if(!PasswordHasher.Verify(user.PasswordHash, model.Password))
            return StatusCode(401, new ResultViewModel<string>("Usuário ou senha inválida"));
        
        // Então, se ele passou do código acima, significa que a senha é válida, então é só agora a gente gerar o token
        // Só que dessa vez a gente vai passar o nosso user dentro do Token, e pra isso a gente precisa fazer algumas alterações no nosso TokenService
        // Se a gente gerar um token do jeito que o nosso código do TokenService estava antes, vai ser um token invalido
        // Pois ele não vai trazer as informações do nosso usuário para os seus claims, mas sim as informações hardcoded que botamos nos clains
        // Vai pro TokenService.cs pra gente fazer essa alterações
        
        // Mas antes, preciso dizer que no nosso retorno, a gente deve passar tanto o token, quando o null
        // Pois se a gente passa só o token ele vai entender que é um erro, devido a ele ser uma string

        try
        {
            var token = tokenService.Generate(user);
            return Ok(new ResultViewModel<string>(token, null));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("Falha interna no servidor"));
        }
    }
}