using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeChilli.DAL.Entities;

namespace AwesomeChilli.DAL.Repositories
{
    internal class ManufacturerRepository : IRepository<ManufacturerEntity>
    {
        public Guid Create(ManufacturerEntity? entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity), $"Parameter {nameof(entity)} of function {nameof(Create)} in  {nameof(ManufacturerRepository)} was null");
            }

            entity.Id = Guid.NewGuid();

            Database.Instance.Manufacturers.Add(entity);

            return entity.Id;
        }

        public ManufacturerEntity Find(Guid id)
        {
            return Database.Instance.Manufacturers.Single(e => e.Id == id);
        }

        public ManufacturerEntity Update(ManufacturerEntity? entity)
        {
            if(entity is null)
            {
                throw new ArgumentNullException(nameof(entity), $"Parameter {nameof(entity)} of function {nameof(Update)} in {nameof(ManufacturerRepository)} was null");
            }

            var existing = Find(entity.Id);

            existing.Name = entity.Name;
            existing.Image = entity.Image;
            existing.Description = entity.Description;
            existing.Country = entity.Country;
            existing.Commodities = entity.Commodities;

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
    }
}
