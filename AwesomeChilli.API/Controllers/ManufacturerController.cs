using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AwesomeChilli.DAL;
using Entities = AwesomeChilli.DAL.Entities;
using Repositories = AwesomeChilli.DAL.Repositories;

namespace AwesomeChilli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        Repositories.ManufacturerRepository repository = new();

        [HttpGet("/Find[controller]")]
        public Entities.ManufacturerEntity FindManufacturer(Guid guid)
        {
            return repository.Find(guid);
        }

        [HttpPost("/Create[controller]")]
        public Guid CreateManufacturer(Entities.ManufacturerEntity newManufacturer)
        {
            return repository.Create(newManufacturer);
        }

        [HttpPost("/Update[controller]")]
        public void UpdateManufacturer(Entities.ManufacturerEntity updatedManufacturer)
        {
            repository.Update(updatedManufacturer);
        }

        [HttpPost("/Delete[controller]")]
        public void DeleteManufacturer(Guid guid)
        {
            repository.Delete(guid);
        }
    }
}
