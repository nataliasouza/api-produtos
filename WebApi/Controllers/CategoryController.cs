using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("categories")]
    public class CategoryController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<List<Category>>> CreateCategory([FromBody] Category model)
        {
            return Ok(model);
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Category>>> ReadCategory()
        {
            return new List<Category>();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> ReadCategoryById(int id)
        {
            return new Category();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<List<Category>>> UpdateCategory(int id,[FromBody]Category model)
        {
            if(model.Id == id)
                return Ok(model);

            return NotFound();
        }

        [HttpDelete]
        [Route("id:int")]
        public async Task<ActionResult<List<Category>>> DeleteCategory()
        {
            return Ok();
        }
    }
}
