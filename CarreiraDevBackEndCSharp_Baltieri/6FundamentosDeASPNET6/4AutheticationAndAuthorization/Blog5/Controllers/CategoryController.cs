using Blog.Data;
using Blog.Extensions;
using Blog.Models;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{

    [ApiController]
    public class CategoryController : ControllerBase
    {

        [HttpGet("v1/categories")] 
        public async Task<IActionResult> GetAsync([FromServices] BlogDataContext context)
        {
            try
            {
                var categories = await context.Categories.ToListAsync();

                return Ok(new ResultViewModel<List<Category>>(categories));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Category>>("05XE01 - Falha interna no servidor!"));
            }
        }

        [HttpGet("v1/categories/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] BlogDataContext context, [FromRoute] int id)
        {
            try
            {
                var category = await context
                    .Categories
                    .FirstOrDefaultAsync(c => c.Id == id);

                if(category == null)
                    return NotFound(new ResultViewModel<Category>("Categoria não encontrada")); // Aqui era pra ter uma tag na string pra padronizar o erro, mas coloco dps

                return Ok(new ResultViewModel<Category>(category));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Category>("05XE02 - Falha interna no servidor!"));
            }
        }
        
        [HttpPost("v1/categories")]
        public async Task<IActionResult> PostAsync([FromServices] BlogDataContext context, [FromBody] EditorCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResultViewModel<Category>(ModelState.GetErrors()));
            }

            try
            {
                var category = new Category
                {
                    Id = 0,
                    Name = model.Name,
                    Slug = model.Slug.ToLower()
                };

                await context.Categories.AddAsync(category); 
                await context.SaveChangesAsync(); 

                return Created($"categories/{category.Id}", new ResultViewModel<Category>(category));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Category>("05XE03 - Não foi possivel incluir a categoria"));
            }
            catch 
            {
                return StatusCode(500, new ResultViewModel<Category>("05XE04 - Falha interna no servidor!"));
            }
        }

        [HttpPut("v1/categories/{id:int}")]
        public async Task<IActionResult> PutAsync([FromServices] BlogDataContext context, [FromRoute] int id, [FromBody] EditorCategoryViewModel model)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(new ResultViewModel<Category>(ModelState.GetErrors()));

                var category = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);
                
                if (category == null)
                    return NotFound(new ResultViewModel<Category>("Categoria não encontrada"));

                category.Name = model.Name;
                category.Slug = model.Slug;

                context.Categories.Update(category);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Category>(category));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Category>("05XE05 - Não foi possivel atualizar a categoria"));
            }
            catch 
            {
                return StatusCode(500, new ResultViewModel<Category>("05XE06 - Falha interna no servidor!"));
            }

        }

        [HttpDelete("v1/categories/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromServices] BlogDataContext context, [FromRoute] int id)
        {
            try
            {
                var model = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);
                if (model == null)
                    return NotFound(new ResultViewModel<Category>(ModelState.GetErrors()));

                context.Categories.Remove(model);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Category>("Categoria apagada com sucesso!"));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Category>("05XE07 - Não foi possivel deletar a categoria"));
            }
            catch 
            {
                return StatusCode(500, new ResultViewModel<Category>("05XE08 - Falha interna no servidor!"));
            }
        }
    }
}
