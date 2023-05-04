using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AwesomeChilli.DAL;
using Entities = AwesomeChilli.DAL.Entities;
using Repositories = AwesomeChilli.DAL.Repositories;
using AwesomeChilli.API.EntityViews;
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
        IRepository<TEntity> repository;
        public RepositoryControllerBase(IRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        [HttpPost("/Find[controller]")]
        public ActionResult<TDataObject> Find(Guid guid)
        {
            try
            {
                return Ok(repository.Find(guid).ToDataObject<TEntity, TDataObject>());
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
                return Ok(repository.Create(newObject.ToEntity<TEntity, TDataObject>()));
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
                repository.Update(updateObject.ToEntity<TEntity, TDataObject>());
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

        [HttpGet("/Page[controller]")]
        public ActionResult<IEnumerable<TDataObject>> GetPage (int page, int PageSize)
        {
            try
            {
                return Ok(repository.GetPage(page, PageSize).Select(x => x.ToDataObject<TEntity, TDataObject>()));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
