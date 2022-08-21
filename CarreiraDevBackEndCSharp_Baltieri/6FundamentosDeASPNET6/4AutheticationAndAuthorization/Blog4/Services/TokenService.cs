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