using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeChilli.DAL.Entities;

namespace AwesomeChilli.DAL.Repositories
{
    public class CommodityRepository : IRepository<CommodityEntity>
    {
        public Guid Create(CommodityEntity? entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity), $"Parameter {nameof(entity)} of function {nameof(Create)} in {nameof(CommodityRepository)} was null");
            }

            entity.Id = Guid.NewGuid();

            Database.Instance.Commodities.Add(entity);

            return entity.Id;
        }

        public CommodityEntity Find(Guid id)
        {
            return Database.Instance.Commodities.Single(e => e.Id == id);
        }

        public CommodityEntity Update(CommodityEntity? entity)
        {
            if(entity is null)
            {
                throw new ArgumentNullException(nameof(entity), $"Parameter {nameof(entity)} of function {nameof(Update)} in {nameof(CommodityRepository)} was null");
            }

            var existing = Find(entity.Id);

            existing.Name = entity.Name;
            existing.Image = entity.Image;
            existing.Description = entity.Description;
            existing.Price = entity.Price;
            existing.Weight = entity.Weight;
            existing.Stock = entity.Stock;

            existing.Category = entity.Category;
            existing.Manufacturer = entity.Manufacturer;
            existing.Reviews = entity.Reviews;

            return existing;
        }

        public void Delete(Guid id)
        {
            // find existing
            var entity = Find(id);

            // delete all reviews of commodity
            if(entity.Reviews is not null)
                foreach (var r in entity.Reviews)
                    Database.Instance.Reviews.Remove(r);

            // remove existing entity
            Database.Instance.Commodities.Remove(entity);
        }
    }
}
