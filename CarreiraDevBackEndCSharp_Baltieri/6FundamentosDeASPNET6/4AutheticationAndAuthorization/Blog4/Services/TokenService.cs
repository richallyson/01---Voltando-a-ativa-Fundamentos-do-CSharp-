using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Blog.Extensions;
using Blog.Models;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Services;

public class TokenService
{
    public string Generate(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler(); // Item usado pra gerar o token
        var key = Encoding.ASCII.GetBytes(Configuration.JwtKey); // Chave Jwt
        var claims = user.GetClaims();
        
        // = Gerando Token Claims para usuarios criados =
        // Bem dentro do nosso método Generate a gente ta recebendo um User mas não está fazendo nada com ele
        // A gente precisa criar os claims pra esse usuário que vai ser gerado no endpoint accounts do nosso AccountController.cs
        // Nossos claims precisam receber o nome do nosso usuário e a sua role pra autenticar esse usuário a usar a nossa aplicação
        // Porém, no Blog3 os nossos claims eram hardcoded, a gente digitava o nome de um user já no claim, assim como a sua role
        // O que a gente precisa fazer é criar algo que deixe isso gerando de forma automática
        // Para quando a gente for criar um user novo, ao invés de usar esses valores hardcoded, trazerem os valores desse novo usuário. Como seu nome/email e role
        // E a melhor forma da gente fazer isso, é criando um método de extensão pro user
        // Pra isso a gente vai pra nossa pasta Extensions e criar uma classe nova chamada de RoleClaimsExtension.cs
        // Agora vai lá ler tudo o que foi feito nessa classe
        // Com tudo terminado no RoleClaimsExt, agora a gente vai chamar a função da classe no nosso usuário dessa nossa função...
        // Pra trazer pra gente todos os claims que a gente necessita de forma automatizada
        // Isso foi feito nessa variavel claims, acima desse texto
        // Depois disso, basta passar essa lista de claims, dentro do ClaimsIdentity e pronto
        // Agora o nosso TokenService ta usando de fato o user que a gente recebe como atributo aqui
        // E vamo testar isso no nosso velho amigo Postman. Usa o endpoint v1/accounts/login
        // Nele você vai precisar da senha gerada quando criou um user e do email
        // Quando tentar logar dessa vez o token que vai ser gerado tem todas as informações do user que logou
        // Pra ver isso a gente usa o jwt.io
        // Lembrando que você tem que ir no banco e assemelhar uma role a esses novos usuários criados, pela UserRole
        // E pronto, agora a gente vai testar uma forma de autenticação e autorização diferente. Vai pro Blog5, pro arquivo Configuration.cs
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };  
        
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}