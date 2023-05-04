using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AwesomeChilli.DAL;
using Entities = AwesomeChilli.DAL.Entities;
using Repositories = AwesomeChilli.DAL.Repositories;
using AwesomeChilli.API.EntityViews;
using AwesomeChilli.DAL.Entities;
using AwesomeChilli.DAL.Repositories;

namespace AwesomeChilli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommodityController : RepositoryControllerBase<CommodityEntity, CommodityData>
    {
        public CommodityController(IRepository<CommodityEntity> repository) : base(repository)
        {
        }
    }
}
