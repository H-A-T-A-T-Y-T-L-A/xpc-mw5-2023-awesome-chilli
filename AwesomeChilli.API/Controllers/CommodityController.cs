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
    public class CommodityController : RepositoryControllerBase<CommodityEntity, CommodityData>
    {
        private readonly Queries.GetByName.GetByNameQuery<CommodityEntity> getByNameQuery;
        private readonly Queries.GetCommodityByCategoryQuery getCommodityByCategoryQuery;
        private readonly Queries.GetCommodityByManufacturerQuery getCommodityByManufacturerQuery;
        public CommodityController(Queries.GetByName.GetByNameQuery<CommodityEntity> getByNameQuery,
                                  Queries.GetCommodityByCategoryQuery getCommodityByCategoryQuery,
                                  Queries.GetCommodityByManufacturerQuery getCommodityByManufacturerQuery,
                                  IRepository<CommodityEntity> repository,
                                  Mapper<CommodityEntity, CommodityData> mapper,
                                  Queries.GetAllQuery<CommodityEntity> getAllQuery) : base(repository, mapper, getAllQuery)
        {
            this.getByNameQuery = getByNameQuery;
            this.getCommodityByCategoryQuery = getCommodityByCategoryQuery;
            this.getCommodityByManufacturerQuery = getCommodityByManufacturerQuery;
        }

        [HttpGet("/[controller]GetByName")]
        public ActionResult<IEnumerable<CommodityData>> GetByName(string name)
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

        [HttpGet("/[controller]GetByCategory")]
        public ActionResult<IEnumerable<CommodityData>> GetByCategory(Guid id)
        {
            try
            {
                return Ok(getCommodityByCategoryQuery.Execute(id).Select(mapper.EntityToDataObject));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("/[controller]GetByManufacturer")]
        public ActionResult<IEnumerable<CommodityData>> GetByManufacturer(Guid id)
        {
            try
            {
                return Ok(getCommodityByManufacturerQuery.Execute(id).Select(mapper.EntityToDataObject));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
