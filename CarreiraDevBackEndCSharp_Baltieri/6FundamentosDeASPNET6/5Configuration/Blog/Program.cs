using System.Text;
using Blog;
using Blog.Data;using Blog.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration.Ini;
using Microsoft.IdentityModel.Tokens;

// Antes de tudo, a gente vai arrumar a casa aqui. Vamos pegar esses trechos de configuração e mover para metodos
// Para ver como era antes, basta abrir o ultimo blog do modulo anterior

var builder = WebApplication.CreateBuilder(args);

ConfigureAuthentication(builder);
ConfigureMvc(builder);
ConfigureServices(builder);

var app = builder.Build();

LoadConfiguration(app);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();


// = Entendendo o ApiSettings =
// A gente tem duas formas de se pegar as informações do appsettings para fazer o parse para uma classe
// A primeira é usando o app app.Configuration.GetSection(), que vai obter uma sessão do appsettings
// A segunda é usando o app.Configuration.GetValue<>(), onde a gente passa um nó, por exemplo o JwtKeu
// Onde nisso ele vai tentar trazer pra gente esse JwtKey
// E bem, agora vamos carregar de vez o que a gente precisa, para os nós simples
// Depois iremos carregar o smtp que é um nó a parte, e composto
// A diferança que temos é a função .Bind depois do GetSection
// Nessa função, o aspnet vai automaticamente pegar o Json que explicitamos e converter para a classe que passamos dentro do bind
// No nosso caso, ele vai pegar o nó Smtp do appsettings, pegar todas informações do Json, e popular a nossa classe Smtp que está no Configuration.cs
// Ou seja, a gente cria uma instância de smpt, linka ela com o conteúdo do nó remetente a ela no appsettings
// E por fim, passa esse smtp criado pra nossa classe configuration com o Configuration.SmtpConfiguration = smtp
// E é assim que a gente usa um bind, pegando uma sessão completa. Ao invés de passar um por um como fizemos com as chaves
// Pegamos toda uma sessão de código json, e populamos uma classe existente

void LoadConfiguration(WebApplication app)
{
    Configuration.JwtKey = app.Configuration.GetValue<string>("JwtKey");
    Configuration.ApiKeyName = app.Configuration.GetValue<string>("ApiKeyName");
    Configuration.ApiKey = app.Configuration.GetValue<string>("ApiKey");

    var smtp = new Configuration.SmtpConfiguration();
    app.Configuration.GetSection("Smpt").Bind(smtp);
    Configuration.Smtp = smtp;
}

void ConfigureAuthentication(WebApplicationBuilder builder)
{
    var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);

    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters 
        {
            ValidateIssuerSigningKey = true, 
            IssuerSigningKey = new SymmetricSecurityKey(key), 
            ValidateIssuer = false, 
            ValidateAudience = false
        };
    });
}

void ConfigureMvc(WebApplicationBuilder builder)
{
    builder.Services
        .AddControllers()
        .ConfigureApiBehaviorOptions
            (options => options.SuppressModelStateInvalidFilter = true );
}

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddDbContext<BlogDataContext>();
    builder.Services.AddTransient<TokenService>(); 
}