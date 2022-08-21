using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Blog.Models;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Services;

// = Token Service = Classe feita para gerar o nosso token
// Services são serviços que suportam os controladores, as extensões, os dados, etc
// Tudo o que tem de extra, que não é dado, n é viewmodel, não é controller, ele vai pra dentro do serviço
// O token vai ser no formato string, vai retornar uma string pra gente
// A gente vai criar um método chamado de Generate, onde a gente passa como parametro um User
// Mas pq user? Pois a gente tem os roles dentro dele, que são as funções que o usuário pode exercer 
// A gente vai verificar a role do user, e dado isso, a gente vai gerar um Token pra ele
// E como que a gente gera esse Token aqui? A gente vai precisar de dois pacotes pra isso
// Primeiro o dotnet add package Microsoft.AspNetCore.Authentication
// E segundo o dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer

public class TokenService
{
    // A primeira coisa que a gente vai fazer é criar uma instância de um item chamado de TokenHandler
    // Handle em inglês significa manipular, e Handler é aquele que manipula. Então, manipulador de Token
    // A gente vai usar esse manipulador de Token pra gerar o nosso Token pra gente
    // Esse manipulador vai ser do tipo JwtSecurityTokenHandler()
    public string Generate(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler(); // Item usado pra gerar o token
        
        // E pra gerar o Token, a gente vai precisar da nossa chave que ta no Configuration.cs
        // Porém, a gente não pode passar a nossa chave como string pro nosso manipulador
        // O TokenHandler espera um array de bytes, espera essa chave convertida em bytes
        // E pra fazer isso a gente vai transformar nossa chave no que o manipulador espera, usando as funções abaixo
        // Dessa forma a gente transforma a nossa string em um array de bytes já no padrão ASCII
        
        var key = Encoding.ASCII.GetBytes(Configuration.JwtKey); // Chave Jwt
        
        // E por final, a gente precisa das configurações do Token, que a gente chama de TokenDescriptor
        // Esse item aqui, de fato, vai conter todas as informações do Token
        // Agora vamos configurar o nosso tokenDescriptor
        // A gente tem que passar alguns valores que o tokenDescriptor pede. 
        // Esses valores definem a data de expiração do Token. O Token não pode viver para sempre
        // Se alguém roubar o Token, vai poder fazer malicias com a aplicação
        // Então o correto é deixar a sua expiração curta. Entre 2 a 8 horas
        // No nosso caso a gente definiu que o token expira em 8 horas. Depois disso o usuário tem que logar de novo
        // E ao logar de novo, vai ser gerado um novo Token para esse usuário, e assim sucessivamente
        // O outro valor é o SigningCredentials, que define como o Token vai ser gerado e como ele vai ser lido posteriormente
        // A gente tem um médoto no dotnet chamado também de SigningCredentials()
        // Esse médoto vai pedir a nossa chave, e também vai definir como vamos gerar o Token, encriptar ele...
        // e posteriormente a forma como ele vai desnecriptar o Token
        // E tanto pra encriptar quando pra desencriptar, a gente usa a nossa chave criada no Configurations.cs
        // A gente poderia toda vez passar o array de bytes direto nessa função. Mas pra evitar erros, fica melhor colocar ele em um lugar comun
        // Quando a gente cria o SigningCredentials, ele espera dois itens
        // O primeiro item é a nossa chave. No nosso caso iremos usar uma chave simetrica
        // O Balta não se aprofunda nesses tipos de chave nesse contexto, então se quiser conhecer mais sobre: Google
        // O segundo item se refere ao tipo de algoritmo que ele vai utilizar pra encriptar os itens
        // Novamente ele fala que tem diversos tipos de algoritmos de encriptação, mas não se aprofunda
        // Cada um desses algoritmos é baseado no que você precisa.
        // No nosso caso iremos usar o SecurityAlgorithms.HmacSha256Signature
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            
        };  
        
        // E agora vamos criar o Token de fato usando as funções abaixo
        var token = tokenHandler.CreateToken(tokenDescriptor);
        
        // Só que esse token criado é to tipo SecurityToken, e a nossa função espera uma string como retorno
        // Então no nosso retorno, vamos usar as funções do manipulador pra transformar ele numa string
        // Esse método faz com que ele escreva uma string, onde o próprio método retorna uma string
        // Então o WriteToken já gera uma string baseada no token que a gente passou
        
        return tokenHandler.WriteToken(token);
        
        // Agora vai pro arquivo AccountController.cs
    }
}