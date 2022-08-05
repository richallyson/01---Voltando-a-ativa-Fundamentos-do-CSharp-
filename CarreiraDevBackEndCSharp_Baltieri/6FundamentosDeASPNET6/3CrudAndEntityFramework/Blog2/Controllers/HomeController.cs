using Microsoft.AspNetCore.Mvc;

// A gente vai trabalhar com um modelo diferente nesse controller do que o do módulo passado
// Vamos usar um conceito chamado de Health Check ou Checagem de saúde/Checkpoint de saúde
// Ela é aplicada em um cenário onde a gente tem diversas APIs (que é o cenário normal de uma empresa)
// Então, aqui a gente tem a possibilidade de criar um endpoint padrão, raiz, onde outras APIs conseguem consultar o status
// Para assim saber se essa API está OK
// Ou seja, o Health Check serve para saber se uma API está online ou offiline
// Serviçoes grandes como Facebook, Twitter, Netflix, etc, usam esse mesmo recurso
// Então do lado da nossa API a gente tem que ter um endpoint/url, onde as pessoas possam pingar essa url, fazer um request com essa url
// E a partir disso receber um status, no caso 200 se tiver tudo ok ou erro 500 se essa API estiver fora
// Então o erro 500 a gente não precisa tratar, pois obviamente, se ela não responder 200 é pq ela esta offline
// E para isso, a gente deixa o nosso route do HomeController na raiz, e ao criar uma action/metodo dentro dele, também passar o route como raiz
// Logo depois a gente cria essa action esperando algum resultado como retorno, passando o Ok(). 
// Então, localhost:5001, localhost:2033, qualquer porta que esteja rodando, ele vai sempre retornar um status ok, pois esse método vai fazer a verificação de se a API ta online, pra gente
// Ou seja, dessa forma, se ele não conseguir acessar a raiz, logo a gente sabe que vai ser impossivel realizar qualquer requisição na API
// Porém, se ele acessar a raiz, pingar o endereço e retornar um status 200, vai significar que ta tudo Ok
namespace Blog.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
