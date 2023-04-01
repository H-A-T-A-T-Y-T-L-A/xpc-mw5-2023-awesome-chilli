using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AwesomeChilli.DAL;
using Entities = AwesomeChilli.DAL.Entities;
using Repositories = AwesomeChilli.DAL.Repositories;

namespace AwesomeChilli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        Repositories.CategoryRepository repository = new();

        [HttpGet("/Find[controller]")]
        public Entities.CategoryEntity FindCategory(Guid guid)
        {
            return repository.Find(guid);
        }

        [HttpPost("/Create[controller]")]
        public Guid CreateCategory(Entities.CategoryEntity newCategory)
        {
            return repository.Create(newCategory);
        }

        [HttpPost("/Update[controller]")]
        public void UpdateCategory(Entities.CategoryEntity updatedCategory)
        {
            repository.Update(updatedCategory);
        }

        [HttpPost("/Delete[controller]")]
        public void DeleteCategory(Guid guid)
        {
            repository.Delete(guid);
        }
    }
}
