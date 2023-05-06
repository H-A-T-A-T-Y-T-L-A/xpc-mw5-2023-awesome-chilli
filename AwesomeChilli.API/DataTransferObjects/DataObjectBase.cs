using AwesomeChilli.DAL;
using AwesomeChilli.DAL.Entities;
using Entities = AwesomeChilli.DAL.Entities;

namespace AwesomeChilli.API.DataTransferObjects
{
    public abstract class DataObjectBase<TEntity> where TEntity : class, IEntity
    {
        [Map(nameof(IEntity.Id))]
        public Guid Id { get; set; }
    }
}
