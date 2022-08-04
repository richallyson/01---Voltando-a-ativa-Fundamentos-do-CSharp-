using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        // = Nomeando um endpoint no padrão REST =
        // Agora a gente vai começar a nomear as nossas requisições Http com uma convenção de nomenclatura
        // Essa nomenclatura segue os padrões do que a gente chama de API REST
        // Essas APIs REST, esse padrão REST que a gente tem, ele é um padrão que grandes empresas usam
        // E se você seguir essas convenções nas nossas APIs, vai ajudar bastante todas as outras pessoas que vão consumir essa API
        // Porquê é o mesmo estilo que o Facebook, Google, Microsoft, assim como inumeras empresas fazem
        // Então, seguir a convenção é sempre o melhor padrão, beleza? Tudo o que você padronizar na sua API é bom
        // Então vamos supor que a gente tem um método Get que retorna uma lista de Categorias, dai num outro método Get de produto, você retorna a data igual e a lista de produtos
        // E em outro método Get você retorna a quantidade de produtos mais a lista de produtos, então fica uma bagunça, você nunca sabe o que esperar da API
        // Então, no nosso código, a gente sempre vai padronizar!
        // E a primeira coisa sobre padronização que a gente vai aprender aqui, é sobre como nomear um endpoint dentro desse padrão REST
        // E como a gente faz? Bota sempre o nome do modelo no minusculo e sempre no plural, como visto no HttpGet abaixo
        // Não precisa colocar barra nem antes nem depois, pois o ASP.NET coloca automaticamente pra gente
        // E esse padrão serve para TODOS os endpoints que a gente vai criar
        // Se a gente tiver um caso de nome de modelo composto como UserRole, ele fica desse jeito dentro do padrão: user-roles
        // Caso você tenha o Resharp e deixe "userrole" ele vai deixar o nome verdinho embaixo já dizendo que você tem um erro de escrita ai
        // Resharp é god dms, da ideia de correção até pra endereço de endpoint no padrão REST kkkk
        // E se você tiver mais de uma rota, você pode colocar outra para suportar em diversos idiomas, mas sempre seguido o padrão REST de minusculo e plural
        // Basta colocar essa rota acima ou abaixo das outras rotas e gg: [HttpGet("categorias")] - Exemplo de outra rota pro mesmo destino para outra linguagem usando padrão REST

        // = Versionamento =
        // Imagina um cenário onde a gente atualiza a nossa API, que ta sendo consumida por N aplicações, e por algum descuido, foi retirado um campo ou adicionado um campo
        // As aplicações que ainda não atualizaram pra nova versão, na hora que forem consumir a nossa API, vão quebrar, pois elas esperam aqueles campos para poder continuar com suas requisições
        // Nesse cenário é de extrema importância a gente sempre trabalhar com o versionamento das nossas APIs
        // E como isso funciona? Bem, basta você adicionar a versão ao endpoint antes do nome do modelo, como por exemplo ["v1/categories]
        // Agora vamos supor que nós vamos atualizar a nossa API, e nela tem uma nova função Get, como a gente faria para botar essa nova função sem quebrar as aplicações que ainda não atualizaram a sua versão
        // 

        [HttpGet("categories")] // localhost:port/categories (padrão REST de endpoint)
        public IActionResult Get([FromServices] BlogDataContext context)
        {
            var categories = context.Categories.ToList();
            return Ok(categories);
        }

        [HttpPost("categories")]
        public IActionResult Post([FromServices] BlogDataContext context, [FromBody] Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();

            return Created($"categories/{category.Id}", category);
        }

        [HttpPut("categories/{id}")]
        public IActionResult Put([FromServices] BlogDataContext context, [FromBody] int id, Category category)
        {
            var model = context.Categories.FirstOrDefault(c => c.Id == id);

            return Ok();

        }
    }
}
