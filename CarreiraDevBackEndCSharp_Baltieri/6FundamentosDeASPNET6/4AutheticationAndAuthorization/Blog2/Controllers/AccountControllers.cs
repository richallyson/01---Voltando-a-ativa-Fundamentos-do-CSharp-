using Blog.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[Authorize]
[ApiController]
public class AccountControllers : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("v1/login")]
    public IActionResult Login([FromServices] TokenService tokenService)
    {
        var token = tokenService.Generate(null);
        return Ok(token);
    }
    
    // = Testando a autenticação e a autorização = Primeiro leia aqui
    // E bem, pra gente testar a autenticação e autorização depois de configurada no program.cs...
    // Nós iremos criar algumas ações para isso, um para cada role que o user pode ter
    // E bem, mas como a gnt vai usar esses métodos msm? Qual a sua função
    // Bem, a função deles é assegurar o acesso a qualquer controller ou método da nossa aplicação
    // Mas para isso, a gente precisa primeiro de um atribudo chamado de [Authorize]
    // Esse atribudo Authorize pode ser colocado tanto pra um método quanto para o controller todx
    // Para colocar pro controller todx, basta colocar ele acima do atribudo ApiController, que é o nosso caso
    // Porém existe um problema nisso, a partir do momento que a gente bota o atributo Authorize antes da classe...
    // A gente espera que qualquer ação realizada por esse controller só possa ser feita por usuários autorizados
    // E isso inclui tbm a função de login que gera o Token de autorização e autenticação pra gente
    // E como a gente sabe, para conseguir autorização na nossa aplicação a gente precisa de um token
    // Se você tentar fazer um post em login, você vai ter de retorno o status 401, que é o Unauthorized
    // Vamos supor que dentro desse cenário faz mais sentido deixar o Authorize no topo msm, pois a maioria das funções precisam de autorização
    // Porém, nesse cenário, existe uma função que eu não quero que precise de autorização para ser usada, como eu faria?
    // Usando um outro atributo chamado de [AllowAnonymous]
    // E dessa forma a gente consegue usar a função, mesmo que a classe toda precise de autorização pra ser usada
    // Que foi o que a gente fez na função de Login, permitindo que ela possa ser usada sem autorização
    // E bem, abre teu Postman, e gera um token dando post em login
    // Depois disso, tenta dar um get nos três endpoints abaixo. Ele vai retornar novamente o 401
    // Justamente pelo fato dessas funções precisarem de autorização para serem usadas
    // E como a gente ainda n tem uma aplicação completa pra fazer tudo bonitin, a gente usa o Postman pra isso
    // Primeiro pegue o token gerado no Postman, e depois vá na aba Authorization
    // Nessa aba tem um dropdown, você clica nele e escolhe a opção Bearer Token, que é o tipo de token que a gnete ta usando
    // Ao clicar no Bearer Token, vai aparecer um campo para ser preenchido, você cola o Token lá e da Get de novo
    // Isso tudo dentro do Get de algum desses endpoints abaixo
    // Quando você tenta dar o get, dessa vez vai conseguir, pois tem o Token de autorização que permite o uso da aplicação
    // Agora a gente vai continuar o mesmo tema, porém vamos alterar o código um pouco
    // Então como já tem coisa dms nesse projeto, vai pra pasta Blog3, novamente no AccountController

    [HttpGet("v1/user")]
    public IActionResult GetUser() => Ok(User.Identity.Name);
    
    [HttpGet("v1/author")]
    public IActionResult GetAuthor() => Ok(User.Identity.Name);
    
    [HttpGet("v1/admin")]
    public IActionResult GetAdmin() => Ok(User.Identity.Name);

}