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
        private Database database { get; }

        public CategoryRepository(Database database)
        {
            this.database = database;
        }

        public Guid Create(CategoryEntity? entity)
        {
            // do not allow null inserts
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity), $"Parameter {nameof(entity)} of function {nameof(Create)} in {nameof(CategoryRepository)} was null");
            }

            // assign newly generated Guid
            entity.Id = Guid.NewGuid();

            // insert into database
            database.Categories.Add(entity);

            return entity.Id;
        }

        public CategoryEntity Find(Guid id)
        {
            return database.Categories.Single(e => e.Id == id);
        }

        public CategoryEntity Update(CategoryEntity? entity)
        {
            // nonsense
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity), $"Parameter {nameof(entity)} of function {nameof(Update)} in {nameof(CategoryRepository)} was null");
            }

            // find the entity to update
            var existing = Find(entity.Id);

            // copy the new entity to the found entity
            existing.Name = entity.Name;

            // remove found entity from its current commodities
            if (existing.Commodities is not null)
                foreach (var commodity in existing.Commodities)
                    commodity.Category = null;

            // copy list of commodities
            existing.Commodities = entity.Commodities;

            // add found entity back into its new commodities
            if (existing.Commodities is not null)
                foreach (var commodity in existing.Commodities)
                    commodity.Category = existing;

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
            database.Categories.Remove(entity);
        }

        public IEnumerable<CategoryEntity> GetPage(int page, int pageSize)
        {
            return database.Categories.Skip(page * pageSize).Take(pageSize);
        }
    }
}
