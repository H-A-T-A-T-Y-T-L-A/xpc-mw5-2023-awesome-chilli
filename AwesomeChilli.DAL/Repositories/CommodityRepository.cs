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
            // do not allow null inserts
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity), $"Parameter {nameof(entity)} of function {nameof(Create)} in {nameof(CommodityRepository)} was null");
            }

            // assign newly generated Guid
            entity.Id = Guid.NewGuid();

            // insert into database
            Database.Instance.Commodities.Add(entity);

            // add self to category
            if(entity.Category is not null)
            {
                entity.Category.Commodities ??= new List<CommodityEntity>();
                entity.Category.Commodities.Add(entity);
            }

            // add self to manufacturer
            if(entity.Manufacturer is not null)
            {
                entity.Manufacturer.Commodities ??= new List<CommodityEntity>();
                entity.Manufacturer.Commodities.Add(entity);
            }

            return entity.Id;
        }

        public CommodityEntity Find(Guid id)
        {
            return Database.Instance.Commodities.Single(e => e.Id == id);
        }

        public CommodityEntity Update(CommodityEntity? entity)
        {
            // nonsense
            if(entity is null)
            {
                throw new ArgumentNullException(nameof(entity), $"Parameter {nameof(entity)} of function {nameof(Update)} in {nameof(CommodityRepository)} was null");
            }

            // find the entity to update
            var existing = Find(entity.Id);

            // copy the new entity to the found entity
            existing.Name = entity.Name;
            existing.Image = entity.Image;
            existing.Description = entity.Description;
            existing.Price = entity.Price;
            existing.Weight = entity.Weight;
            existing.Stock = entity.Stock;

            // delete found entity from its previous category
            if(entity.Category is not null)
                entity.Category?.Commodities?.Remove(entity);

            // delete found entity from its previous manufacturer
            if(entity.Manufacturer is not null)
                entity.Manufacturer?.Commodities?.Remove(entity);

            // copy references
            existing.Category = entity.Category;
            existing.Manufacturer = entity.Manufacturer;
            
            // add found entity to its new category
            if(existing.Category is not null)
            {
                existing.Category.Commodities ??= new List<CommodityEntity>();
                existing.Category.Commodities.Add(existing);
            }

            // add found entity to its new category
            if(existing.Manufacturer is not null)
            {
                existing.Manufacturer.Commodities ??= new List<CommodityEntity>();
                existing.Manufacturer.Commodities.Add(existing);
            }

            // remove found entity from its reviews
            if (existing.Reviews is not null)
                foreach (var review in existing.Reviews)
                    review.Commodity = null;

            // copy list of reviews
            existing.Reviews = entity.Reviews;

            // add found enitity back into its new commodities
            if (existing.Reviews is not null)
                foreach (var review in existing.Reviews)
                    review.Commodity = existing;

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

            // delete self from category
            if(entity.Category is not null)
                entity.Category?.Commodities?.Remove(entity);

            // delete self from manufacturer
            if(entity.Manufacturer is not null)
                entity.Manufacturer?.Commodities?.Remove(entity);

            // remove existing entity
            Database.Instance.Commodities.Remove(entity);
        }

        public IEnumerable<CommodityEntity> GetPage(int page, int pageSize)
        {
            return Database.Instance.Commodities.Skip(page * pageSize).Take(pageSize);
        }
    }
}
