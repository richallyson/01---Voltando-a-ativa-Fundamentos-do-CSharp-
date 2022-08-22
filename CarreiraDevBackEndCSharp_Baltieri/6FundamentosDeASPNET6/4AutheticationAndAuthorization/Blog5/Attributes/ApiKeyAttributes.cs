using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Blog.Attributes;

// = ApiKey =
// E é aqui que a gente vai criar o nosso atributo
// Esse atributo vai verificar se existe a chave na requisição, interceptar essa requisição...
// E se tiver tudo ok, a gente vai permitir ou não a passagem do robô
// E bem, vamos começar!
// Esse decorador [AttributeUsage()] diz pra que tipo de coisa o nosso atributo é válido
// No caso, vai ser para as classes e pros métodos
// E bem, um attributo aqui no aspnet nada mais é uma classe que herda de Attribute e implementa a interface IAsyncActionFilter
// O IAsyncActionFilter é um filtro de ação, como o IActionResult, onde nele a gente definia o tipo de ação que seria retornada
// Só que nesse contexto, a gente vai filtrar as ações que o robô pode fazer
// E essa interface implementa o método OnActionExecutionAsync
// E esse método basicamente vai fazer algo enquanto a ação estiver executando, vai interceptar a requisição, e deixar ela passar ou não

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class ApiKeyAttributes : Attribute, IAsyncActionFilter 
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        // Agora iremos tratar alguns cenários, onde caso todos não sejam satisfeitos, tudo vai dar certo, e o robô vai poder trabalhar
        // Primeiro cenário: o usuário fez uma requisição e não mandou a chave pra gente
        
        // O context tem tanto a nossa requisição quanto a nossa reposta. A partir dele a gente vai interceptar a requisição pra verificar os dados passados na query string
        // E dentro disso, dar um resultado
        // Essa função basicamente vai pegar a o valor da query da requisção (query string é o endereço do nosso localhost)
        // Vai pegar o valor que vem a frente da interrogação e verificar se ele é inválido
        // Se esse valor for invalido, ele vai retornar o que está dentro do if, e não vai permitir a autenticação do robô
        // Se for válido, se ele conseguir pegar o valor, ele vai criar uma variavel chamada extractedApiKey e guardar esse valor dentro dela 
        // Ou seja, se o robô digitar localhost:5001?api_key=CHAVE, ele vai buscar justamente pela string api_key, que como eu disse, autentica o robô
        // Ps: primeira vez que o Balta mostra o out durante toda a carreira dotnet. Basicamente quando uma váriavel out é colocada como atribudo...
        // Ela pode ser usada em outros locais, sem que você precise criar ela de novo. Depois desse if você vai entender melhor

        if (!context.HttpContext.Request.Query.TryGetValue(Configuration.ApiKeyName, out var extractedApiKey))
        {
            context.Result = new ContentResult
            {
                StatusCode = 401,
                Content = "ApiKey não encontrada!"
            };

            return;
        }
        
        // Segundo cenário: uma ApiKey foi encontrada, com o formato certin que eu já mostrei acima
        // Essa função verifica se a ApiKey é a mesma ApiKey que a gente tem no configuration
        // Lembrando que para acontecer o robô tem que acessar o endereço localhost:5001?api_key=chave
        // Essa chave pode ser qualquer uma, tanto faz. A primeira parte ele passou, que foi passar o parametro api_key que autentica o robô na API
        // E bem, se essa ApiKey não for igual a nossa, a gente retorna um StatusCode 403, que é o Unauthorized

        if (!Configuration.ApiKey.Equals(extractedApiKey))
        {
            context.Result = new ContentResult
            {
                StatusCode = 403,
                Content = "Acesso não autorizado!"
            };

            return;
        }
        
        // E se tudo der certo, se o ApiKeyName e o ApiKey for o que se espera, a gente faz isso abaixo
        // Ou seja, ele ta dizendo: ta tudo correto, pode passar
        // Ai agora a gente tem um atributo que pode ser colocado tanto em classes como métodos
        // A gente pode colocar isso apenas em um método que da um get em posts, ou mesmo em um controller todo
        // Agora pra testar, vamo pro HomeController.cs
        
        await next();

    }
}