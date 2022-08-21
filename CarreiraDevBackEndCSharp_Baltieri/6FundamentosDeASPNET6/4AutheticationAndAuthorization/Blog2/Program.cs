using System.Text;
using Blog;
using Blog.Data;using Blog.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// = Configurando autenticação e autorização =
// A gente usou o app.MapControllers, pra dizer que o nosso app devia mapear os nosso controladores para serem usados
// Da mesma forma iremos fazer com a autenticação e a autorização. Vamos dizer pro app usar isso a partir de agora
// E pra isso a gente usa o app.UseAuthentication() e o app.UseAuthorization()
// Lembrando que tem que ser especificamente nessa ordem, pois a gente primeiro precisa autenticar um usuário...
// pra depois autorizar ele a fazer algo na aplicação
// Autenticação = quem você é / Autorização = o que você pode fazer.
// E bem, a gente disse que tem autenticação e tem autorização
// Mas eai, qual o tipo de autenticação que eu vou usar? É preciso definir o esquema de autenticação que vamos usar
// Já sabemos que vamos usar token para autenticar, mas como eu vou desencriptar esse token? Qual chave eu vou usar pra desencriptar ele?
// Lembrando que o que a gente fez no TokenService, foi só a criação do Token, e no Configuration, só criamos a chave
// Em nenhum momento nós dissemos para a aplicação toda como fariamos a desencriptação dele
// Mas eai, qual o tipo de autorização que eu vou usar? Sim, você precisa definir o tipo do esquema de autorização
// E bem, essas espeficações são feitas dentro do builder
// Mas primeiro a gente precisa trazer a nossa chave, dentro daquele mesmo formato que trouxemos no TokenService
// Depois que a gente tem a chave, a gente vai usar o builder.Services.AddAuthetication(), para adicionar autenticação a nossa aplicação
// Onde dentro desse AddAuthetication() a gente vai passar qual o esquema utilizado para fazer a nossa autenticação
// A gente configura esses esquemas com dois itens, o DefaultAuthenticationScheme e o DefaultChallengeScheme
// E como atributo delas a gente coloca o JwtBearerDefaults.AutheticationScheme, que é justamente o esquema de se trabalhar com o JwtBearer
// O Balta não explica cada uma dessas opções de autenticação, então procura melhor, pra se aprofundar mais
// Porém, só isso diz o esquema de autenticação, a gente não ta dizendo como a gente vai desencriptar o nosso token
// Para isso a gente usa o .AddJwtBearer({}), onde dentro dele a gente vai por as configurações de desencriptação
// Dentro das opções a gente passa os parametros que vão validar o Token
// Sendo o primeiro o que realmente valida a assinatura
// O segundo, a forma como ele valida a assinatura, que é usando a nossa chave
// E ai vem uma recaptulação, que é o que fizemos no jwt.io, onde a chave midificou o payload do nosso payload...
// apois essa modificação o token foi alterado, se tornando inutilizavel, mas quando locamos a nossa chave na verificação de assunatura...
// Ele se tornou um token válido pra nossa aplicação
// Os outros dois parametros não entram muito na discussão, pois a gente ta trabalhando com a autenticação de apenas uma API
// Se fosse um cenário com multiplas APIs, tanto o DefaultChallenge do Authentication, quanto os dois ultimos parametros do TokenValidantion, seriam mais válidos pra gente aquii
// Ou seja, eles seriam diferentes se fosse em caso de se trabalhar com um parque de APIs
// E essa é toda a configuração que a gente precisa para ter autenticação e autorização na nossa API
// Agora, vai pro AccountControleller que a gente vai testar a autenticação e autorização

var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters // Parametros do token
    {
        ValidateIssuerSigningKey = true, // Validar a chave de assinatura
        IssuerSigningKey = new SymmetricSecurityKey(key), // Como valida a chave de assinatura? Através da nossa chave simétrica
        ValidateIssuer = false, //
        ValidateAudience = false
    };
});

builder.Services
    .AddControllers()
    .ConfigureApiBehaviorOptions
    (options => options.SuppressModelStateInvalidFilter = true );

builder.Services.AddDbContext<BlogDataContext>(); 

builder.Services.AddTransient<TokenService>(); // Sempre criar um novo

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
