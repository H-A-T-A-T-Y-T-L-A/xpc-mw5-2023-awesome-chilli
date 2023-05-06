using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AwesomeChilli.DAL;
using Entities = AwesomeChilli.DAL.Entities;
using Repositories = AwesomeChilli.DAL.Repositories;
using AwesomeChilli.API.DataTransferObjects;
using AwesomeChilli.DAL.Entities;
using AwesomeChilli.DAL.Repositories;
using AwesomeChilli.API.DataMappers;

namespace AwesomeChilli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommodityController : RepositoryControllerBase<CommodityEntity, CommodityData>
    {
        public CommodityController(IRepository<CommodityEntity> repository, Mapper<CommodityEntity, CommodityData> mapper) : base(repository, mapper)
        {
        }
    }
}
