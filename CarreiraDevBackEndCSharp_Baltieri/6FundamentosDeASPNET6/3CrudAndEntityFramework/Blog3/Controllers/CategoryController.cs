using Blog.Data;
using Blog.Models;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {

        [HttpGet("v1/categories")] 
        public async Task<IActionResult> GetAsync([FromServices] BlogDataContext context)
        {
            try
            {
                var categories = await context.Categories.ToListAsync();
                return Ok(categories);
            }
            catch (Exception e)
            {
                return StatusCode(500, "05XE01 - Falha interna no servidor!");
            }
        }

        [HttpGet("v1/categories/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] BlogDataContext context, [FromRoute] int id)
        {
            try
            {
                var category = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);

                if(category == null)
                    return NotFound();

                return Ok(category);
            }
            catch (Exception e)
            {
                return StatusCode(500, "05XE02 - Falha interna no servidor!");
            }
        }

        // = ViewModels =
        // Agora a gente vai entrar no mundo das validações! Um fator EXTREMAMENTE importante
        // Tudo o que a gente vai fazer nessa parte é uma abordagem que facilita a vida do usuário, que são os ViewModels
        // Existem várias aplicações pros ViewModels, e eles fazem parte de um outro padrão chamado de MVVM, do qual a gente ainda vai estudar melhor sobre ele mais a frente na parte de apps
        // Na parte de APIs o MVVM não é usado pelo fato da gente não ter View de forma explicita, como um HTML
        // Muita gente nem chega a chamar esse conceito de Views dentro das APIs, inclusve o Balta não considera isso como um ViewModel kk
        // Porém é uma convenção que é muito usada e que a gente traz muito dentro do ASP.NET
        // Os ViewModels são modelos baseados em visualizações. A gente sempre atribui view com visualização html, etc, mas pode ser uma visualização de dados
        // Então ViewModels, são modelos adaptados para as visualizações. Por exemplo, modelos para entrada de dados, como os que a gente recebe do Body no Postman, que é o nosso caso aqui
        // Então, a gente tem o Model sendo algo que vai pro banco e tem as ViewModels que é algo que vem da tela pra gente, no nosso caso, o Postman
        // Bem, a gente na pasta Blog, viu que toda vez que a gente ia criar uma categoria nova, a gente precisava passa junto dela os nossos posts
        // Porém, imagina em um cenário onde a gente vai trabalhar com um modelo bem maior, com 20 propriedades. E nesse cenário a gente teria que passar todas as 20 informações na nossa view
        // Para o usuário isso seria totalmente inviavel, pois na maioria das vezes essas informações não fazem sentido pra ele
        // Como justamente no caso do nossos posts, ou até mesmo o slug. O usuário só precisa interagir com o que faz sentido pra ele
        // E é justamente nesse contexto que entram os ViewModels, que são classes criadas para interagir diretamente com as nossas view
        // Enquanto as classes models ficam restritas apenas para trabalhar com o nosso banco
        // Sendo assim, as ViewModels vão receber apenas as informações necessárias, as informações que fazem sentido para o nosso usuário
        // E depois de receber essas informações, as ViewModels, vão passar elas pros nossos Models através dos nossos Controllers, e depois devolver pra tela somente o que é significativo para o usuário
        // Nem sempre a entrada de dados vai ser igual ao nosso modelo, ao que vai pro banco. E é pra isso que existem as ViewModels
        // E bem, no Blog2, a gente botava a nossa Category diretamente como parametro, porém nessa versão melhorada, a gente passa a nossa ViewModel relacionada a ação 
        // Ou seja, toda ViewModel criada pra um modelo, é reflexo de alguma ação dentro dela. No nosso caso, a gente criou a ViewModel relacionada a Post
        // Dessa forma a gente não vai mais depender do nosso Model para receber coisas da tela, mas sim do nosso ViewModel. O Model fica restrito apenas a mandar as coisas pro banco
        // Eu vou tentar depois fazer com que ele receba apenas o name da categoria, e depois bote o slug automagigamente pegando o name e deixando minusculo. E claro que a gente vai precisar de um Regex pra poder substituir os espaços por traços e tirar os acentos

        [HttpPost("v1/categories")]
        public async Task<IActionResult> PostAsync([FromServices] BlogDataContext context, [FromBody] EditorCategoryViewModel model)
        {
            // Pra entender isso aqui vai no ViewModel Editor, e procura a palavra EXEMPLO, bem grandona assim kk
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var category = new Category
                {
                    Id = 0,
                    Name = model.Name,
                    Slug = model.Slug.ToLower()
                };

                await context.Categories.AddAsync(category); 
                await context.SaveChangesAsync(); 

                return Created($"categories/{category.Id}", model);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "05XE03 - Não foi possivel incluir a categoria");
            }
            catch (Exception e)
            {
                return StatusCode(500, "05XE04 - Falha interna no servidor!");
            }
        }

        // Agora a gente faz a mesma coisa pro Update
        // E como a gente usa as mesmas informações da criação de uma categoria no nosso update, a gente pode usar a mesma classe que foi criada para fazer a criação de categoria
        // E bem, ficaria estranho pra caramba a gente usar no Put uma classe chamada de CreateCategoryViewModel.cs (era o nome antigo)
        // Existe uma convenção usada para casos como esse. Quando a gente tem um mesmo modelo, que usa as mesmas informações, tanto para edição, quanto pra adição...
        // ao invés da gente criar uma classe especifica para cada uma das ações, a gente cria uma classe com o nome Editor ao começo
        // Sendo assim, essa classe, que usa as mesmas informações tanto para criar, quanto para atualizar uma categoria, pode ser usada em diversos cantos, contanto que literalmente use as mesmas informações
        // Se você estiver no Visual Studio, ele vai atualizar tudo pra gente. Nome da classe e onde ela é usada. Se tu usa o VSCode, vai ter que fazer tudo na mão kkkkk
        // E em relação ao código, a única coisa que muda msm é a substituição de Category pro nosso ViewModel Editor de Category. O código permanece o mesmo
        // E da mesma forma a gente não precisa mais passar a lista de posts
        // Agora vai pro EditorCategory que tem coisa lá pra ler

        [HttpPut("v1/categories/{id:int}")]
        public async Task<IActionResult> PutAsync([FromServices] BlogDataContext context, [FromRoute] int id, [FromBody] EditorCategoryViewModel model)
        {
            try
            {
                var category = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);
                if (category == null)
                    return NotFound();

                category.Name = model.Name;
                category.Slug = model.Slug;

                context.Categories.Update(category);
                await context.SaveChangesAsync();

                return Ok(category);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "05XE05 - Não foi possivel atualizar a categoria");
            }
            catch (Exception e)
            {
                return StatusCode(500, "05XE06 - Falha interna no servidor!");
            }

        }

        [HttpDelete("v1/categories/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromServices] BlogDataContext context, [FromRoute] int id)
        {
            try
            {
                var model = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);
                if (model == null)
                    return NotFound();

                context.Categories.Remove(model);
                await context.SaveChangesAsync();

                return Ok("Categoria apagada com sucesso!");
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "05XE07 - Não foi possivel deletar a categoria");
            }
            catch (Exception e)
            {
                return StatusCode(500, "05XE08 - Falha interna no servidor!");
            }
        }
    }
}
