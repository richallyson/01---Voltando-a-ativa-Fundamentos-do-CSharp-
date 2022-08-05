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
    // Pensa que muitas aplicações vão consumir a nossa API. Então uma coisa que a gente tem que pensar desde já, é como a gente vai suportar diferentes versões de dispositivos conectados na nossa api
    // Por exemplo, minha API recebeu uma atualização, mas alguns dispositivos ainda não realizaram essa atualização por falta de internet ou outros motivos
    // E esse suporte é feito através do versionamento
    // Imagina um cenário onde você atualiza a sua API, e nessa atualização muda algum campo de algo, ou adiciona, ou mesmo remove
    // O dispositivo que ainda não atulizou pra nova versão dessa API, vai quebrar, caso a sua API não trabalhe com versionamento
    // Mais um exemplo: vamos supor que um aplicativo consome a sua API de Blog, um aplicativo para Android. Esse app consome um endpoint especifico da sua API chamado de meuservico.com/categories
    // Agora imagina que o time ou pessoa responsável pela API precisa realizar mudanças internas dentro das categories, e no meio dessa mudança, por algum motivo, a API parou enviar o Id da Categoria
    // O que aconteceu com essa aplicação que consumia essa API? Como elas esperavam o Id dessa Categoria, elas quebraram
    // Mas ai a gente pensa: poxa, num é só soltar uma correção que resolve tudo? Não kk Pois os apps de qualquer mobile primeiro passam pela loja para só depois seram aprovados. Seja um lançamento ou atualização
    // E nesse processo de passar pela loja, ele vai ficar em processo de autorização, para só depois de fato ser liberado pra loja em si, e isso geralmente demora em cerca, duas horas
    // Ou seja, durante no minimo duas horas, diversas pessoas que usam o app que consome essa API, ficarão na mão, sem conseguir fazer nada no aplicativo. E no caso da Apple é pior ainda, pois o app pode ficar esperando aprovação da loja por até dois dias
    // É isso dentro do cenário dos usuários que sempre tão atualizando os seus apps. Ainda existe o cenário em que muitas pessoas não atualizam seus apps
    // No caso do front-end das telas das aplicações web, muitas dessas aplicações, mesmo elas sendo mais fáceis de atualizar por não ter uma loja, basta subir pro servidor e pronto, eles tem muito cache, e esse cache previne que versões novas sejam atualizadas as vezes
    // Ter esse controle é muito dificil. Então a gente tem que controlar isso de que forma? Dentro da nossa API
    // A gente tem que pensar também em versionar a nossa API pra que novas versões não quebrem o código antigo
    // E bem, a gente tem aqui um Get de Categorias. Como a gente faria o versionamento desse nosso código?
    // A forma mais simples e rápida que a gente tem de solucionar isso é adicionando o vi/ no começo do endpoint, como visto abaixo
    // Isso quer dizer que essa é a versão 1 do Get que trás todas as categorias pra gente
    // Então o nosso localhost (balta meteu um por enquanto kk), vai ficar: localhost:port/v1/categories
    // Lembrando que a gente poderia colocar essa rota v1 lá em cima, abaixo de ApiController, sendo assim criando um prefixo de rota
    // Porém, fica muito melhor de se colocar esse versionamento dentro das ações do controller do quê lá em cima pelo fato de que se caso eu queria adicionar uma versão nova dentro dessa controller, posso adicionar um v2 direto na ação, sem deixar o link assim: v1/v2/categories

        [HttpGet("v1/categories")] // localhost:port/categories (padrão REST de endpoint)
        public IActionResult Get([FromServices] BlogDataContext context)
        {
            var categories = context.Categories.ToList();
            return Ok(categories);
        }

        // Agora vamos supor que a gente vai ter outro método onde a gente não vai colocar o Id da categoria (na real não tem nenhuma função ainda que pegue a categoria por Id, mas imagina ai que tem kkkk). O que a gente pode fazer?
        // A gente pode ter outro método aqui embaixo, por exemplo, e ao invés de adicionar o v1/ no começo da rota, a gente adiciona o v2
        // E claro, esse método foi adicionado em uma nova versão. Vamos supor que a API foi lançada, e que agora estamos fazendo mudanas e adicionando um novo método Get, ou qualquer método que seja
        // E aqui a gente tem um método categories v2, e esse v2 é uma url diferente, e a url da v1, ela ainda ta lá
        // Então a gente tem as duas urls vivas. Então os apps que não foram atualizados ainda, que chamam a versão 1 da nossa API, eles vão funcionar
        // E os apps que já tão atualizados que já podem chamar a versão 2, eles também vão funcionar
        // Então assim a gente consegue colocar essas versões lado a lado. É só criar um método novo, e trocar a url que isso funciona
        // Claro que dai tem a questão da bagunça do código, eu tenho um Get2. E seu eu tivesse um Get3, Get4...?
        // Então, obviamente a gente tem que ter cuidado com isso pra não crescer muito
        // E bem, você tendo a versão 2 no ar, você já pode iniciar uma tarefa de comunicar o pessoal que consome a nossa API falando:
        // "oh pessoal, a gente vai suportar a versão 1 até daqui 3 meses, vocês tem 3 meses pra mudar o app ai, da tempo o suficiente de ajeitar tudo. Passou os 3 meses a versão 1 vai sair do ar e só vai ficar a versão 2"
        // E claro que existem n outras estratégias para versionar a nossa API, e essa nossa estratégia é uma estratégia simples e direta (E eu gostei pra caramba) 
        // E a partir daqui a gente vai ver muito o v1 por ai, pelo fato de que a gente ta criando a nossa API, sendo assim, é a v1 da nossa api. Já vamos colocar tudo versionado pra n ter problema nenhum

        [HttpGet("v2/categories")] // localhost:port/v2/categories
        public IActionResult Get2([FromServices] BlogDataContext context)
        {
            var categories = context.Categories.ToList();
            return Ok(categories);
        }

        // Bem, agora vou criar outra pasta pois a gente vai modificar muito o código, então pra deixar os exemplos aqui condizentes com os comentários, vamo pra pasta Blog2
        // Esse código abaixo foi escrito por mim e não pelo Balta. Ma ta bem certin. Confia!

        [HttpPost("categories")]
        public IActionResult Post([FromServices] BlogDataContext context, [FromBody] Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();

            return Created($"{category.Id}", category);
        }

        [HttpPut("categories/{id}")]
        public IActionResult Put([FromServices] BlogDataContext context, [FromRoute] int id, [FromBody] Category category)
        {
            var model = context.Categories.FirstOrDefault(c => c.Id == id);
            if(model == null)
                return BadRequest(model);

            model.Name = category.Name;
            model.Slug = category.Slug;

            context.Categories.Update(model);
            context.SaveChanges();

            return Ok(model);

        }
    }
}
