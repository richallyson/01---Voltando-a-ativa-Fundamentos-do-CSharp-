using Blog.Data;using Blog.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .ConfigureApiBehaviorOptions
    (options => options.SuppressModelStateInvalidFilter = true );

builder.Services.AddDbContext<BlogDataContext>(); 

// = Continuando injeção de dependência =
// Já adicionamos um serviço antes, que foi o nosso context. Para o TokenService vai ser quase a msm coisa
// No caso do DbContext, a gente sempre usa o AddDbContext pois ele já é nativo, feito pra ele. Sempre!
// E bem, pro caso do nosso TokenService, a gente pode resolver ele de três forma possiveis
// Usando o AddTransient(), o AddScoped() ou o AddSingleton(). Cada um vai ser usado para um cenário desejado
// Esses tipos de serviços são descritos como life time. O tempo de vida do serviço
// Então, além da gente prover o nosso TokenService, a gente tem que dizer quando que ele nasce e quando que ele morre
// Cada uma dessas funções vai fazer algo especifico dentro disso que a gente falou

// == AddTransient ==
// Se a gente usa o AddTransient, ele sempre vai criar um novo serviço.
// Toda vez que a gente usar o [FromServices] TokenService, ele vai instanciar um novo TokenService pra gente 
// Ou seja, se eu chamo outro método dentro de uma função que tem o TokenService, ele toda vez vai criar uma nova instância
// Vai criar tanto a instância do método que tem TS, quanto a instância do metodo chamado que tem TS
// E isso se aplica infinitamente. Se uma função que tem TokenService tem um filho que usa TokenService...
// Caso essa função seja chamada em outra função, que também tem TokenService, ele vai a instância de cada coisa que tem a dependência
// Então para itens onde você não tem estado, que você não necessite que essa informação dure, por algum motivo você pode sempre usar o AddTransient()
// Resumindo, a instância vai ser criada sempre que precisar resolver a depêndencia

builder.Services.AddTransient<TokenService>(); // Sempre criar um novo

// == AddScoped ==
// No caso do AddScoped, ele dura por requisição
// Toda vez que ele for usado a primeira vez, ele vai ser criado, usado durante toda a requisição e deletado pelo GC
// Se você usa chama outro método que use também algum serviço do tipo AddScoped, dentro de um método que tb usa AddScoped
// Ele vai verificar, ver que ambos usam, e aproveitar o mesmo serviço para ser usado em toda a requisição
// Ou seja, diferente do AddTransient, que sempre cria uma nova instância caso seja chamado de novo dentro do método...
// Ele vai aproveitar o serviço que ta sendo já utilizado, para usar em todx método
// Ele vai falar assim: vou chamar função tal pra me ajudar. Já existe um TokenService nessa requisição? Sim!...
// então vou aproveitar a que já existe nessa requisição pra resolver todos os problemas sem ter que criar outro serviço
// Então, se você precisa que os itens tenham uma longa duração, use o Scoped. O DbContext se aplica a esse caso, por exemplo
// Porém, como o dbcontext tem sua adição como serviço nativo, a gente n precisa usar o Scoped, mas caso não tivesse a gente usaria ele pra adicionar o dbcontext
// Pois é o cenário que se aplica ao dbcontext. A gente precisa que nossos itens durem toda a requisição

// builder.Services.AddScoped<>(); // Dura por requisição

// == AddSingleton ==
// Ele é um padrão chamado de Singleton
// O AddSingleton, dado o inicio da sua aplicação, ele vai carregar o serviço na primeira vez que for chamado
// Depois disso ele vai ficar carregado na memória. Ou seja, não é levado pelo GC
// Ou seja, uma vez que você chamou o objeto, ele carrega pra memória do app, e fica lá pra "sempre"
// A única forma de derrubar ele seria fechando o app e abrindo de novo, ai ele repetiria o mesmo processo
// Ou seja, sempre a mesma instância. E a gente tem que ter cuidado com isso, pois ele vai ta vivo eternamente
// Se você carregar muita coisa usando o Singleton, ele vai ficar consumindo muita memória da nossa aplicação, sem necessidade

// builder.Services.AddSingleton(); // Um por app

// E bem, no caso do nosso serviço a gente vai colocar o nosso TokenService como AddTransient
// Como a gente só vai usar ele em um pedaço especifico da aplicação, é o mais tranquilo pro contexto
// Agora sapeca um dotnet run, e faz uma requisição pro endpoint que retorna o token, no Postman
// Se tudo der certo, ele vai retornar uma string gigantesca toda random
// Essa string é o nosso token encriptado pela nossa chave jwt
// Agr copia esse token que foi gerado, pra gente decodificar ele em um site chamado jwt.io
// Como a gente sabe, nosso token não ta valendo nada kk Ta sendo apenas gerado
// No site, desça um pouco e cole o token
// Pode ver que ele possui 3 cores, sendo a vermelha o header, o roxo o payload e o azul a assinatura do token
// Então, o nosso Token é dividido em 3 partes, e essas partes são separadas por pontos, gerados automaticamente pelo Asp net
// Logo ao lado temos uma janela com 3 partes, que explicam exatamente o que tem em cada uma dessas divisões
// O header diz o algoritmo usado pra criar o token, que no nosso caso foi o HS256
// Assim como também no header diz o tipo do nosso token, que é jwt
// E isso significa que o nosso payload está no formato jwt, Json Web Token
// E por sua vez, o payload é o conteúdo do token, nessa parte vai ser de fato os dados refentes ao objeto 
// No nosso caso, quando fizermos, vai ser os dados do usuário
// E lembrando de que nunca passe informações sensiveis para esse payload, como o id, por isso é bom usar viewmodel
// Na parte onde está o payload, é possivel editar. Adicione alguma propriedade a mais e veja que o token vai sendo modificado
// E caso você pegue esse token novo gerado e mande de volta pra nossa aplicação, não vai funcionar
// Pois a partir do momento em que modificamos o payload, a sua assinatura mudou, que é o terceiro bloco de info da janela
// Essa chave secreta já é diferente da que a gente criou no COnfiguration.cs
// Ou seja, se você adiciona informações a mais depois, o token vai mudar, uma nova assinatura de chave vai ser feita, e o token fica invalido para o nosso programa
// Dado que ele já não tem mais a mesma chave secreta que a nossa
// E isso é um recurso de segurança que o aspnet tem
// Ou seja, se outra pessoa mudar o payload do nosso token, ele não vai ter mais acesso a aplicação, pois a assinatura vai ser mudada
// Para conseguir, ele teria que gerar uma assinatura com a nossa chave
// E pra gente entender melhor, vai em configuration.cs, copia a nossa chave, e no bloco verify signature tem uma caixinha onde você pode colar a chave
// Uma vez que você cola a chave, o token vai mudar de novo, e a partir desse momento, ele é válido para a nossa aplicação
// Justamente pelo fato de que esse token agora tem a mesma assinatura que a gente usa na nossa aplicação
// Dessa forma, o Token se torna válido pra gente, pois utilizamos a nossa chave para assinar o token
// E é justamente por isso que a chave de assinatura deve ficar apenas no nosso servidor, para evitar que pessoas modifiquem o payload e assinem o novo token com a nossa chave

// Bem, agora como a gente vai mudar um pouco da estrutura do TokenService, eu acho melhor criar um proj novo
// Então, cola no Blog2, que lá vai ta a continuação desse conteúdo

var app = builder.Build();

app.MapControllers();

app.Run();
