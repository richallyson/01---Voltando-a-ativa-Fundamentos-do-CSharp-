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
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            // = Testando a autenticação e autorização =
            // Bem como pode perceber, a gente ta atribuindo roles a um user especifico
            // A gente ainda não fez o controle do usuário, pegando o nome que ele passaria no JSON
            // Porém vamos fazer isso mais a frente
            // E bem, a gente ta colocando a role do guts como admin, porém a gente pode acumular roles para um user
            // E foi justamente isso que a gente fez, deu mais uma role para o guts pra testar melhor a autenticação e autorização
            // Agora o guts tem a role user e a role admin, dessa forma ele vai conseguir acessar os métodos referentes a essas roles
            // Porém, não vai conseguir acessar o método referente a role de author
            // Claro que o admin tem poder máximo sobre a aplicação, mas a gente não vai tratar isso agr
            // Agora volta pro AccountController.cs
            
            Subject = new ClaimsIdentity(new Claim[]
            {
                new (ClaimTypes.Name, "guts"), //User.Identity.Name
                new (ClaimTypes.Role, "user"), //User.IsInRole("")
                new (ClaimTypes.Role, "admin")
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