using Blog.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

// = Injeção de dependência =
// Injeção de dependência é uma técnica que implementa um padrão chamado de IoC (Inversão de Controle)
// Vamos tratar um cenário onde a gente precisa do TokenService para trabalhar
// Bem, a gente já viu como adiciona um serviço nos módulos anteriores
// Fomos no Program.cs e adicionamos o nosso context como serviço
// Pra chamar ele a gente usa o [FromServices] e passa o objeto como parametro
// Dessa forma a gente diz pra nossa ação que ela necessita daquele serviço para funcionar
// No caso do context, a gente necessita dele pra poder pegar as informações do banco em memória
// E bem, a gente criou um serviço novo, que foi o TokenService, classe do qual precisa sempre ser instanciada.
// Pois como não é uma classe estatica, em caso de precisão, precisamos instanciar ela
// E bem, a gente criou a nossa classe TokenService, justamente para gerar um Token pra gente
// Esse Token vai ser responsável pela autorização e autenticação de um usuário 
// Ou seja, dentro desse nosso contexto onde a gente criou um controlador para login na plataforma...
// Pode se dizer que a gente depende do TokenService para fazer essa autenticação e autorização pra gente
// Ficaria muito anti-produtivo se a gnt toda vez que precisasse do TokenService, instanciasse ele na ação
// Uma forma de se fazer isso, de já ter o TokenService no nosso Controller, é através de um construtor
// Como fizemos em uma das nossas aulas de Dapper que pode ser vista nesse link entre as linhas 30 e 34: https://tinyurl.com/mr2enrvu
// Nesse arquivo do link, a gente precisava de uma conexão com o servidor em memória para fazer as queries
// Sendo assim, criamos uma propriedade privada do tipo da conexão, depois um construtor com um parametro...
// que era também do tipo da conexão do servidor. E por fim passamos para essa propriedade privada o servidor via construtor
// Isso é a mesma coisa que uma injeção de dependência, a gente ta dizendo que praquela classe funcionar, ele vai precisar da conexão com o server
// Porém, existe uma forma melhor de se fazer isso, que é usando o [FromServices], do qual já usamos no CategoryControllers.cs
// A gente faz exatamente a mesma coisa que fizemos nesse exemplo do Dapper, porém, só utilizando o [FromServices]
// E bem, como podemos fazer isso? A gente apenas criou uma classe chamada TokenService, mas não adicionou...
// ela aos nossos serviços como fizemos com o nosso DbContext
// Se a gente rodar a nossa aplicação e entrar nesse endpoint, vai retornar um erro
// Porquê a gente ta dizendo que precisa de um TokenService, mas o nosso programa não faz ideia de como ele resolve essa parte da dependência
// O programa não faz ideia do que seja um TokenService, a gente precisa definir que isso é um serviço
// E depois adicionar esse serviço para ser chamado por toda a aplicação quando a gente desejar
// E para isso a gente vai agora pro nosso Program.cs

[ApiController]
public class AccountControllers : ControllerBase
{
    [HttpPost("v1/login")] // Endpoint onde vamos fazer o login da nossa aplicação
    public IActionResult Login([FromServices] TokenService tokenService)
    {
        var token = tokenService.Generate(null);
        return Ok(token);
    }
}