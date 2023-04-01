using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeChilli.DAL.Entities;

namespace AwesomeChilli.DAL.Repositories
{
    public class CategoryRepository : IRepository<CategoryEntity>
    {
        public Guid Create(CategoryEntity? entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity), $"Parameter {nameof(entity)} of function {nameof(Create)} in {nameof(CategoryRepository)} was null");
            }

            entity.Id = Guid.NewGuid();

            Database.Instance.Categories.Add(entity);

            return entity.Id;
        }

        public CategoryEntity Find(Guid id)
        {
            return Database.Instance.Categories.Single(e => e.Id == id);
        }

        public CategoryEntity Update(CategoryEntity? entity)
        {
            if(entity is null)
            {
                throw new ArgumentNullException(nameof(entity), $"Parameter {nameof(entity)} of function {nameof(Update)} in {nameof(CategoryRepository)} was null");
            }

            var existing = Find(entity.Id);

            existing.Name = entity.Name;

            return existing;
        }

        public void Delete(Guid id)
        {
            // find existing
            var entity = Find(id);

            // remove category from each of its commodities
            if (entity.Commodities is not null)
                foreach (var c in entity.Commodities)
                    c.Category = null;

            // remove existing entity
            Database.Instance.Categories.Remove(entity);
        }
    }
}
