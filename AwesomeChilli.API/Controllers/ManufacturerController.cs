using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AwesomeChilli.DAL;
using Entities = AwesomeChilli.DAL.Entities;
using Repositories = AwesomeChilli.DAL.Repositories;
using AwesomeChilli.API.EntityViews;
using AwesomeChilli.DAL.Repositories;
using AwesomeChilli.DAL.Entities;

namespace AwesomeChilli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : RepositoryControllerBase<ManufacturerEntity, ManufacturerData>
    {
        public ManufacturerController(IRepository<ManufacturerEntity> repository) : base(repository)
        {
        }
    }
}
