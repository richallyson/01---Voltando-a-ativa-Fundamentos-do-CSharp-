using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blog.Extensions
{
    public static class ModelStateExtension
    {
        // Bem, aqui iremos fazer o nosso método de extensão do nosso ModelState. Mas o que é um método de extensão?
        // É um método que é extendido para outras classes (não sei se funciona com structs, records, etc. O balta não fala isso)
        // Por exemplo. Eu tenho uma classe base do asp.net, e desejo atribuir a ela um novo método. Seria muito estranho você ir no código principal dela e alterar. Isso poderia dar muito bucho pra você.
        // E é nesse cenário onde a gente tem os extensions methods. Para que a gente extenda uma função de fora dessa classe pra ela...
        // basta a gente chamar essa classe como parametro dentro da nossa função, e botar o this antes dela
        // Dessa forma o csharp vai extender esse método criado para a classe que a gente deseja
        // E bem, agora vamos para o corpo do método. Nosso objetivo aqui é pegar apenas as mensagens de erro que vem dentro do ModelStates.Values
        // Pois como a gente sabe, a gente deseja sempre retornar as nossas coisas dentro do padrão do ResultViewModel
        // Sendo assim, desejamos retornar um erro, ou uma lista de erros. Então, vamo começar!
        // Depois de ler tudo aqui, volta pra ação de post no category controller

        public static List<String> GetErrors(this ModelStateDictionary modelState)
        {
            // Primeiro a gente cria uma lista de strings que vai receber os erros que a gente deseja
            var errors = new List<String>();

            // Depois vamos percorrer os objetos que o ModelState.Values retorna quando acontece algum erro de validação
            foreach (var item in modelState.Values)
            {
                // Dentro desses objetos, a gente vai procurar apenas as mensagens de erro
                foreach (var error in item.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }

            // E depois, a gente retorna esses erros que pegamos, pra passar essa lista de string dentro do nosso ResultViewModel
            return errors;
            
            //return (from item in modelState.Values from error in item.Errors select error.ErrorMessage).ToList();
        }

        // Se você usa o ReSharper, quando você terminar de codar a sua função de extensão, ele vai sugerir uma melhoria no seu código
        // Dessa forma, se você aceitar, todx aquele código de cima, vai virar apenas essas duas linhas. Doideira né?
        // Então, use ReSharper, vai deixar tudo mais lindo

        //public static List<String> GetErrors(this ModelStateDictionary modelState)
        //    => return (from item in modelState.Values from error in item.Errors select error.ErrorMessage).ToList();
        //
    }
}
