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
    public class CommodityController : ControllerBase
    {
        Repositories.CommodityRepository repository = new();

        [HttpGet("/Find[controller]")]
        public ActionResult<CommodityView> FindCommodity(Guid guid)
        {
            try
            {
                return Ok(new CommodityView(repository.Find(guid)));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("/Create[controller]")]
        public ActionResult<Guid> CreateCommodity(CommodityView newCommodity)
        {
            try
            {
                return Ok(repository.Create(newCommodity.MakeEntity()));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("/Update[controller]")]
        public ActionResult UpdateCommodity(CommodityView updatedCommodity)
        {
            try
            {
                repository.Update(updatedCommodity.MakeEntity());
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("/Delete[controller]")]
        public ActionResult DeleteCommodity(Guid guid)
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
