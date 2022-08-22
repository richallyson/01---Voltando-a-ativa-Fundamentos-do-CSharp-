using System.Security.Claims;
using Blog.Models;

namespace Blog.Extensions;

public static class RoleClaimsExtension
{
    // = Continuação - gerando Token Claims para usuarios criados =
    // Lembrando que toda classe de extensão deve ser static
    // E bem, a gente vai pegar os roles e transformar eles em uma lista de Claims
    // A gente basicamente vai fazer um parse pra converter os objetos que são do tipo role no tipo claim
    // E depois a gnt vai levar essa lista pro nosso generate, e passar esses claims subject do nosso tokenDescriptor
    // Quando a gente chamar a nossa função, ele vai pegar os roles do usuário e transformar em claims
    // Lembrando que pra ter acesso as features do aspnet relacionadas a autenticação, a gente precisa utilizar certos padrões
    // No caso, a gente precisa definir os ClaimTypes
    
    public static IEnumerable<Claim> GetClaims(this User user)
    {
        // O primeiro Claim que a gente precisa é o ClaimTypes.Name, só que no nosso caso, iremos usar o email
        // Não tem problema usar o email, o ClaimTypes trabalha tanto com nome quanto com email
        // E como eu havia dito, a gente vai criar uma lista de Claims, e passar os claims necessários dentro dessa lista
        // Você pode passar qualquer propriedade dentro do valor do ClaimTypes, contanto que transforme ele em string
        // E lembrando que o ClaimTypes.Name depois vira o User.Identity.Name
        // E bem, por segundo a gente adiciona os roles do usuário ao result
        // A função AddRange vai adicionar uma lista a nossa lista de Claims
        // Lembrando que as Roles são uma classe separada dos Users. Ela apenas é chamada no User
        // O que a gente vai fazer é basicamente adicionar uma lista a nossa lista de claims
        // Depois a gente vai pegar todos os roles que estão no usuário usando o Select, e vamos retornar deles um Claim
        // Mas lembra que a gente falou que precisaria fazer um parse de roles pra claim? Psé, o select faz isso pra gente
        // O Select transforma um objeto em outro. No nosso caso, vamos transformar as roles do usuário e claims
        // Dentro do select, a gente seleciona o role, e diz qual o tipo de retorno que a gente vai ter
        // No caso, um claim, com os eu claimTypes esperado, e dentro do Claim, a gente passa a chave (ClaimTypes.Role) e a chave, que vai ser o slug da role
        // E o valor é o que a gente vai passar no atributo Authorize, que faz a autenticação do usuário pra gente dentro de um certo contexto
        // COmo no exemplo de uso do Authorize, que permitia o usuário acessar apenas certos métodos baseado na sua role
        // E por fim a gente retorna a nossa lista de Claims. E agora a gente pode usar essa lista de claims no nosso Token Generator
        // E é pra lá que tu vai, voltar pro TokenService.cs
        
        var result = new List<Claim>
        {
            new (ClaimTypes.Name, user.Email)
        };
        result.AddRange(user.Roles.Select(role => new Claim(
                ClaimTypes.Role, role.Slug)));
        
        return result;
    }
}