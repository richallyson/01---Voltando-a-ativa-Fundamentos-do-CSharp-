using Blog.Data;
using Blog.Extensions;
using Blog.Models;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    // = Continuando a padronização de retorno de resquisição =
    // Bem, a gente pra usar o ResultViewModel, vai precisar fazer uma pequena alteração no nosso Program.cs
    // Quando a gente decora a nossa classe Controller com o [ApiController], automaticamente a gente não precisa mais ficar vendo se o nosso ModelState está valido ou invalido
    // Na pasta Blog3, eu falei sobre o ModelState. Resumindo, o ModelState vai fazer as validações pra gente. Se o modelo não for válido ele vai retornar algo, assim como também se o modelo for válido
    // Porém, no Blog3 mesmo, a gente fez uma verificação do ModelState só para mostrar, mas não tinha necessidade pelo fato de que ele já faz isso automaticamente pra gente quando decoremos o [ApiController}
    // O retorno do if do ModelState, como pode ser visto na nossa ação de post, é um BadRequest(), e caso entre nesse BadRequest, vai retornar aquele objeto pra gente com o type, title, statis e traceId
    // E a gente não quer isso, a gente a partir de agora, quer retornar um erro padronizado, para que o front sempre saiba o que esperar de um retorno de uma requisição
    // Como o decorador [ApiController] já faz essa validação pra gente de forma automática, retornando sempre um objeto, em caso de erro, daquela forma, vai ser necessário a gente suprimir essa validação automatica do ModelState
    // E pra isso, agora tu vai na classe Program.cs e depois volta aqui de novo
    // Dps de ler tudo o que tem explicando lá sobre como desativar a validação automática do ModelState, bora continuar nosso aprendizado
    // Primeiro, vamos padronizar o retorno do nosso Get. Essas padronizaçõs de retorno acontecem no return (obvio kk)
    // A padronização de resultados, pra gente que ta no back-end não faz tanta diferença assim na questão de código. A gente fez alguns ajustes básicos, onde ao invés de retornar sempre o objeto cru, a gente retorna um objeto que trata pra gente o retorno
    // Mas pra quem vai consumir a nossa API, isso muda tudo por quê essa pessoa tem todx o retorno padronizado
    // Então se vier erro, ele tem uma lista de erros, e se vier dados, ele tem os dados
    // Explicando direitin como isso funfa pra pegar melhor na mente da gente kk
    // A gente criou uma classe, e essa classe sempre vai ser o retorno, onde essa classe também retorna pra gente, o que a gente deseja dentro das nossas ações nos controllers
    // Ou seja, a gente sempre vai ta retornando um ResultViewModel que retorna algo, seja os dados ou uma lista de erros
    // Sendo assim, a gente nunca vai ter o retorno padrão das funções do IActionResult, mas sim uma padronização que vai ser aplicada em todas as ações de todos os controllers
    // E sempre, em TODOS os casos, quem consome a API, vai sempre receber o Data e o Error, já sabendo qual retorno esperar
    // E lembra que quando a gente usa esse padrão, a comunicação entre os times de front e o back é muito importante

    [ApiController]
    public class CategoryController : ControllerBase
    {

        [HttpGet("v1/categories")] 
        public async Task<IActionResult> GetAsync([FromServices] BlogDataContext context)
        {
            try
            {
                var categories = await context.Categories.ToListAsync();

                // Ao invés da gente retornar o return Ok(categories), a gente vai retornar o nosso ResultViewModel, passando o tipo de retorno e os dados retornados
                // A gente vai retornar um new ResultViewModel, e a partir desse momento ele vai pedir pra gente um T
                // Vai dizer assim: oh qual que é o tipo do meu retorno? E se a gente ta retornando uma lista de categorias, o tipo vai ser List<Category>
                // Depois disso, a gente precisa passar algo como parametro, pois a gente tem diversos métodos construtores para cada tipo de cenário
                // No nosso caso, vamos passar a lista de categoreis que pegamos do banco, que é o T Data
                // Ou seja, quando definimos o tipo de retorno da nossa classe, já dizemos também o tipo de dados que o nosso Data é
                // Então esse ResultViewModel é do tipo lista de categoria, e a gente ta passando essa lista de categorias como parametro
                // Ele assim já vai preencher as listas de categorias, e os erros vão ser vazios por padrão, nesse nosso cenário onde não existe nenhum erro
                return Ok(new ResultViewModel<List<Category>>(categories));
            }
            catch
            {
                // A mesma coisa, o mesmo trecho de código de retorno do try, a gente pode repetir aqui abaixo com pequenas mudanças
                // O Exception foi tirado, pois a gente não tava usando ele. Não tava fazendo nada com o seu parametro 
                // E aqui a gente pode passar novamente um ResultViewModel de lista de categorias, só que ao invés de passar os dados, passar a string do erro
                // E automaticamente ele vai entender que isso aqui é um error. E fica mais fácil ainda de se visualizar, se você estiver usando o Resharp
                // Se a gente clicar nesse ResultViewModel segurando o crtl, ele vai direto para a função que recebe apenas uma string de erro
                // Se clicar no result do Try, ele vai direto para a função onde a gente recebe os dados, e passa os dados como parametro
                // E isso é a famosa sobrecarga de métodos do nosso csharp, coisa que a gente já viu no curso de POO
                // Agora faz uns testes no Postman, um com o Docker parado, outro com ele aberto. Que tu vai ver que o nosso retorno já vai ta padronizado e bonitin
                return StatusCode(500, new ResultViewModel<List<Category>>("05XE01 - Falha interna no servidor!"));
            }
        }
        // Agora vamos padronizar o GetById, onde basicamente faremos a mesma coisa que fizemos acima
        [HttpGet("v1/categories/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] BlogDataContext context, [FromRoute] int id)
        {
            try
            {
                var category = await context
                    .Categories
                    .FirstOrDefaultAsync(c => c.Id == id);

                if(category == null)
                    return NotFound(new ResultViewModel<Category>("Categoria não encontrada")); // Aqui era pra ter uma tag na string pra padronizar o erro, mas coloco dps

                return Ok(new ResultViewModel<Category>(category));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Category>("05XE02 - Falha interna no servidor!"));
            }
        }
        
        // Agora vamos padronizar o Post, e ele possui diferenças, pois quando a gente retorna a categoria criada, a gente usa o Created
        // E o Created recebe dois parametros, o url da nova categoria, e o modelo que vai ser retornado
        // Assim como também, a gente vai precisar fazer validação do nosso Model, através do ModelState na mão, pois suprimimos essa validação automatica

        [HttpPost("v1/categories")]
        public async Task<IActionResult> PostAsync([FromServices] BlogDataContext context, [FromBody] EditorCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Nesse retorno do BadRequest a gente primeiro botou o ModelState.Values
                // Dentro do retorno do ModelState.Values, existem diversos objetos, e o nosso objetivo não é trazer coisas assim, mas sim padronizar o nosso retorno
                // Dentro desses diversos objetos, existem os erros que aconteceram na nossa validação, e a gente precisa deles. Mas como a gente faz pra pegar só esses erros dentro desses objetos?
                // Bem, a gente vai usar um conceito novo chamado de extensão de método
                // Todos os métodos de extensão se encontram na pasta Extensions. Então agora tu vai pra lá, especificamente para a classe ModelStateExtension.cs
                // Depois de entender tudo o que tava lá, agora a gente simplesmente cria um novo ResultViewModel, e passa como atributo, o ModelState chamando a nossa nova função de extensão
                // Dessa forma, ele vai trazer apenas os erros que a gente quer, e não aquele conjunto de objetos, e vai satisfazer também uma das funções construtoras do nosso ResultViewModel
                // Agora eu vou deixar todx o resto do código dentro da nossa padronização
                // E tbm vou copiar esse projeto, e criar a pasta Blog5, onde vou completar o projeto criando todos os controllers, ajeitando todas as tabelas, maps, etc. Cola lá!

                return BadRequest(new ResultViewModel<EditorCategoryViewModel>(ModelState.GetErrors()));
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

                return Created($"categories/{category.Id}", new ResultViewModel<EditorCategoryViewModel>(model));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<EditorCategoryViewModel>("05XE03 - Não foi possivel incluir a categoria"));
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResultViewModel<EditorCategoryViewModel>("05XE04 - Falha interna no servidor!"));
            }
        }

        [HttpPut("v1/categories/{id:int}")]
        public async Task<IActionResult> PutAsync([FromServices] BlogDataContext context, [FromRoute] int id, [FromBody] EditorCategoryViewModel model)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(new ResultViewModel<EditorCategoryViewModel>(ModelState.GetErrors()));

                var category = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);
                
                if (category == null)
                    return NotFound(new ResultViewModel<EditorCategoryViewModel>("Categoria não encontrada"));

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
                return StatusCode(500, new ResultViewModel<EditorCategoryViewModel>("05XE07 - Não foi possivel deletar a categoria"));
            }
            catch (Exception e)
            {
                return StatusCode(500, new ResultViewModel<EditorCategoryViewModel>("05XE08 - Falha interna no servidor!"));
            }
        }
    }
}
