using Todo.Data;

var builder = WebApplication.CreateBuilder(args);

// = Entendendo os Controllers = Chamando o nosso HomeController
// E como a gente faz pra chamar o nosso Controller aqui? A gente primeiro precisa configurar o ASP.NET, e dizer pra ele: Olha ASP.NET, a gente ta usando controllers, ta?
// Sendo assim, a gente vai dizer pro ASP.NET que a gente não vai ter o nosso código todo aqui dentro (das requisições), mas sim nos Controllers
// E pra fazer isso é extremamente simples. Primeiro a gente vai acessar o builder, que é o método que a gente usa pra construir a nossa aplicação Web
// E dentro do builder tem um cara que a gente vai usar muito, que é o Services. Então todos os serviços que a gente for utilizar, seja ele do ASP.NET, do EF, ou qualquer outra coisa...
// eles vão ta sempre dentro do Services. Quando a gente da um builder.Services. vai aparecer uma afinidade de coisas, de funções, mas no nosso caso, a que a gente vai usar é a AddControllers();
// E ao fazer isso, ao chamar a linha builder.Services.AddControllers(); a gente adiciona suporte aos Controllers aqui da nossa aplicação
// Logo abaixo da nossa instaância do app, a gente vai colocar mais uma linha de código. Nesse local, vão ficar outras configurações do nosso programa
// Mas nesse momento a única configuração que a gente vai chamar é o app.MapControllers();
// Depois da gente adicionar o serviço que da suporte aos nossos Controllers, a gente tem que falar pro ASP.NET quais funções que os nosso Controllers vão fazer
// Que no caso, a gente vai ta dizendo pro ASP.NET que os nossos COntrollers vão ta fazendo a mesma função do MapGet, MapPost, etc
// Então a gente adiciononou os controllers aqui, através do serviço, e na instância do app, mandou ele mapear os controllers
// Falando assim: oh, busca tudo o que tiver ai que herde de Controller ou ControllerBase, e dentro disso busca todas as funções Http, e monta uma tabela de rotas pra gente, para que o ASP.NET possa endereçar as requisições pra dentro dos nossos Controllers
// E depois de ter o controllers configurado, e ter dado suporte a eles e mapeado eles aqui no nosso program, a gente já pode dar um dotnet run, que o nosso Get do Controller já vai ser chamado

// = Lendo itens do banco de dados = Começa aqui e termina nos controllers
// Lembra que no nosso curso de EF, sempre que a gente queria ler algo do banco, a gente tinha que criar uma instância do nosso DbContext dentro de um using, para só assim conseguir fazer as nossas queries?
// E lembrando que a gente tinha que fazer isso pelo fato de que em hipotese alguma a gente nunca deveria ter mais de uma conexão aberta, e o using fazia o dispose dessa conexão pra gente logo apóe a gente realizar oq ue desejava, dentro dele
// Pois é. Aqui no ASP.NET a gente não precisa fazer isso, pois a gente pode deixar o nosso DbContext rodando como serviço para toda nossa aplicação. E quando você desejar fazer uma leitura no banco, basta você chamar esse serviço
// E para isso a gente vai usar novamente o builder.Services, pois dentro dele existe uma função onde a gente vai chamar o nosso AppDbContext que criamos
// A nossa linha de código vai ficar assim: builder.Services.AddDbContext<AppDbContext>();
// Como já dito acima, o Services possui diversas funções que ajudam a nossa vida no desenvolvimento ASP.NET, e uma delas é a capacidade de adicionar um DbContext como serviço através dessa função mostrada
// E reiterando, a partir do momento em que você digita essa linha de código, nossa aplicação pode chamar esse serviço quando desejar acessar algo do banco
// E para isso ela usa um conceito chamado de INJEÇÃO DE DEPENDÊNCIA (Do qual vai ser estudado mais a fundo no futuro)
// Antes de ir pros controllers vale dizer que dessa forma o ASP.NET vai configurar o nosso Context por REQUISIÇÃO, de uma forma muito mais simples e fácil. 
// Ou seja, sempre que uma requisição for realizada, ela vai abrir uma conexão (criar o objeto), realizar o que deve ser realizar e depois realizar a destrução desse objeto (fechando a conexão). E sempre impedido que mais de uma conexão fique aberta ao mesmo tempo
// Agora, pra gente entender melhor, volte para o nosso Controller, especificamente para a nossa função Get
builder.Services.AddControllers(); // Da suporte aos controllers
builder.Services.AddDbContext<AppDbContext>(); // Chamando o nosso DbContext como serviço para toda a aplicação

var app = builder.Build();

app.MapControllers();

app.Run();
