using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("categories")]
    public class CategoryController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public Category CreateCategory([FromBody] Category model)
        {
            return model;
        }

        [HttpGet]
        [Route("")]
        public string ReadCategory()
        {
            return "GET";
        }

        [HttpGet]
        [Route("{id:int}")]
        public string ReadCategoryById(int id)
        {
            return "GET" + id.ToString();
        }

        [HttpPut]
        [Route("{id:int}")]
        public Category UpdateCategory(int id,[FromBody]Category model)
        {
            if(model.Id == id)
                return model;
            return null;
        }

        [HttpDelete]
        [Route("id:int")]
        public string DeleteCategory()
        {
            return "DELETE";
        }
    }
}
