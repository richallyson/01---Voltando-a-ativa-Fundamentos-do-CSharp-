using Blog.Data;

var builder = WebApplication.CreateBuilder(args);

// = Continuando a padronização de retorno = 
// Se tu veio aqui primeiro, vai primeiro pra ResultViewModel.cs, e de lá segue o fluxo
// Agora que seguiu o fluxo, a gente já pode falar sobre as mudanças feitas aqui
// E como eu estava dizendo no CategoryController.cs, pra gente padronizar o retorno pra tela através do ResultViewModel
// A gente precisa suprimir a validação automática do ModelState
// E para isso, basta a gente adicionar essas linhas dps de AddControllers(), que essa validação automática vai ser desativada
// O .ConfigureApiBehaviorOptions, vai configurar o pra gente o comportamento da nossa API
// E como a gente quer que o comportamento de validação automática seja desativado, basta usar uma expressão onde options vai desativar esse comportamento
// E a partir desse momento, toda vez que você trabalhar com algum Model, a gente é OBRIGADO a trabalhar com a verificação do ModelState através de um if ou qualquer outra técnica
// Agora sim, em casos onde o modelo não passou na validação, a gente vai poder ter um retorno padronizado usando o ResultViewModel

// Agora pode voltar de novo pro CategoryController

builder.Services.AddControllers().ConfigureApiBehaviorOptions
    (options => options.SuppressModelStateInvalidFilter = true );

builder.Services.AddDbContext<BlogDataContext>();

var app = builder.Build();

app.MapControllers();

app.Run();
