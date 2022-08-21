using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Blog.Models;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Services;

public class TokenService
{
    public string Generate(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler(); // Item usado pra gerar o token
        var key = Encoding.ASCII.GetBytes(Configuration.JwtKey); // Chave Jwt
       
        // = JWT Claims =
        // Antes de tudo, veja esse video: https://www.youtube.com/watch?v=3i0RcKrVyTo&ab_channel=FrankLiu
        // Ele explica bem melhor sobre Principal, ClaimsIdentity e Claims, do quê o curso do Balta
        // Vamos adicionar mais um item ao tokenDescriptor, o Subject, que é Assunto em inglês
        // A gente pode passar um objeto dentro do subject. E o Subject espera um ClaimsIdentity
        // Claim significa afirmação, reivindicação, ou seja, iremos afirmar algo sobre um certo assunto
        // No nosso caso, iremos fazer afirmações sobre o nosso token ou sobre o usuário que a gente ta gerando
        // Então, a gente pode criar um claim baseado num role, baseado num slug, nome, etc
        // A gente pode fazer um claim até sobre um true ou false, pra afirmar se ele tem acesso ou não a uma parte do sistema
        // Ou seja, quando a gente faz um ClaimIdentity, a gente ta reivindicando uma indentidade sobre uma entidade
        // Dessa forma, a pra autenticação e autorização, a gente vai dizer que a identidade daquele usuário pode fazer algo em certo contexto
        // Um usuário pode ter diversas identidades, assim como na vida real, você pode ter um rg, carteira de motorista, etc
        // Cada uma dessas identidades vai lhe autorizar a fazer algo. Primeiro autenticam que você tem uma identidade de certa coisa
        // E depois te autorização a fazer certa coisa baseado nessa autenticação. Por exemplo, um usuário ser autenticado como admin
        // E por ele ser admin, é autorizado a mexer em toda a aplicação, sem restrições
        // E uma identidade pode contar diversos Claims
        // Dentro do ClaimsIdentity() a gente precisa passar declaraçoes sobre a entidade, no caso o user
        // Essas declarações são feitas usando o Claim(). Geralmente o ClaimsIdentity espera um conjunto de declarações
        // Dessa forma iremos criar uma array de Claim
        // As declarações contidas em uma ClaimsIdentity descrevem o que a entidade corresponde ou representa e podem ser usadas para tomar decisões de autorização e autenticação.
        // E dentro dessa array a gente cria um novo Claim. Percebe que a gente botou apenas new e abriu os parenteses?
        // Psé, o dotnet já entende que esse new abre paranteses, já é um novo Claim, pois a gente já disse o tipo da array
        // O Claim espera dois valores, que são strings, uma chave e um valor
        // Existem alguns CLaims especificos que o aspnet trata, ou seja, se usarmos eles, o aspnet vai ajudar mais a gente
        // Esses claims podem ser usados para saber se o usuário já está logado, se ele é de role x, etc
        // Pra ver melhor, vai no CategoryController, que lá tem uns exemplos disso, que estão comentados
        // Depois de ter lido tudo do CategoryController.cs, a gente vai continuar o aprendizado
        // Bem, pra gente tem acesso a aquelas features que falamos no CategoryController, a gente tem que criar Claims especificos
        // Ou seja, para ter acesso ao User.Identity.IsAuthenticated, ao User.Identity.Name e ao User.IsInRole(), iremos criar esses claims
        // Para isso a gente tem criar pelo menos dois claims que são essenciais
        // Que é o ClaimType.Name, e o ClaimType.Role. Lembrando que a gente tem acesso as propriedades de user, pq passamos ele como parametro
        // Essas são as chaves. Nos valores você passa algum nome qualquer dentro do definido pelo mapeamento
        // E na role, você coloca o nome da role, no nosso caso, a role admin, que foi criada no nosso banco
        // Os outros roles você cria no valor que quiser e precisar, como o caso do author e do user
        // Com essas duas ClaimTypes criadas, a gente agora tem acesso as features faladas
        // Agora, faz uma requisição pro login, pega o Token, e verifica como ficou no jwt.io
        // E nesse teste sem querer eu descobri que você pode botar diversos ClaimTypes.Name
        // Dessa forma, todos os nomes dentro desse claimstype, vão pode usar o User.Identity.Name
        // E bem, a gente tem o nosso token sendo gerado, com seus claims bonitinhos, mas falto algo
        // Agora vamo pro Program.cs pois a gente agora de fato vai configurar a nossa aplicação pra de fato usar autenticação e autorização

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new (ClaimTypes.Name, "guts"), //User.Identity.Name
                new (ClaimTypes.Role, "admin") //User.IsInRole("")
            }),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };  
        
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}