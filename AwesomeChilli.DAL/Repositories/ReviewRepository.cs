using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeChilli.DAL.Entities;

namespace AwesomeChilli.DAL.Repositories
{
    internal class ReviewRepository : IRepository<ReviewEntity>
    {
        public Guid Create(ReviewEntity? entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity), $"Parameter {nameof(entity)} of function {nameof(Create)} in  {nameof(ReviewRepository)} was null");
            }

            entity.Id = Guid.NewGuid();

            Database.Instance.Reviews.Add(entity);

            return entity.Id;
        }

        public ReviewEntity Find(Guid id)
        {
            return Database.Instance.Reviews.Single(e => e.Id == id);
        }

        public ReviewEntity Update(ReviewEntity? entity)
        {
            if(entity is null)
            {
                throw new ArgumentNullException(nameof(entity), $"Parameter {nameof(entity)} of function {nameof(Update)} in {nameof(ReviewRepository)} was null");
            }

            var existing = Find(entity.Id);

            existing.Stars = entity.Stars;
            existing.Title = entity.Title;
            existing.Description = entity.Description;
            existing.Commodity = entity.Commodity;

            return existing;
        }

        public void Delete(Guid id)
        {
            // find existing
            var entity = Find(id);

            // remove existing entity
            Database.Instance.Reviews.Remove(entity);
        }
    }
}
