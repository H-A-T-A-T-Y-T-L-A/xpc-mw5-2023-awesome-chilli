using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AwesomeChilli.DAL;
using Entities = AwesomeChilli.DAL.Entities;
using Repositories = AwesomeChilli.DAL.Repositories;
using AwesomeChilli.API.EntityViews;

namespace AwesomeChilli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        Repositories.CategoryRepository repository = new();

        [HttpGet("/Find[controller]")]
        public ActionResult<CategoryView> FindCategory(Guid guid)
        {
            try
            {
                return Ok(new CategoryView(repository.Find(guid)));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("/Create[controller]")]
        public ActionResult<Guid> CreateCategory(CategoryView newCategory)
        {
            try
            {
                return Ok(repository.Create(newCategory.MakeEntity()));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("/Update[controller]")]
        public ActionResult UpdateCategory(CategoryView updatedCategory)
        {
            try
            {
                repository.Update(updatedCategory.MakeEntity());
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("/Delete[controller]")]
        public ActionResult DeleteCategory(Guid guid)
        {
            try
            {
                repository.Delete(guid);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
