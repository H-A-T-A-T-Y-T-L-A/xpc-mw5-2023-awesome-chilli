using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeChilli.DAL.Entities;

namespace AwesomeChilli.DAL.Repositories
{
    public class ManufacturerRepository : IRepository<ManufacturerEntity>
    {
        public Guid Create(ManufacturerEntity? entity)
        {
            // copy the new entity to the found entity
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity), $"Parameter {nameof(entity)} of function {nameof(Create)} in  {nameof(ManufacturerRepository)} was null");
            }

            // assign newly generated Guid
            entity.Id = Guid.NewGuid();

            // insert into database
            Database.Instance.Manufacturers.Add(entity);

            return entity.Id;
        }

        public ManufacturerEntity Find(Guid id)
        {
            return Database.Instance.Manufacturers.Single(e => e.Id == id);
        }

        public ManufacturerEntity Update(ManufacturerEntity? entity)
        {
            // nonsense
            if(entity is null)
            {
                throw new ArgumentNullException(nameof(entity), $"Parameter {nameof(entity)} of function {nameof(Update)} in {nameof(ManufacturerRepository)} was null");
            }

            // find the entity to update
            var existing = Find(entity.Id);

            // copy the new entity to the found entity
            existing.Name = entity.Name;
            existing.Image = entity.Image;
            existing.Description = entity.Description;
            existing.Country = entity.Country;


            // remove found entity from its commodities
            if (existing.Commodities is not null)
                foreach (var c in existing.Commodities)
                    c.Manufacturer = null;

            // copy list of commodities
            existing.Commodities = entity.Commodities;

            // add found entity back into its new commodities
            if (existing.Commodities is not null)
                foreach (var c in existing.Commodities)
                    c.Manufacturer = existing;

            return existing;
        }

        public void Delete(Guid id)
        {
            // find existing
            var entity = Find(id);

            // remove manufacturer from each of its commodities
            if (entity.Commodities is not null)
                foreach (var c in entity.Commodities)
                    c.Manufacturer = null;

            // remove existing entity
            Database.Instance.Manufacturers.Remove(entity);
        }

        public IEnumerable<ManufacturerEntity> GetPage(int page, int pageSize)
        {
            return Database.Instance.Manufacturers.Skip(page * pageSize).Take(pageSize);
        }
    }
}
