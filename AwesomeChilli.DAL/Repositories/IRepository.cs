using AwesomeChilli.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeChilli.DAL.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        Guid Create(TEntity entity);
        TEntity Find(Guid id);
        Guid Update(TEntity entity);
        void Delete(Guid id);
    }
}
