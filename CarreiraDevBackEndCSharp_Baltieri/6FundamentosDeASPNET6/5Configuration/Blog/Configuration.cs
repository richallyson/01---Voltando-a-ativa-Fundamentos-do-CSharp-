namespace Blog;

public static class Configuration
{
    // = Entendendo o AppSettings =
    // Bom, primeiro ponto a gente se atentar é a essas informações fragéis que estão chapadas aqui
    // O certo seria que essas informações variassem, e não fosse estáticas
    // A gente teria uma chave que seria válida para o servidor de desenvolvimento
    // E outra chave que seria válida apenas para o servidor de produção
    // E a gente não pode deixar essa informação chapada aqui, pois se não os desenvolvedores vão ter acesso a elas
    // E isso pode acabar vazando e dando uma completa desgraça pra sua aplicação
    // E o mesmo vale pra quando a gente precisa armazenar chaves de outros serviços, elas n podem estar chapadas
    // Como a gente vai fazer aqui por exemplo, no caso de envio de email
    // A gente vai armazenar na nossa aplicação uma chave, que se o dev tiver acesso, ele consegue mandar email em nome da empresa
    // Então n é algo viavel deixar isso visivel aqui, normalmente a gente tem chaves de teste (que é o caso dessa abaixo)
    // Essas chaves de teste só devem funcionar no modo de desenvolvimento
    // E bem, pra evitar que essas chaves fiquem chapadas aqui, a gente tem dois arquivos que auxiliam a gente nisso
    // O appsettings.json e o appsettingsDevelopment.json
    // O appsettingsDevelopment.json só funciona no modo desenvolvimento, só quando a gente roda com o flag developmente, que ele vai funcionar
    // E o appsettings.json serve para quando a gente não ta rodando com nenhum flag. Acho que não precisa explicar o que é flag né? O nome já diz tudo
    // A gente pode deixar informações dentro desses arquivos, pode deixar as nossas configurações nesses arquivos
    // E na hora de publicar, o Balta vai mostrar pra gente como coloca essas configurações direto no servidor, pra que ngm tenha acesso
    // O appsettings.json vai sempre junto com a aplicação, então se você colocar qualquer informação sensivel dentro dele...
    // Qualquer usuário que tenha acesso ao arquivo, vai poder ver essa informação. Principalmente em casos de projeto opensource, que geral tem acesso
    // E mesmo que você pense em não mandar o appsettings pra evitar isso, não é recomendado
    // Pois quem pegar o seu projeto não vai saber as coisas que são necessárias instalar para usar ele
    // E a forma que a gente tem de fazer essas configurações, sem enviar os dados sensivéis, é fazer tudo a nv de desenvolviment
    // Sempre usar o appsettinsDevelopment.json, pois ele não representa produção, mas sim desenvolvimento
    // E feito isso, com as configs nele, a gente vai colocar as chaves de produção direto no servidor, no azure
    // Pois tecnicamente ngm tem acesso a elas, só a infraestrutura do azure
    // E também existe o AspNetUserSecrets, que carregam as configurações em tempo de execução com as chaves que estão na máquina, mas não veremos agr
    // E bem, a gente vai popular o appsettings e com ele populado, a gente vai popular essa nossa classe de configuração
    // Mas antes de ir pra appsettings de fato, primeiro iremos criar as configurações que a gente precisa para realizar um envio de email
    // Tudo o que a gente tem nessa classe de configuração, a gente vai ter no nosso appsettings
    // E pra que isso funcione, os nomes tanto das configurações aqui quanto no appsettings tem que ser os mesmos
    // E isso é importante pelo fato de que na hora que a gente vai puxar esses dados pro appsettings, o processo fica mais fácil
    // Podemos puxar item por item, ou tudo de uma vez, se os nomes estiverem iguais, ler toda a configuração de uma vez pra dentro de uma classe
    // Aparentemente a gente lê as configs do appsettings, essas configs vão estar ligadas a uma classe que contém esses dados
    // E isso também serve para os nós. O que são nós? No appsettings são como se fossem objetos jsons próprios para aquilo
    // No nosso caso, o SmtpConfiguration é um nó, que vai ser ligado a essa classe, que possui as suas proprias propriedades
    // Ou seja, na hora de escrever ela no appsettings, a gente vai criar um nó, um objeto json, especifico pro smtp
    // E claro, com os mesmos nomes que estão na classe
    // E pra visualizar isso melhor, vai agora no appsettings.json e depois volta aqui
    // Literalmente igual a como ta aqui, e agr fica mais fácil também de visualizar o que é um nó
    // Então, quando a gente fizer um parse daquele json criado no appsettings, para uma classe, ele já vem diretamente pra essa classe aqui
    // Já pode ser carregado dirtamente dessa classe aqui
    // E pra gente fazer a captura dessa informação, pra gente ler alguma coisa da configuração, a gente vai agora pro Program.cs

    public static string JwtKey { get; set; } = "b2xlIjoiQWRtaW4iLCJJc3N1ZXIiOiJJc3N1ZXIiLCJVc2VybmFtZSI6Ikp";
    public static string ApiKeyName = "api_key";
    public static string ApiKey = "1234";
    public static SmtpConfiguration Smtp { get; set; } = new();
    
    // E pra gente fazer um envio de email, a gente precisa das configurações abaixo
    // A primeira é a configuração do host que a gente vai enviar
    // A segunda é a porta do servidor. A gente informa ao host a porta do servidor
    // O usuário e a senha
    // Ou seja, o host vai ser o serviço do email, por exemplo: gmail.com
    // Então o host, gmail.com, a porta 25 (geralmente é essa), usarname vai ser o seunome@gmail.com, e a senha a sua senha
    // No caso o gmail não permite a gente fazer envio do smtp, foi só mais pra exemplificar 
    // Nos iremos usar um serviço chamado de SendGrid para fazer a nossa configuração
    // Um ponto interessante é que a gente ta criando uma classe dentro de outra classe, coisa que é plenamente possivel no csharp
    // E essa classe não precisa ser static
    // Porém, não é legal ficar fazendo isso no dia a dia, mas pra classe de configuração, pode valer a pena
    // Depois de criada a classe da configuração Smpt a gente expõe ela acima como uma propriedade da classe Configuration
    
    public class SmtpConfiguration
    {
        public string Host { get; set; }
        public int Post { get; set; } = 25;
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}