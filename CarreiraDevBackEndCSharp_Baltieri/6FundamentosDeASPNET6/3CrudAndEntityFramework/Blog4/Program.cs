using Blog.Data;

var builder = WebApplication.CreateBuilder(args);

// = Continuando a padroniza��o de retorno = 
// Se tu veio aqui primeiro, vai primeiro pra ResultViewModel.cs, e de l� segue o fluxo
// Agora que seguiu o fluxo, a gente j� pode falar sobre as mudan�as feitas aqui
// E como eu estava dizendo no CategoryController.cs, pra gente padronizar o retorno pra tela atrav�s do ResultViewModel
// A gente precisa suprimir a valida��o autom�tica do ModelState
// E para isso, basta a gente adicionar essas linhas dps de AddControllers(), que essa valida��o autom�tica vai ser desativada
// O .ConfigureApiBehaviorOptions, vai configurar o pra gente o comportamento da nossa API
// E como a gente quer que o comportamento de valida��o autom�tica seja desativado, basta usar uma express�o onde options vai desativar esse comportamento
// E a partir desse momento, toda vez que voc� trabalhar com algum Model, a gente � OBRIGADO a trabalhar com a verifica��o do ModelState atrav�s de um if ou qualquer outra t�cnica
// Agora sim, em casos onde o modelo n�o passou na valida��o, a gente vai poder ter um retorno padronizado usando o ResultViewModel

// Agora pode voltar de novo pro CategoryController

builder.Services.AddControllers().ConfigureApiBehaviorOptions
    (options => options.SuppressModelStateInvalidFilter = true );

builder.Services.AddDbContext<BlogDataContext>();

var app = builder.Build();

app.MapControllers();

app.Run();
