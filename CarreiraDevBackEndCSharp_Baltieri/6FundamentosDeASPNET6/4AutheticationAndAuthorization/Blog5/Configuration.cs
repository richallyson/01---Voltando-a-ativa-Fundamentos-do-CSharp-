namespace Blog;

public static class Configuration
{
    public static string JwtKey { get; set; } = "b2xlIjoiQWRtaW4iLCJJc3N1ZXIiOiJJc3N1ZXIiLCJVc2VybmFtZSI6Ikp";
    
    // = ApiKey =
    // Agora iremos aprender outra forma de autenticação usada em outro contexto
    // Em um contexto onde a gente não trabalha apenas com um usuário final, com o frontend, mas sim tb com um robô, por exemplo...
    // A cada periodo de tempo, esse robô vasculha a nosso blog para ver se algo nela mudou, por exemplo, se um post novo foi criado
    // E se tiver alguma atualização a API realiza uma ação, como por exemplo, manda um email para os usuários falando que tem post novo
    // Basicamente esse robô seria uma console app que fica checando a nossa API de temmpos em tempos
    // Se a gente tivesse apenas o esquema de autenticação usando email e senha, usando JWT Bearer, o que esse robô precisaria fazer?
    // Primeiro, ele precisaria ter um usuário pra poder acessar a API. E precisaria ser um usuário diferente, pois o robô n atenderia as propriedades do nosso modelo User já existente
    // E segundo, que esse robô teria sempre um processo duplo para realizar suas ações
    // Porquê imagina que ele roda todx dia as 6 da manhã, e nosso token expira a cada 8 horas
    // Então, todx dia a seis da manhã, ele teria que iniciar um processo onde ele faria o login com user e senha
    // Gerar o token e mandar o token depois na requisição pra poder ler os posts, tags, categorias, etc
    // Então pra esses cenários existem um item mais fácil, e que obviamente a gente tem que ter muito mais cuidado com ele
    // Esse item é a autenticação por ApiKey, que é basicamente uma chave que a gente gera na nossa aplicação, e essa chave permite acesso aos métodos que você explicitar
    // Ela não precisa de role e nem nada, apenas da ApiKey definida e pronto. E claro que com isso a gente não tem acesso aos métodos que os Claims geram pra gente
    // Então, basicamente a gente vai criar uma chave aqui, e toda vez que uma requisição for feita usando essa chave (senha), o robô vai ter acesso a alguma informação
    // E bem, primeiro a gente criar o ApyKeyName, que é o nome do parametro que ele vai passar. Mas como assim?
    // Quando você for acessar o seu localhost:port?, você bota a frente o parametro do ApyKeyName=ApiKey
    // Fica mais ou menos assim localhost:port?api_key=curso_api_Ia75!@#$A88>-))asd5
    // Basicamente é como se fosse um endpoint, onde você adiciona o parametro da ApiKeyName a frente do endpoint e a ApiKey em si
    // Então, sempre que o robô passar um parametro de api_key, a gente vai buscar por esse parametro na requisição, e se esse parametro estiver na requisição, a gente já entende que ele ta autenticado
    // Porém, se você não passar a ApiKey como valor do parametro ApiKeyName, você só está autenticado, mas não autorizado a realizar alguma ação
    // E por fim tempos a ApiKey, que é a chave que vai ser utilizada pra autorizar o robô a realizar alguma determinada ação dentro da nossa API
    // E por isso eu disse que tinha que ter cuidado, pois se alguém tiver acesso a esse chave, ela tem acesso a nossa API
    // Mas como a gente faz essa verificação? Pra isso tu vai agora pro HomeController.cs 
    
    public static string ApiKeyName = "api_key";
    public static string ApiKey = "1234"; // Claro que você nunca deve utilizar uma senha assim kk
}