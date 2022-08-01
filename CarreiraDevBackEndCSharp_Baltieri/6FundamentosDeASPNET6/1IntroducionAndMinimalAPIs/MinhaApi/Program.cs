// Criando uma aplicação WEB
var builder = WebApplication.CreateBuilder(args);

// Construindo a aplicação WEB
var app = builder.Build();

// = Mapeando uma requisição =
// Como fazemos para receber requisições e retornar informações pra nossa tela?
// Usando o app.MapGet(). Por isso é de importância aprender os verbos http, pois dentro dessa função a gente já traz um
// Ou seja, se a gente quer obter uma informação, a gente vai usar o método Get, se quiser enviar, usar o método Post
// Se quiser atualizar alguma info, usar o método Put. E se quiser deletar, usar o método Delete
// Então, app.MapGet(). Dentro dele podemos ver que temos alguns parametros sendo passados
// O primeiro é uma string com uma barrinha, da qual se refere a nossa url. Que é exatamente a barra que fica ao final, depois da porta, no caso da nossa aplicação
// Esse é o conceito de rotas no ASP.NET. Uma coisa, da um crtl + c no teu terminal que ta rodando a aplicação e da um dotnet watch run
// O dotnet watch run atualiza automaticamente pra gente, tudo o que a gente fizer no código, depois de salvar, claro
// E bem, se você alterar o primeiro parametro do MapGet() para por exemplo "/banana" e salvar o arquivo com o dotnet watch run rodando, ele vai retornar um erro
// Pelo fato de que essa rota não foi criada. Esse erro que vai dar, vai ser o 404, que é justamente o clássico Page Not Found
// E claro que isso é culmulativo, eu posso adicionar mais rotas caso eu queira, como eu fiz com o segundo MapGet(). Sendo assim a gente pode ter mais de um endpoint
// Endpoint de uma API seria: um endereco utilizado para comunicacao entre uma API e um sistema externo. Pensando mais "tecnicamente", um endpoint em uma API seria uma URI mapeada.
// Então a gente consegue começar a endereçar as coisas dentro da nossa API, utilizando esse esquema que é chamado de Rotas
app.MapGet("/", () => "Hello World!");
app.MapGet("/watch", () => "Meu dotnet watch run não ta dando hot reload :(");

// = Funções anonimas =
// Para explicar melhor essa parte eu criei uma terceira rota pra gente, ou se preferir chamar, um terceiro endpoint
// E bem, falamos do primeiro parametro do MapGet, do mapeamento da requisição GET, que é básicamente o endereço da nossa rota
// Agora vamos falar sobre o segundo parametro da nossa função MapGet, que é bem diferente do que já vimos até agora
// Acho que o mais estranho é o começo desse segundo parametro: () =>
// A gente já conhece o expression bodied, que é o sinal de igual com a setinha, mas nunca tinhamos visto dois parenteses vazios sendo passados como parametro
// Pois bem, isso é uma função anonima. Uma função que basicamente não tem nome e nem nada (a pobi lkkkk)
// Ou seja, esse segundo parametro recebe uma função. Mas pra que a gente não precise criar uma função pra ocupar mais espaço e só dps passar como parametro, a gente usa a função anonima
// Esse tipo de função veio com o csharp 10, é basicamente como se a gente tivesse criando um metodo mesmo
// Vamos supor que eu criei um metodo como o mostrado abaixo (comentado)
// void Teste(){"regra de negócio"}
// Com o Csharp 10 a gente é capaz de criar um metodo que não tem nome, e como a gente vai retornar apenas uma coisa, é possivel usar o expresion bodied nesse contexto do nosso MapGet
// Caso a gente fosse retornar mais de uma coisa, fariamos como fazemos normalmente, abrindo as chaves e botando as regras de negócio dentro
// app.MapGet("/anonima", () => {"regras de negócio"});
// Abaixo eu criei mais uns MapGet() pro exemplo ficar melhor. Um exemplo passando uma função como parametro
// Outro usando a função anonima com mais de uma regra de negócio dentro dela
// Agora pode ir testar no Postman, pois todas os endpoints vão ta funcionando direitin, e retornando o que a gente passou na função anonima. Todos os três
// Ps: toda vida to tendo que dar um dotnet run, pois o meu dotnet watch run não ta dando o hot reload. Caso o seu não atualize tbm, faça o mesmo
app.MapGet("/anonima", () => "Meu dotnet watch run não ta dando hot reload :(");
app.MapGet("/anonima2", Teste);
app.MapGet("/anonima3", () =>
{
    return "Meu dotnet watch run ainda não ta funcionando kk";
});

// = Parametros =
// Agora vamos bricar com os parametros do MapGet()
// Como retorno do endpoint /parametro, a gente vai usar o Results. E dentro Results a gente tem várias opções pra escolher
// E nesse caso, a gente usou o Results.Ok(), que já coloca o Status 200 pra gente, deixa tudo parametrizado pra gente saber que deu tudo certo na nossa requisição
// O Results.Ok() recebe algo como parametro, e no nosso caso passaremos a string Hello World! Porém ele também pode receber outros tipos
app.MapGet("/parametro", () =>
{
    return Results.Ok("Hello World!");
});

// Agora vamos entrar em outro cenário onde a gente espera um paremetro dentro do endpoint. Como a gente faz pra passar um parametro pra nosso metodo Get?
// Uma caracterista do metodo GET é que ele não tem corpo. A gente não consegue mandar informações no corpo da requisição. A gente só consegue mandar informações através da Url
// É definido como um método seguro e não deve ser usado para disparar uma ação (remover um usuário, por exemplo). As informações enviadas no corpo (body) da requisição são utilizadas para criar um novo recurso. 
// Também é responsável por fazer processamentos que não são diretamente relacionados a um recurso.
// A Url tem um limite de caracteres no browser (balta diz que são 2000), além de ficar muito mais exposta as informações. Tipo, não vale a pena a gente trazer na Url as coisas literais...
// Como uma url que o nome é nome=andre&senha=minhasenha
// Então, como a gente faz pra receber parametro dentro do Get? A gente usa as chaves {}, e dentro dessas chaves a gente passa o nome do parametro
// Na nossa função anonima a gente passa o tipo de retorno com o nome desse parametro que a gente deseja receber
// Ai depois a gente sapeca uma interpolação de string dentro do retorno do Results, e pronto. A gente vai ta recebendo como parametro o endereço do nosso endpoint
// Agora é só ir no Postman e passar qualquer nome (ou palavra) depois da barra que ele vai retornar o Hello junto com o nome que você passou
// Isso aqui se aplica em diversos cenários, dos quais a gente vai trabalhar bastante futuramente
// Se você tentar fazer como a url errada que eu disse acima, que seria fazendo nome=nosy, não vai funcionar. Pois de alguma forma ele detecta que ta rolando uma ação não segura
app.MapGet("/{nome}", (string nome) =>
{
    return Results.Ok($"Hello {nome}");
});

// E claro que a url também pode ser composta, como vista abaixo
// Dessa forma ele vai compor a url, vai entender que dps do /nome vem o name, que é o parametro que a gente deseja passar
app.MapGet("/name/{nome}", (string nome) =>
{
    return Results.Ok($"Hello {nome}");
});

// = Serialização Json =
// Agora a gente vai melhorar o nosso código e vamos criar um Post, pra enviar informação pra tela
// A gente acima recebeu da url a informação, mas agora a gente quer receber do corpo da requisição
// O Post recebe basicamente os mesmos parametros, que é uma url e uma função
// E agora vamos Mapear a nossa postagem!
// Uma coisa interessante das nossas APIs, é que a gente pode, e em muitos cenários a gente deve usar verbos diferentes pra mesma url
// Então a gente pode dizer que a nossa url base "/", ela pode receber tanto Get, quanto Post, quanto Delete
// E ele não vai se confundir, pois como a gente pode ver, são mapeamentos diferentes, o acima é um mapeamento de Get e o abaixo é um mapeamento de Post
// Pra gente fazer o nosso Post, vamos criar uma classe abaixo do app.Run(); (E claro que tudo isso é feito apenas pra demonstração, quando for em um cenário real, a gente vai separar tudo direitin)
// Então vamos supor que a gente quer enviar um User pro post, e depois a gente quer salvar esse User no banco e depois retornar alguma informação pra tela
// Pra isso a gente vai passar o retorno da função anonima como User
// Diferente do MapGet acima, a gente vai trabalhar agora com objetos complexos
// Primeiro o Balta fez um exemplo mais básico, onde no Results ele retornou apenas o user que a gente tem como parametro na função anonima: return Results.Ok(user); 
// Um exemplo mais complexo de trabalhar com a classe como retorno de um mapeamento de post vai ser trabalhado em outros módulos do curso
// E como a gente faz pra agora pra receber um usuário e enviar um usuário pra tela?
// Antes de tudo quero dizer algo. Imagina as aplicações, elas precisam ter uma integração com outras aplicações, só que a aplicação que a gente ta desenvolvendo funciona duma forma, e as outras de outra
// Então para isso, existem algumas padronizações nos formatos de dados que a gente vai enviar. Ou seja, para que a gente faça um Post é necessario seguir um certo padrão pra facilitar a vida de todo mundo
// E uma dessas padronizações, e provavelmente a mais conhecida, é um tipo chamado JSON (JavaScript Objetct Notation). É um objeto que o JavaScript entende por padrão
// Então as integrações com o front-end ou com outros projetos que suportam o tipo JSON, são EXTREMAMENTE comuns
// Então é muito provavel que a aplicação que vai consumir a nossa API vai trabalhar com o JSON, nos dias de hj. Antigamente a galera usava o XML (e ainda usam em algums projetos). Porém o JSON chegou, sendo mais leve, sucinto e mais fácil de se trabalhar que o XML
// E agora você deve ta se perguntando: mas se o JSON é entrada e se o JSON é saída, como que a gente vai converter a nossa classe User em Json? Como a gente vai converter um binário (que é o que todo código é no fim) em Json? E ao contrário, como funciona?
// E aqui vem a boa nóticia. O ASP.NET faz isso facinho pra gente
// Agora vai no Postman que a gente tem trabalho pra fazer lá. Mas claro, sempre indo e voltando aqui pra ver as instruções
// Crie uma nova aba no Postman, do tipo post e cole a nossa url padrão. E nessa requisição Post, a gente vai trabalhar no Body dela, ou seja, clique na aba Body
// Dentro da aba Body marque a opção raw. Isso siginifica que você está dizendo que o corpo dessa requisição é raw, que significa cru. Então iremos trabalhar com essa requisição sem ajuda nenhuma, a partir do momento em que marcamos o raw
// Pode ver que quando nós selecionamos a opção raw, no canto direito, apareceu um dropdown escrito Text. Clique nele e escolha a opção JSON, para substituir o tipo da nossa requisição pro tipo de arquivo que a gente deseja trabalhar
// O JSON é escrito sempre nesse formato: {}. Onde ele sempre começa como um objeto, ou como uma lista de objetos dentro de uma "array": [{}, {}, {}]
// No nosso caso a gente ta tentando passar um objeto pelo MapPost() do qual ele vai tentar converter para um User. E para isso a gente precisa olhar as propriedade de User e ver o que ele espera que um User tenha
// E abaixo (comentado), foi como ficou o nosso objeto JSON no Postman, que vai ser usado na requisição
//{
//  "id": 1,
//  "usarname": nosy
//}
// Note que a gente não colocou as propriedades em maiusculo como ta na nossa classe User. Não precisa, O Csharp vai fazer essa conversão pra gente de uma forma automatica
// Esse processo de converter um JSON para um objeto é chamado de SERIALIZAÇÃO. E o processo contrário é chamado de DESERIALIZAÇÃO
// Depois disso, basta você apertar em SEND, que vai dar tudo certin. Na janela de baixo vai aparecer o mesmo objeto, assim como também do lado o Status 200 dizendo que ta tudo ok
// E qual foi o processo que ocorreu aqui? Já que ele retornou o mesmo objeto pra gente no Postman
// Significa que ele passou esse objeto pro nosso código Csharp, chegou no código do MapPost(), conseguiu converter o Json que a gente enviou para um User, e depois ele conseguiu converter de volta o User para um Json
// Então, a gente pode usar o ASPNET/Csharp, (mesmo ele sendo uma linguagem tipada que usa informações diferentes) junto com o JavaScript porquê o ASPNET da esse suporte pra gente. 
// É simples e tranquilo converter um objeto para json e converter um json para objeto aqui no nosso lindo ASPNET


app.MapPost("/", (User user) =>
{
    return Results.Ok(user);
});

// Rodando a aplicação WEB
app.Run();


// = Funções anonimas = Função utilizada para explicar a função anonima
string Teste()
{
    return "teste de função anonima";
}

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
}