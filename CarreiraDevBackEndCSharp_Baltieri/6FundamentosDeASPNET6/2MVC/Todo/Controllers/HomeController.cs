using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers
{
    // = Entendendo os Controllers =
    // O que é um controller no MVC? É nada menos que uma classe que herda de Controller
    // Caso você herde apenas de Controller, ele vai criar um Controller genérico pra gente
    // Para que ele venha com mais funções e seja robusto, a gente herda de ControllerBase, ao invés de apenas Controller
    // O Balta diz que para as APIs é sempre melhor herdar de ControllerBase, por ter mais opções
    // O ASP.NET permite que a gente trabalhe tanto com APIs quanto com a criação de sites, WebApps, por exemplo
    // Então, esse controller aqui é um controlador que vai servir só pra API, só pra JSON, ele não vai retornar HTML, apenas JSON
    // E para que isso aconteça da melhor forma possivel, a gente vai decorar ele, usar um decorator chamado de [ApliController]
    // Essa é a forma mais correta de se criar um COntroller para uma API.
    // Através do Decorator a gente disse pro ASP.NET que a gente ta trabalhando com uma API, e que essa classe é um ApiController, um controle de uma API
    // Sendo assim, ele vai retornar apenas JSON
    // E como a gente melhora esse controlador? Bem, vamos agora para o corpo da classe
    [ApiController]
    // [Route("home")]
    public class HomeController : ControllerBase
    {
        // Todo método publico dentro de um controller, é comumente chamado de Action
        // Então toda vez que você tem métodos dentro do controller, você chama eles de Action
        // Vocês lembram que no nosso Program.cs, quando a gente cria a nossa aplicação, ele trás um método MapGet() pra gente? Especificando que ele vai fazer um Get de algo
        // Se a gente ta criando um Get aqui dentro do nosso controller, que dentro do MVC são os os itens que vão receber as requisições, gerenciar essas requisições e devolver um valor pra tela...
        // Como a gente fala pro ASP.NET que esse Get aqui é realmente um Get de requisição? Novamente, através de um atributo, e no caso, um atribudo chamado de [HttpGet]
        // E ao colocar o ASP.NET sabe que esse método é GET
        // E isso vai funcionar para todas as outras ações, como o Post, Put, Delete, etc. Toda vez que você criar uma ação dentro de um Controller, você tem que especificar que requisição ele vai realizar
        // Se você não colocar nenhum atributo, o ASP.NET vai entender que esse método é um método do tipo Get, mas é sempre bom deixar o código mais expressivel o possivel pra quem bata o olho já consiga ver que isso aqui é um [HttpGet]
        // E bem, depois disso tudo, a única coisa a mais que a gente precisa colocar aqui pro ASP.NET saber como a gente encontra esse Controller, é a sua rota
        // Lembra que dentro do nosso método MapGet() a gente possui dois parametros, onde o primeiro paremetro é uma rota? Ou seja, sempre que eu entrar naquela rota, vai acontecer um Get de algo que foi passado como segundo parametro dentro do MapGet
        // E no caso do MapGet do Program.cs quando a gente cria um projeto, quando a gente entra na rota base, que é apenas com a barra (/), ele vai retornar um Hello World pra gente
        // Como eu faço para realizar esse mesmo comportamento chamando o Get do meu controller? Como eu faço para chamar esse Get do meu controller quando eu entrar em uma certa rota?
        // A gente faz novamente através de um atributo chamado de [Route("nomeDaRota")]
        // Toda vez que a gente coloca um atributo chamado Route aqui, você pode abrir parenteses e dentro dele (string) e passar a rota que deseja chamar esse Get
        // Ou seja, sempre que eu entrar na rota "/", esse Get do nosso controllador vai ser chamado, e retornar o que se espera
        // E a gente pode fazer muitas coisas com a rota, como fizemos no módulo passado, inclusive passar um parametro dentro dele
        // A gente tbm pode colocar um route na nossa classe como visto no route abaixo do ApiController. Ao fazer isso, essa rota vira um prefixo de rota
        // E isso significa que todas as rotas abaixo, vão ter o home na frente. Se a gente descomentar o route acima da classe, e tentar entrar no localhost:porta/m não vai mais rodar, pois antes do barra ele espera um prefixo de rota
        // E isso é acumulativo. Cada vez que você coloca uma rota acima, a rota abaixo vai precisar trazer o prefixo da rota acima pra poder acessar o que deseja
        // E dessa forma com o prefixo de rota acima, caso fossemos chamar o nosso get do controller, o endereço ficaria assim: localhost:porta/home. Ou seja, o prefixo de rota bem logo após 
        // Porém a gente não vai usar isso agora
        // Outra coisa importante é que o nosso route pode ser resumido direto no nosso HttpGet. Para isso basta colocar a rota na frente do Get, como vemos abaixo no nosso exemplo
        // Porém, como o Balta as vezes da umas esquecidas kkkk Se a gente tentar acessar essa nossa rota, ele não vai entrar nesse nosso Get do nosso Controller, mas sim no MapGet do Program.cs. E é justamente isso que a gente vai ver agr, como chamar esse Get e não do do Program
        // Agora pode ir pro Program.cs que o trabalho vai ser feito lá

        [HttpGet("/")]
        // [Route("/")]

        // = Lendo itens do banco de dados = Continuando o que foi começado no Program.cs
        // Como havia dito no Program.cs, a gente agora é capaz de usar o nosso DbContext como serviço em toda nossa aplicação através do uso de uma injeção de dependência. Mas, como a gente faz isso?
        // Bem, para isso a gente primeiro tem que instanciar o nosso DbContext como parametro do nosso Get
        // E para gente ser capaz de usar o Serviço de DbContext que a gente criou na Program, basta a gente adicionar a injeção de dependência [FromServices] atrás do tipo passado como parametro
        // A partir desse momento, você realizou uma injeção de depêndencia nesse Get, e pode realizar leituras no banco, sem precisar de todo aquele código que a gente fazia no EF
        // Para exemplo, a gente vai ler todos os itens da nossa tabela Todo. E claro, que para isso a gente tem que definir o nosso retorno como uma Lista de Todo
        // E a forma da gente realizar as nossa queries continua como a gente fez no curso de EF. E lembrando né, que o ToList vem sempre ao final
        public List<TodoModel> Get([FromServices] AppDbContext context)
        {
            return context.Todos.ToList();
        }

        // Fazendo um Get recebendo uma id como parametro da rota. Sendo assim, retornando apenas um Todo, e não uma lista
        // Se você quiser, pode colocar o [FromRoute] antes da instancia de id como parametro, mas se não quiser, o ASP.NET vai ser inteligente o suficiente pra entender o que vc deseja fazer
        // Durante todo esse módulo o balta fala: por enquanto a gente vai deixar assim e depois a gente vai ver soluções melhore
        // Então a gente já sabe que tem forma melhor de fazer, mas é sempre bom ir aprendendo de forma gradativa e vendo como as coisas podem funcionar, mesmo no cenário menos otimizado
        [HttpGet("/{id:int}")]
        public TodoModel GetById(int id, [FromServices] AppDbContext context)
        {
            return context.Todos.FirstOrDefault(x => x.Id == id);
        }

        // = Criando um registro (Enviando itens com Post) =
        // Bem, acho que não tem muito o que explicar nesse código, pois depois de toda a explicação que a gente fez, já ta tudo muito implicito
        // A diferença é que dessa vez a gente vai receber um Todo do Postman e vamos salvar esse Todo aqui no nosso DataContext
        // Mas agora, como eu faço pra receber esse Todo que a gente espera no nosso Post? Lembra que a gente já falou que o ASP.NET converte para JSON e converte de JSON?
        // E é justamente por isso que a gente vai usar o Postman para fazer esse nosso Post. A gente vai compor um JSON nele, para ser mandado para o nosso Context, convertido como código Csharp
        // E pra isso a gente precisa abrir o postman, botar a nossa requisição como Post, e compor esse nosso JSON que vai ser enviado pra cá
        // E como a gente já sabe, que diferente do Get o Post tem um Body, que é justamente onde a gente vai trabalhar. Fazendo aquele mesmo esquema de marcar como Raw e mudando o formato de escrita pra JSON
        // No Postman você compõem o nosso JSON passando todas as propriedades que se espera na hora de construir um Todo. E lembrando que pode deixar o nome das propriedades em minusculo, pois o ASP.NET já resolve isso pra gente na hra de trazer pra cá
        // Bem, a forma como as propriedades são colocadas no postman diferem pouca coisa de como elas são atribuídas aqui. Então caso tenha alguma duvida de como deve colocar a data ou o booleano, pesquisa no Google como deve ser feito
        // Por exemplo, a gente preenche data dessa forma dentro do Postman: "createdAt": "2022-08-03T14:00:00" (ano-mês-diaThoras:minutos:segundos)
        // Outra curiosidade legal é que se a gente digitasse a nossa propriedade CreatedAt dessa forma "created_at", também seria aceito, e o ASP.NET trataria tudo pra gente
        // Como eu já havia dito, o post diferente de um get tem um Body, e a gente precisa especificar isso. A gente tem que dizer de qual parte da requisição ta vindo esse Todo
        // E a gente faz isso usando a notação [FromBody] antes da instância do objeto que a gente deseja receber. Sem isso, o Postman vai enviar a requisição e quando o ASP.NET for receber, vai ficar perdido, sem saber de onde vem ela, se é do header, body, etc
        // Fazendo isso, a gente diz que do corpo da requisição, vai chegar esse TodoModel pra gente. Pois a gente está recebendo algo e não enviando, então tem que sempre explicitar isso
        // Com tudo isso pronto, basta dar um send no nosso Post do Postman, esperar dar um Status 200 com o retorno do JSON que a gente enviou
        // E para ter certeza que tudo deu certo, basta agora dar um Get que ele vai retornar pra gente esse nosso objeto que foi criado
        [HttpPost("/")]
        public TodoModel Post([FromBody] TodoModel todo, [FromServices] AppDbContext context)
        {
            context.Todos.Add(todo);
            context.SaveChanges();
            return todo;

        }

        // = Alterando Registro (PUT) = 
        // Novamente só vou explicar do código algo que for novo, como alguma injeção de dependência, etc
        // A gente atualizava algo no banco pegando o Id desse objeto/item de tabela. O Balta fala que existem casos onde os programadores fazem isso na função
        // Porém, ele prefere resgatar esse id direto da rota, e é assim que a gente vai fazer. Sendo assim, a gente vai acessar aquele objeto pela rota dele, alterar e mandar de volta alterado
        // A gente continua usando o [FromBody] pois a informação que iremos enviar vem do Body
        [HttpPut("/{id:int}")]
        public TodoModel Put([FromRoute] int id, [FromBody] TodoModel todo, [FromServices] AppDbContext context)
        {
            // Primeiro a gente recupera o item do banco
            // Lembrando que o todo instanciado como parametro é o que vem da tela (do postman) e o model é o que a gente resgatou do banco
            var model = context.Todos.FirstOrDefault(x => x.Id == id);
            // Só que esse item que a gente ta tentando recuperar pode ser nulo, e se ele for a gente faz um if pra parar nossa requisição
            if (model == null)
                return todo;

            // Agora a gente vai equiparar o todo que veio da tela com o todo que a gente resgatou do banco na variavel model
            // No caso, a gente vai atualizar os dados do nosso Todo resgatado do banco, passando os dados do Todo que veio da tela
            // Nunca se deve atualizar o id. E nesse caso, não faz sentido atualizar o CreatedAt
            model.Title = todo.Title;
            model.Done = todo.Done;

            // Depois de atualizar os dados aqui, agora é a hora da gente atualizar os dados no nosso banco
            context.Todos.Update(model);
            context.SaveChanges();

            // E depois é só da um return no model com os dados atualizados
            return model;

        }

        // = Deletando registro (DELETE) =
        // Pra deletar um item, a gente vai fazer algo similar com o Put
        // A diferença é que a gente vai receber só o Id, e no Body não precisa ter nada
        [HttpDelete("/{id:int}")]
        public string Delete([FromRoute] int id, [FromServices] AppDbContext context)
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);

            context.Todos.Remove(model);
            context.SaveChanges();

            return "Todo removido com sucesso";

        }

        // Agora meu parceiro, é só ir pro teu postman e ir testando o put e o delete. Adiciona mais objetos, e vai testando.
        // Por aqui acabou. Pois a próxima aula desse módulo é dele melhorando esse código. Sendo assim vou criar um projeto novo pra deixar esse aqui com os comentários e exemplos
    }
}