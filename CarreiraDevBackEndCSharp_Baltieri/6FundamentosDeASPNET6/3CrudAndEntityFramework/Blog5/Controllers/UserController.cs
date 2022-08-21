using Blog.Data;
using Blog.Extensions;
using Blog.Models;
using Blog.ViewModels;
using Blog.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("v1/users")]
        public async Task<IActionResult> GetAsync([FromServices] BlogDataContext context)
        {
            try
            {
                var users = await context.Users.ToListAsync();
                return Ok(new ResultViewModel<List<User>>(users));
            }
            catch
            {
                return StatusCode(500,
                    new ResultViewModel<List<User>>("Falha interna no servidor"));
            }
        }

        [HttpGet("v1/users/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] BlogDataContext context, [FromRoute] int id)
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);

                if (user == null)
                    return NotFound(new ResultViewModel<User>("O usuário não foi encontrado"));

                return Ok(new ResultViewModel<User>(user));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<User>("Falha interna no servidor"));

            }
        }

        [HttpPost("v1/users")]
        public async Task<IActionResult> PostAsync([FromServices] BlogDataContext context, EditorUserViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<User>(ModelState.GetErrors()));

            try
            {
                var user = new User
                {
                    Id = 0,
                    Name = model.Name,
                    Email = model.Email,
                    PasswordHash = model.Name.ToLower(),
                    Slug = model.Name.ToLower(),
                };

                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                return Created($"v1/users{user.Id}", new ResultViewModel<User>(user));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<User>("Não foi possivel incluir o usuário"));
            }
            catch 
            {
                return StatusCode(500, new ResultViewModel<User>("Falha interna no servidor!"));
            }

        }

        [HttpPut("v1/users/{id:int}")]
        public async Task<IActionResult> PutAsync([FromServices] BlogDataContext context, EditorUserViewModel model, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<User>(ModelState.GetErrors()));

            try
            {
                var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);

                if (user == null)
                    return NotFound(new ResultViewModel<User>("Usuário não encontrado"));

                user.Name = model.Name;
                user.Email = model.Email;
                user.PasswordHash = model.Name.ToLower();
                user.Slug = model.Name.ToLower();

                context.Users.Update(user);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<User>(user));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<User>("Não foi possivel atualizar o usuário"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<User>("Falha interna no servidor"));
            }
        }

        [HttpDelete("v1/users/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromServices] BlogDataContext context, [FromRoute] int id)
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);

                if (user == null)
                    return NotFound(new ResultViewModel<User>("Usuário não encontrado"));

                context.Users.Remove(user);
                context.SaveChangesAsync();

                return Ok(new ResultViewModel<User>("Usuário deletado com sucesso"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<User>("Falha interna no servidor!"));
            }
        }
    }
}
