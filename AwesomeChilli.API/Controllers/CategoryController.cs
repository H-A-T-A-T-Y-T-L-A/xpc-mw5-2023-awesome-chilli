using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AwesomeChilli.DAL;
using Entities = AwesomeChilli.DAL.Entities;
using Repositories = AwesomeChilli.DAL.Repositories;
using AwesomeChilli.API.DataTransferObjects;
using AwesomeChilli.API.DataMappers;
using AwesomeChilli.DAL.Entities;
using AwesomeChilli.DAL.Repositories;
using System.Security.Cryptography.X509Certificates;
using AwesomeChilli.DAL.Queries;

namespace AwesomeChilli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : RepositoryControllerBase<CategoryEntity, CategoryData>
    {
        private readonly GetAllQuery<CategoryEntity> getAllQuery;
        public CategoryController(IRepository<CategoryEntity> repository, Mapper<CategoryEntity, CategoryData> mapper, GetAllQuery<CategoryEntity> getAllQuery) : base(repository, mapper)
        {
            this.getAllQuery = getAllQuery;
        }

        [HttpGet("/AllCategories")]
        public IEnumerable<CategoryEntity> AllCategories()
        {
            return getAllQuery.Execute();
        }
    }
}
