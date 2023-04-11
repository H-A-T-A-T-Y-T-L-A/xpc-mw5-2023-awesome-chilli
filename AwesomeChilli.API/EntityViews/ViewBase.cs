using AwesomeChilli.DAL.Entities;
using Entities = AwesomeChilli.DAL.Entities;

namespace AwesomeChilli.API.EntityViews
{
    public abstract class ViewBase<EntityT> where EntityT : class, IEntity
    {
        public Guid Id { get; set; }
        public  ViewBase() { }
        public ViewBase(EntityT entity) { Id = entity.Id; }

        public abstract EntityT MakeEntity();
    }
}
