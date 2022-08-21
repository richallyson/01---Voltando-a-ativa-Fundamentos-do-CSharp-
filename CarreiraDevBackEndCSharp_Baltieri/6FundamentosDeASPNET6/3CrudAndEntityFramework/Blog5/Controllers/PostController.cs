using Blog.Data;
using Blog.Extensions;
using Blog.Models;
using Blog.ViewModels;
using Blog.ViewModels.PostViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    [ApiController]
    public class PostController : ControllerBase
    {
        [HttpGet("v1/posts")]
        public async Task<IActionResult> GetAsync([FromServices] BlogDataContext context)
        {
            try
            {
                var posts = await context.Posts.ToListAsync();
                return Ok(new ResultViewModel<List<Post>>(posts));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Post>>("Falha interna no servidor"));
            }
        }

        [HttpGet("v1/posts/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] BlogDataContext context, [FromRoute] int id)
        {
            try
            {
                var post = await context.Posts.FirstOrDefaultAsync(x => x.Id == id);

                if (post == null)
                    return NotFound(new ResultViewModel<Post>("Post não encontrado!"));

                return Ok(new ResultViewModel<Post>(post));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Post>("Falha interna no servidor"));
            }
        }

        [HttpPost("v1/posts")]
        public async Task<IActionResult> PostAsync([FromServices] BlogDataContext context,
            [FromBody] EditorPostViewModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Post>(ModelState.GetErrors()));

            try
            {
                var post = new Post
                {
                    Id = 0,
                    Title = model.Title,
                    Summary = model.Summary,
                    Body = model.Body,
                    Slug = model.Slug.ToLower(),
                    CreateDate = DateTime.UtcNow,
                    LastUpdateDate = DateTime.UtcNow,
                    Author = model.Author,
                    Category = model.Category,
                    Tags = model.Tags
                };

                await context.Posts.AddAsync(post);
                await context.SaveChangesAsync();

                return Created($"v1/posts/{post.Id}", new ResultViewModel<Post>(post));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Post>("Não foi possivel incluir o post"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Post>("Falha interna no servidor"));
            }
        }

        [HttpPut("v1/posts/{id:int}")]
        public async Task<IActionResult> PutAsync([FromServices] BlogDataContext context,
            [FromBody] EditorPostViewModel model, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Post>(ModelState.GetErrors()));

            try
            {
                var post = await context.Posts.FirstOrDefaultAsync(x => x.Id == id);

                if (post == null)
                    return NotFound(new ResultViewModel<Post>("Post não encontrado!"));

                post.Title = model.Title;
                post.Summary = model.Summary;
                post.Body = model.Body;
                post.Slug = model.Slug;
                post.LastUpdateDate = DateTime.UtcNow;
                post.Author = model.Author;
                post.Category = model.Category;
                post.Tags = model.Tags;

                context.Posts.Update(post);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Post>(post));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Post>("Não foi possivel incluir o usuário"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Post>("Falha interna no servidor"));
            }
        }

        [HttpDelete("v1/posts/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromServices] BlogDataContext context, [FromRoute] int id)
        {
            try
            {
                var post = await context.Posts.FirstOrDefaultAsync(x => x.Id == id);
            
                if (post == null)
                    return NotFound(new ResultViewModel<Post>("Post não encontrado"));

                context.Posts.Remove(post);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Post>(post));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Post>("Falha interna no servidor"));
            }
        }
    }
}
