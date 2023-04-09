using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeChilli.DAL.Entities;

namespace AwesomeChilli.DAL.Repositories
{
    public class ReviewRepository : IRepository<ReviewEntity>
    {
        public Guid Create(ReviewEntity? entity)
        {
            // do not allow null inserts
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity), $"Parameter {nameof(entity)} of function {nameof(Create)} in  {nameof(ReviewRepository)} was null");
            }

            // assign newly generated Guid
            entity.Id = Guid.NewGuid();

            // insert into database
            Database.Instance.Reviews.Add(entity);

            // add self to commodity
            if (entity.Commodity is not null)
            {
                entity.Commodity.Reviews ??= new List<ReviewEntity>();
                entity.Commodity.Reviews.Add(entity);
            }

            return entity.Id;
        }

        public ReviewEntity Find(Guid id)
        {
            return Database.Instance.Reviews.Single(e => e.Id == id);
        }

        public ReviewEntity Update(ReviewEntity? entity)
        {
            // nonsense
            if(entity is null)
            {
                throw new ArgumentNullException(nameof(entity), $"Parameter {nameof(entity)} of function {nameof(Update)} in {nameof(ReviewRepository)} was null");
            }

            // find the entity to update
            var existing = Find(entity.Id);

            // copy the new entity to the found entity
            existing.Stars = entity.Stars;
            existing.Title = entity.Title;


            // delete found entity from its previous category
            if(existing.Commodity is not null)
                existing.Commodity?.Reviews?.Remove(existing);

            // copy references
            existing.Description = entity.Description;
            existing.Commodity = entity.Commodity;

            // add self to commodity
            if (existing.Commodity is not null)
            {
                existing.Commodity.Reviews ??= new List<ReviewEntity>();
                existing.Commodity.Reviews.Add(existing);
            }

            return existing;
        }

        public void Delete(Guid id)
        {
            // find existing
            var entity = Find(id);

            // delete found entity from its previous category
            if(entity.Commodity is not null)
                entity.Commodity?.Reviews?.Remove(entity);

            // remove existing entity
            Database.Instance.Reviews.Remove(entity);
        }
    }
}
