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
    public class ManufacturerController : RepositoryControllerBase<ManufacturerEntity, ManufacturerData>
    {
        private readonly Queries.GetByName.GetByNameQuery<ManufacturerEntity> getByNameQuery;
        public ManufacturerController(Queries.GetByName.GetByNameQuery<ManufacturerEntity> getByNameQuery,
                                  IRepository<ManufacturerEntity> repository,
                                  Mapper<ManufacturerEntity, ManufacturerData> mapper,
                                  Queries.GetAllQuery<ManufacturerEntity> getAllQuery) : base(repository, mapper, getAllQuery)
        {
            this.getByNameQuery = getByNameQuery;
        }

        [HttpGet("/[controller]GetByName")]
        public ActionResult<IEnumerable<ManufacturerData>> GetByName(string name)
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
