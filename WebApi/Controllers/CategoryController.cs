using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("categories")]
    public class CategoryController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<List<Category>>> CreateCategory(
            [FromBody] Category model,
            [FromServices]DataContext context 
            )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                context.Categories.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar a categoria" });
            }
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Category>>> ReadCategory(
            [FromServices] DataContext context
            )
        {
            var categories = await context.Categories.AsNoTracking().ToListAsync();
                return categories;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> ReadCategoryById(
            int id,
            [FromServices] DataContext context
            )
        {
            var category = await context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return Ok(category);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<List<Category>>> UpdateCategory(
            int id,
            [FromBody]Category model,
            [FromServices] DataContext context
            )
        {
            if(id != model.Id)
                return NotFound(new { message = "Categoria não encontrada" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Entry<Category>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Não foi possível atualizar a categoria" });
            }
        }

        [HttpDelete]
        [Route("id:int")]
        public async Task<ActionResult<List<Category>>> DeleteCategory(
            int id,
             [FromServices] DataContext context
            )
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
                if (category == null)
                    return NotFound(new { message = "Categoria não encontrada" });
            try
            {
                context.Categories.Remove(category);
                await context.SaveChangesAsync();
                return Ok(new { message = "Categoria removida com sucesso" });
            }
            catch(Exception)
            {
                return BadRequest(new { message = "Não foi possível remover a categoria" });
            }
        }
    }
}
