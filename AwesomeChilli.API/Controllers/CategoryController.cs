using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AwesomeChilli.DAL;
using Entities = AwesomeChilli.DAL.Entities;
using Repositories = AwesomeChilli.DAL.Repositories;
using AwesomeChilli.API.EntityViews;
using AwesomeChilli.API.DataMappers;
using AwesomeChilli.DAL.Entities;
using AwesomeChilli.DAL.Repositories;

namespace AwesomeChilli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : RepositoryControllerBase<CategoryEntity, CategoryData>
    {
        public CategoryController(IRepository<CategoryEntity> repository, Mapper<CategoryEntity, CategoryData> mapper) : base(repository, mapper)
        {
        }
    }
}
