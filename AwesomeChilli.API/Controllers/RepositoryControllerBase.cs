using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AwesomeChilli.DAL;
using Entities = AwesomeChilli.DAL.Entities;
using Repositories = AwesomeChilli.DAL.Repositories;
using AwesomeChilli.API.DataTransferObjects;
using AwesomeChilli.API.DataMappers;
using AwesomeChilli.DAL.Entities;
using AwesomeChilli.DAL.Repositories;
using AwesomeChilli.DAL.Queries;

namespace AwesomeChilli.API.Controllers
{
    [ApiController]
    public class RepositoryControllerBase<TEntity, TDataObject> : ControllerBase
        where TEntity : class, IEntity, new()
        where TDataObject : DataObjectBase<TEntity>, new()
    {
        internal readonly IRepository<TEntity> repository;
        internal readonly Mapper<TEntity, TDataObject> mapper;
        internal readonly GetAllQuery<TEntity> getAllQuery;
        public RepositoryControllerBase(IRepository<TEntity> repository, Mapper<TEntity, TDataObject> mapper, GetAllQuery<TEntity> getAllQuery)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.getAllQuery = getAllQuery;
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
                newEntity.Id = Guid.Empty;
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

        [HttpGet("/GetAll[controller]")]
        public ActionResult<IEnumerable<TDataObject>> GetAll()
        {
            try
            {
                return Ok(getAllQuery.Execute().Select(mapper.EntityToDataObject));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
