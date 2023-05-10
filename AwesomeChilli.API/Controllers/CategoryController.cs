using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AwesomeChilli.API.DataTransferObjects;
using AwesomeChilli.API.DataMappers;
using AwesomeChilli.DAL.Entities;
using AwesomeChilli.DAL.Repositories;
using Queries = AwesomeChilli.DAL.Queries;

namespace AwesomeChilli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : RepositoryControllerBase<CategoryEntity, CategoryData>
    {
        private readonly Queries.GetByName.GetByNameQuery<CategoryEntity> getByNameQuery;
        public CategoryController(Queries.GetByName.GetByNameQuery<CategoryEntity> getByNameQuery,
                                  IRepository<CategoryEntity> repository,
                                  Mapper<CategoryEntity, CategoryData> mapper,
                                  Queries.GetAllQuery<CategoryEntity> getAllQuery) : base(repository, mapper, getAllQuery)
        {
            this.getByNameQuery = getByNameQuery;
        }

        [HttpGet("/[controller]GetByName")]
        public ActionResult<IEnumerable<CategoryData>> GetByName(string name)
        {
            try
            {
                return Ok(getByNameQuery.Execute(name).Select(mapper.EntityToDataObject));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
