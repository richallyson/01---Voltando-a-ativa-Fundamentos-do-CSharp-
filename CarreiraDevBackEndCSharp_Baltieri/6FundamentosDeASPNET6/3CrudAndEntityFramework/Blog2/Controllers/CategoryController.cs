using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
    
        // = Async e Await = Tudo o que eu vou falar aqui já foi dito no curso de EF, mas vamo reforçar né?
        // Vamos melhorar os nossos métodos trabalhando com o Async e o Await.
        // Como já vimos no curso de EF, Async e Await tornam os nossos métodos em métodos assincronos
        // Async significa que o método vai ser executado de forma assincrona, numa thread separada
        // E o Await significa que a gente vai aguardar pela execução desse método
        // E agora vamo vê como a gente usa o async e o await nesse nosso cenário. Cuida!
        // E bem, a maioria dos métodos do EF, tem as suas formas convencionais como o ToList(), mas também tem a sua forma assincrona, como o ToListAsync()
        // E o que significa? Significa que você pode disparar esse método e fazer outras coisas e deixar esse método executando em segundo plano
        // Ou seja, a gente pode fazer uma paralelalização das nossas tarefas. Posso fazer diversas tarefas de forma paralela
        // Só que a partir do momento em que a gente chama o ToListAsync, a nossa váriavel deixa de ser uma variavel de lista de categorias e se torna uma Task
        // Task em inglês, significa tarefa. Em todos os métodos que a gente usa assincrono, ele nunca vai retornar os dados direto pra gente
        // Ele vai ser sempre uma tarefa, porquê a gente ta paralelizando a concorrência deles, a gente vai executar em paralelo
        // Para entender melhor: se a gente criasse mais 4 tarefas de ToListAsync dentro desse nosso método, os 4 iam ser disparados na mesma hora
        // Ele não ia funcionar de forma sincrona, que no caso seria realizando cada coisa de uma vez. Fazendo uma tarefa para só então ir pra outra
        // No caso ele não iria executar apenas um, pra ir no banco pegar as infos, e voltar, e só depois ir executando o resto em forma de fila. Ele executa logo tudo duma chibatada, o bixo é doido
        // Ele ia chamar os 4 dumas vez, e na hora que foram chegando os dados, ele deixa os métodos prontos pra gente fazer o que deseja com esses dados recebidos
        // E isso é basicamente o que o Async faz pra gente
        // E a gente também pode transformar o nosso método em um método assincrono. Basta botar o async depois do public
        // E dessa forma a gente pode chamar esse nosso método assincronamente. Mas no que isso muda pro nosso servidor?
        // Significa que ele consegue trazer essa requisição, e executar ela em threads separadas
        // Parece bobagem isso, mas só de você tornar um método em async, faz com que o ASP.NET consiga gerenciar n outras requisições assincronas.
        // Ou seja, sem o async, ele vai fazer uma coisa de cada vez. Com o async ele vai gerenciar as coisas de forma paralela
        // Então, se chegar 10 requisições, ele vai processar todas as 10 pra gente (se o processador/máquina for capaz kk)
        // E a medida que essas requisições forem sendo completadas, ele vai retornando os resultados pra tela
        // Então, no nosso caso aqui, SEMPRE QUE POSSIVEL, utilizem o public async junto com o nosso querido IActionResult
        // E bem, lembra que eu disse que no nomento que a gente botou o ToListAsync na nossa requisição a nossa variavel virou uma tarefa?
        // Pois bem, os métodos assincronos, eles nunca retornam um objeto concreto, ele sempre retorna uma tarefa
        // Sendo assim, a gente tem que definir o nosso retorno agora como uma Task, pois o async sempre retorna Tasks e não objetos concretos
        // Para isso, basta você mudar o seu retorno para Task, e passando pra dentro dessa Task o tipo que a tarefa vai retornar
        // E como a gente já sabe, pra gente já trabalhar bem com os status Http a gente usa o IActionResult como retorno
        // A Task pode passar algo como retorno dentro dela, seja uma lista e objetos ou mesmo nosso lindo IActionResult
        // Sendo assim, como a gente deseja trabalhar com tudo bonitinho dentro das requisições Http, tratando todos os status, a gente passa o IActionResult dentro da Task
        // E é só isso que a gente precisa fazer quando trabalha com metodos async. Passar a Task do tipo IActionResult como nosso retorno
        // Dessa forma, ao final, a gente vai conseguir usar todos os códigos do range http, e retornar a nossa tarefa. E dessa forma o ASP.NET pode disparar váaaaarios métodos
        // Supondo que nosso site ta bombando, tendo muitas requisições pra nossa API, dessa forma a gente vai poder disparar diversas requisições ao mesmo tempo dentro da capacidade do nosso servidor
        // E toda vez que a gente usa o async é de boa prática a gente especificar que o nosso método tbm é async. Ou seja, o nosso método que se chamava apenas Get, agora vai se chamar GetAsync
        // Outra coisa que a gente também te de mudar é o nosso retorno. Esse nosso método é uma tarefa né? E lembra que eu disse que quando a gente bota o ToListAsync pra trazer as categorias a nossa váriaval também vira uma Task?
        // Ou seja, a gente ta pegando a lista de categorias que é uma tarefa e retornando para uma tarefa que é o nosso método. Retornando uma tarefa em cima de uma tarefa, ou seja, a gente tem uma tarefa (metodo) que retorna uma tarefa (lista de categorias). E isso não é legal
        // O retorno dentro do nosso método, sempre tem que ser algo concreto, e não uma tarefa. Não é legal duma task retornar outra task pra ele, pois isso vai gerar uma cadeia muito louca dentro do ASP.NET
        // Ou seja, o nosso retorno precisa ser um a lista de categorias concreta e não a tarefa em si. Se a gente passasse como retorno no Ok um objeto, já serviria para saciar isso
        // Porém, a gente quer retornar a nossa lista de categorias, e pra que a gente retorne a lista e não uma tarefa, a gente usa o AWAIT antes da linha que vai trazer a lista de categorias em si
        // Dessa forma ele entende que o nosso método ToListAsync, nosso método assincrono, ta fazendo algo e retornando algo de fato materializado, concreto, uma lista de categorias
        // Então, a nossa váriavel de categorias ta falando: categories = await (que significa aguarde). Então a gente vai aguardar esse contexto ser executado, vai aguardar ele ir no banco, pegar as informações, pra depois a gente voltar
        // Afinal, não faz sentido a gente retornar essa task de busca das categorias, dizer que ela completou, sem ter os dados
        // E como a gente ta usando Resharp, na hora que a gente bota o Await antes do código de pegar a lista, ele já muda o tipo da váriavel novamente para uma list de category (deleta o Await que tu vê). E antes sem o await ele mostrava a nossa váriavel como uma task
        // Ela não deixa de ser uma tarefa. Só que agora como ele sabe que só vai realmente fazer o retorno quando tiver com os dados em mão, ele define a nossa váriavel pra gente como o retorno final que ela vai ter
        // E bem, a gente ta usando um método async mas ta aguardando algo ser retornado dentro dele com o Await. Pode parecer sem sentido mas não
        // Mas isso não significa que o nosso método de pegar as listas vai ser executado imediatamente
        // Então, se você tivesse outros códigos abaixo dele, primeiro, ele iria passar pelo nosso ToListAsync e ia gerar uma tarefa 
        // Depois os códigos abaixo iriam processar o que podiam processar
        // E códigos que dependem da lista de categorias, obviamente teriam que aguardar, pois a lista ta com o Await
        // Mas o resto dos códigos conseguem de fato ser processados de forma paralela
        // É como se fosse aberta uma nova thread, um novo caminho para executar essa busca das categorias, enquanto o resto do código anda
        // Então, isso desafoga bastante o processador, desafoga bastante o servidor. E a gente começa a usar multitarefas, usar o que melhor tem do dotnet em relação a performance
        // E uma dica importante: uma vez que o método é async, tudo o que poder ser assincrono dentro do método, faça

        [HttpGet("v1/categories")] 
        public async Task<IActionResult> GetAsync([FromServices] BlogDataContext context)
        {
            var categories = await context.Categories.ToListAsync();
            return Ok(categories);
        }

        // Agora vamo criar o resto do CRUD em async, no caso, transformar o que já tem e criar o que não tem
        // Não vou explicar sobre as mudanças, pq já tem uma lapada gigantesca de comentário acima que explica tudo
        // E o resto a gente já fez no módulo anterior desse curso. E depois abre teu Docker e Postman pra testar tudo

        [HttpGet("v1/categories/{id:int}")] // Em geral, a gente pode definir o tipo do parametro que a gente recebe na rota direto na rota
        public async Task<IActionResult> GetByIdAsync([FromServices] BlogDataContext context, [FromRoute] int id)
        {
            var category = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if(category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost("v1/categories")]
        public async Task<IActionResult> PostAsync([FromServices] BlogDataContext context, [FromBody] Category model)
        {
            await context.Categories.AddAsync(model); // Sempre veja se o método suporta async
            await context.SaveChangesAsync(); // E se suportar async use e não se esqueça do await antes

            return Created($"categories/{model.Id}", model);
        }

        [HttpPut("v1/categories/{id:int}")]
        public async Task<IActionResult> PutAsync([FromServices] BlogDataContext context, [FromRoute] int id, [FromBody] Category model)
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

        [HttpDelete("v1/categories/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromServices] BlogDataContext context, [FromRoute] int id)
        {
            var model = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (model == null)
                return NotFound();

            context.Categories.Remove(model);
            await context.SaveChangesAsync();

            return Ok("Categoria apagada com sucesso!");
        }
    }
}
