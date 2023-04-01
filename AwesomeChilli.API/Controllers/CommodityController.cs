using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AwesomeChilli.DAL;
using Entities = AwesomeChilli.DAL.Entities;
using Repositories = AwesomeChilli.DAL.Repositories;

namespace AwesomeChilli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommodityController : ControllerBase
    {
        Repositories.CommodityRepository repository = new();

        [HttpGet("/Find[controller]")]
        public Entities.CommodityEntity FindCommodity(Guid guid)
        {
            return repository.Find(guid);
        }

        [HttpPost("/Create[controller]")]
        public Guid CreateCommodity(Entities.CommodityEntity newCommodity)
        {
            return repository.Create(newCommodity);
        }

        [HttpPost("/Update[controller]")]
        public void UpdateCommodity(Entities.CommodityEntity updatedCommodity)
        {
            repository.Update(updatedCommodity);
        }

        [HttpPost("/Delete[controller]")]
        public void DeleteCommodity(Guid guid)
        {
            repository.Delete(guid);
        }
    }
}
