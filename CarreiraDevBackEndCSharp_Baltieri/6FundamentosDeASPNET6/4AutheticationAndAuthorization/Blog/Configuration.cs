namespace Blog;

//= Token e JWT =
// Por enquanto a nossa calsse vai ser assim, static, pra ela não precisar ser instanciada
// Mas depois veremos como ler ela direto do appsetings.json, ou seja, vai deixar de ser estatica no futuro
// Primeiro a gente vai criar uma propriedade estatica do tipo stringa chamada de JwtKey
// E o que é Jwt? É um formato de Token. Jwt = Json Web Token
// Como a gente sabe, vamos criar um hash, uma cadeia de caracteres, e mandar pra tela
// Esse hash também é conhecido como Token. E o Token pode ser em n formatos
// No nosso caso vamos usar o formato JWT, um dos formatos mais comuns que temos hoje em dia
// Ou seja, quando desencriptarmos o nosso Token, ele vai vir no formato JSON
// Bem, agora vamos inicializar ela direto da propriedade, passando uma chave bem robusta, uma string
// Essa chave eu gerei aqui nesse site: https://www.guidgenerator.com/online-guid-generator.aspx
// É um guid de Base64 no formato Hyphens
// Lembrando que não se deve colocar caracteres especiais, pra evitar eventuais erros
// Agr gente tem uma classe que não precisa instanciar, e que já vem com a nossa chave encriptada pronta pra usar
// Essa é uma chave que vai ta no nosso servidor e apenas no nosso servidor
// E quem tiver essa chave vai conseguir desencriptar o nosso token e editar ele. Então ela tem que ta beeem segura
// Eu não criei uma guid com base 64, só gerei alguma aleatoria mesmo em algum gerador de jwt kkkkk
// Agora vamos gerar um token, baseado no nosso modelo de usuário. E pra fazer isso a gente vai criar um arquivo separado. 
// Agr tu vai pro arquivo TokenService.cs que ta dentro da pasta Services
// Recaptulando. Jwt é um formato de chave, que serve para desencriptar o nosso Token
// A gente usa essa chave para pegar esse Token, desencriptar ele, e ver os dados que tem dentro dele

public static class Configuration
{
    public static string JwtKey { get; set; } = "b2xlIjoiQWRtaW4iLCJJc3N1ZXIiOiJJc3N1ZXIiLCJVc2VybmFtZSI6Ikp";
}