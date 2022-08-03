using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers
{

    [ApiController]
    public class HomeController : ControllerBase
    {
        // Antes o nosso retorno ficava com a linha amarela embaixo, pois ele estava dando uma advertência de que esse retorno podia ser nulo
        // Pra evitar isso, agr a gente vai trabalhar com os ranges de código Http, como o 200, 201, 301, 404, etc. Vamos trabalhar com esse formato
        // Então ao invés de retornar um List de TodoModel, a gente vai usar um IActionResult
        // Esse IActionResult é um tipo especifico do ASP.NET que permite que a gente use return Ok, return Created, etc
        // Lembra no primeiro módulo quando a gente botou no retorno algo como Results.Ok(), e dentro do Ok() a gente passou o que iria ser retornado?
        // É a mesma coisa. Botando o IActionResults como o nosso tipo de retorno, a gente vai poder agora trabalhar com esses results, e padronizar os nosso retornos, para que caso aconteça algo, o próprio código Http trate isso pra gente
        // E isso vai padronizar toda a nossa API. 
        // Então, ao invés da gente retornar apenas o context.Todos.ToList(), a gente vai retornar as funções de código http, e dentro dessas funções o que a gente realmente deseja retornar
        // Dessa forma, como eu já disse, se algo der errado, o próprio código http vai cuidar disso pra gente
        // E como a gente só tem uma linha de código dentro do corpo da função, vamo usar o expression bodied pra ficar mais bunitin né
        [HttpGet("/")]
        public IActionResult Get([FromServices] AppDbContext context)
            => Ok(context.Todos.ToList()); // return Ok() significa que deu tudo certo

        // E agora vamo corrigir o resto botando IActionResult em todos e tratando o que deve ser tratado
        [HttpGet("/{id:int}")]
        public IActionResult GetById(int id, [FromServices] AppDbContext context)
        {
            var todo = context.Todos.FirstOrDefault(x => x.Id == id);

            if (todo == null)
                return NotFound(); // Novamente usando uma função do IActionResults, que dessa vez vai mostrar o Status no range 400, dizendo que não achou anda

            // E se tudo estiver certo, se o todo não cair no if e for null, a gente da um Ok()
            return Ok(todo);
        }

        [HttpPost("/")]
        public IActionResult Post([FromBody] TodoModel todo, [FromServices] AppDbContext context)
        {
            context.Todos.Add(todo);
            context.SaveChanges();
            // Aqui vai retornar o Status de que algo foi criado. Ele pede uma url antes, que é a url final desse objeto
            // E no caso a gente vai passar um endereço que é o id desse novo todo criado. Essa é uma url onde a gente pode visualizar o todo depois
            return Created($"/{todo.Id}", todo);

        }

        // Aqui muda quase nada, então não tem pq explicar. Pois tudo já foi ensinado acima
        [HttpPut("/{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromBody] TodoModel todo, [FromServices] AppDbContext context)
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);

            if (model == null)
                return NotFound();

            model.Title = todo.Title;
            model.Done = todo.Done;

            context.Todos.Update(model);
            context.SaveChanges();

            return Ok(model);
        }

        [HttpDelete("/{id:int}")]
        public IActionResult Delete([FromRoute] int id, [FromServices] AppDbContext context)
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);

            if (model == null)
                return NotFound();

            context.Todos.Remove(model);
            context.SaveChanges();

            return Ok(model); // A gente pode retornar o model ou uma string falando que o model foi deletado

        }

        // Agora abre o postman e vai lá bricar. Cria diversos objetos JSON, atualiza, deleta, lê, etc. Bora pro próximo módulo!
    }
}