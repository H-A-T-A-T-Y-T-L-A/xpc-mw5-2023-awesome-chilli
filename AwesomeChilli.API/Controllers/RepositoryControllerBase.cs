using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AwesomeChilli.DAL;
using Entities = AwesomeChilli.DAL.Entities;
using Repositories = AwesomeChilli.DAL.Repositories;
using AwesomeChilli.API.DataTransferObjects;
using AwesomeChilli.API.DataMappers;
using AwesomeChilli.DAL.Entities;
using AwesomeChilli.DAL.Repositories;

namespace AwesomeChilli.API.Controllers
{
    [ApiController]
    public class RepositoryControllerBase<TEntity, TDataObject> : ControllerBase
        where TEntity : class, IEntity, new()
        where TDataObject : DataObjectBase<TEntity>, new()
    {
        readonly IRepository<TEntity> repository;
        readonly Mapper<TEntity, TDataObject> mapper;
        public RepositoryControllerBase(IRepository<TEntity> repository, Mapper<TEntity, TDataObject> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet("/Find[controller]")]
        public ActionResult<TDataObject> Find(Guid guid)
        {
            try
            {
                TEntity foundEntity = repository.Find(guid);
                TDataObject dataObject = mapper.EntityToDataObject(foundEntity);
                return Ok(dataObject);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("/Create[controller]")]
        public ActionResult<Guid> Create(TDataObject newObject)
        {
            try
            {
                TEntity newEntity = mapper.DataObjectToEntity(newObject);
                Guid newEntityId = repository.Create(newEntity);
                return Ok(newEntityId);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("/Update[controller]")]
        public ActionResult Update(TDataObject updateObject)
        {
            try
            {
                TEntity updateEntity = mapper.DataObjectToEntity(updateObject);
                repository.Update(updateEntity);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("/Delete[controller]")]
        public ActionResult Delete(Guid guid)
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
