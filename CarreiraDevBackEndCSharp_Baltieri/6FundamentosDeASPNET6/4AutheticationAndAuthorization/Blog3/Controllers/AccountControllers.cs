using Blog.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[ApiController]
public class AccountControllers : ControllerBase
{
    [HttpPost("v1/login")]
    public IActionResult Login([FromServices] TokenService tokenService)
    {
        var token = tokenService.Generate(null);
        return Ok(token);
    }
    
    // = Testando a autenticação e a autorização =
    // Depois de explicar sobre o Authorize no começo da classe, no Blog2, agora a gente vai mudar isso
    // Como a gente tem diversas roles aqui, a gente vai trabalhar com o Authorize diretamente nos endopoints dessas roles
    // Dessa forma a gente não precisa mais do AllowAnonymous no Login
    // E bem, o Authorize verifica se o usuário ta logado e sempre preenchido
    // Mas como assim preenchido? Perceba que o User.Identity ta com uma listra laranja embaixo
    // Isso é o Aspnet dizendo pra gente que ele pode vir nulo, mas como agora a gente tem o Authorize acima deles, eles sempre virão preenchidos
    // Porquê de fato ele já ta autenticado. Ou seja, esses três métodos estão autorizados
    // Agora, como eu faço pra garantir que apenas a role user use a função GetUser???
    // Basta a gente abrir o parenteses na frente do Authorize, e botar o user como atributo de roles
    // Dessa forma, só usuários com role user, podem acessar o método GetUser, e assim suscetivamente para cada role
    // Esse Roles é um atributo da classe AuthorizeAtributte, que é a classe do Authorize
    // Agora vamos pra TokenService.cs
    // E bem, adicionamos mais uma role para o nosso usuário no TokenService
    // Outra coisa importante de se saber é que é possivel tb colocar mais de um authorize por método
    // Dessa forma, ele precisaria ter as roles necessárias pra poder acessar o método
    // Agora vamos pro Postman. Gera um token novo, e inspecionar ele no jwt.io
    // Agora a gente pode ver que ele tem uma array de roles
    // Voltando pro Postman, a gente vai tentar um get de novo no v1/user e fai ter novamente o erro 401
    // Como eu falei no AccountController do Blog2, a gente precisa do Token para ser autenticado na app
    // E pra isso, basta a gente ir na aba Authorization, selecionar Bearer Token, e colar ele
    // Dessa forma agora a gente pode fazer o get em user, pois agora temos o token de autorização e autenticação
    // E quanto a gente der o Get, ele vai retornar o que se pede, que é o nome do usuário que a gente criou no ClaimsType do TokenService
    // E se a gente fizer um get pro author passando o Token, ele vai dar um erro 403, que significa que eu não tenho a função do author
    // Isso aconteceu, pois a gente definiu apenas duas roles pro nosso usuário, a user e a admin
    // A função author ele não vai ter acesso, pois não possui essa role
    // Uma coisa legal de se ver é o que foi feito quando a gente fez essa requisição pro Author
    // Pra isso, basta você clicar no icone que fica no canto superior direito, do Postman, ele é assim: </>
    // Dentro dele a gente vai ver o tipo de requisição que ele fez, o tipo do token e o token
    // Resumindo. Se você tiver um token que não usa a nossa chave, ele vai dar 401
    // Se você tentar entrar usar alguma função que pede autorização, sem o token, vai dar 401
    // Se você tem o token, e tem a role especifica para aquela função, ele vai dar 200 
    // E se você tem o token, mas não tem o role especifico pra usar aquela função, vai dar 403
    // E bem, esse métodos aqui foram feitos pra testar os roles, e os Claims
    // Agora vá pra pasta blog quatro, pois a gente vai mudar o código de novo
    // Especificamente para esse mesmo arquivo, pois agora vamos criar um usuário autenticado
    
    [Authorize(Roles = "user")] // Método pode ser acessado apenas pela role user
    [HttpGet("v1/user")]
    public IActionResult GetUser() => Ok(User.Identity.Name);
    
    [Authorize(Roles = "author")] // Método pode ser acessado apenas pela role author
    // [Authorize(Roles = "admin")] - Outro authorize para esse método
    [HttpGet("v1/author")]
    public IActionResult GetAuthor() => Ok(User.Identity.Name);
    
    [Authorize(Roles = "admin")] // Método pode ser acessado apenas pela role admin
    [HttpGet("v1/admin")]
    public IActionResult GetAdmin() => Ok(User.Identity.Name);
}