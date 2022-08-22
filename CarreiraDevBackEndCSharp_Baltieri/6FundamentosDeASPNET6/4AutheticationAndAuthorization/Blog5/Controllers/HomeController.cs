using Blog.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        // = ApiKey =
        // Bem, a gente basicamente antes de retornar qualquer coisa, tem que verificar se existe essa chave na requisição
        // Então, se essa chave existir na requisição e for a mesma que ta no Configurations.cs, a gente permite o robô acessar ou não o método
        // Porém, a gente não pode usar o [Authorize] aqui, pois ele não esta autorizado. O que a gente vai fazer é usar um atributo/decorator customizado para verificar isso
        // Vamos criar um atribudo chamado de [ApiKey]
        // E isso vai ser criar em uma classe própria, dentro da pasta Attributes chamada de ApiKeyAttributes.cs
        // Pode ir pra lá agora
        
        // Se tu terminou de ver tudo lá, agora a gente vai testar o nosso novo atributo que autentica e autoriza o nosso robô a realizar ações na nossa API
        // Ele vai verificar sem vem um ApiKey nessa requisição e se esse ApiKey é válido
        // E pra isso basta a gente colocar o atributo onde deseja, dentro dos limites impostas a ela
        // E agora a gente testa. Roda a aplicação, abre o browser e tenta esses três cenários
        // O primeiro você poda localhost:port - Que é o endereço de quando você da run 
        // O segundo localhost:port?api_key=chaveErrada 
        // E o terceiro localhost:port?api_key=chaveCorreta
        // No primeiro cenário a gente tem como retorno a mensagem "ApiKey não encontrada!", que foi definida no primeiro if do atributo
        // Como eu não passei o ApiKeyName nem a ApiKey no endereço, ele não autorizou nem autenticou o robô
        // No segundo cenário a gente tem como retorno a mensagem "Acesso não autorizado!"
        // Que cai justamente no segundo if, onde a gente tem a autenticação pq passou o ApiKeyName, mas não passou a chave correta
        // Sendo assim, estamos autenticado, mas não estamos autorizados a usar essa função
        // E o terceiro cenário é um status 200. Temos a query string correta, do jeito que se espera
        // Dessa forma a robô tem tanto a autenticação, quando a autorização pra usar a função
        // E claro que isso vai inviabilizar tudo o que a gente fez antes disso
        // Então esse exemplo vai ficar aqui, só pra gente conhecer esse tipo de autenticação
        // Mas o grosso de tudo mesmo está no Blog4
        // E vou criar um novo projeto chamado de BlogNoComments, onde tem todx o projeto do blog4 sem comentários
        // Beijos e vamos pro próximo módulo
        
        [ApiKeyAttributes]
        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok(); // Health Check
        }
    }
}
