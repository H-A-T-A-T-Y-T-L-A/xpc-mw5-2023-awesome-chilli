using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AwesomeChilli.DAL;
using Entities = AwesomeChilli.DAL.Entities;
using Repositories = AwesomeChilli.DAL.Repositories;
using AwesomeChilli.API.DataTransferObjects;
using AwesomeChilli.DAL.Repositories;
using AwesomeChilli.DAL.Entities;
using AwesomeChilli.API.DataMappers;

namespace AwesomeChilli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : RepositoryControllerBase<ManufacturerEntity, ManufacturerData>
    {
        public ManufacturerController(IRepository<ManufacturerEntity> repository, Mapper<ManufacturerEntity, ManufacturerData> mapper) : base(repository, mapper)
        {
        }
    }
}
