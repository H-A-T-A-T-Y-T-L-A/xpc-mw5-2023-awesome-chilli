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
    public class ManufacturerController : ControllerBase
    {
        Repositories.ManufacturerRepository repository = new();

        [HttpGet("/Find[controller]")]
        public ActionResult<ManufacturerView> FindManufacturer(Guid guid)
        {
            try
            {
                return Ok(new ManufacturerView(repository.Find(guid)));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("/Create[controller]")]
        public ActionResult<Guid> CreateManufacturer(ManufacturerView newManufacturer)
        {
            try
            {
                return Ok(repository.Create(newManufacturer.MakeEntity()));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("/Update[controller]")]
        public ActionResult UpdateManufacturer(ManufacturerView updatedManufacturer)
        {
            try
            {
                repository.Update(updatedManufacturer.MakeEntity());
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("/Delete[controller]")]
        public ActionResult DeleteManufacturer(Guid guid)
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
