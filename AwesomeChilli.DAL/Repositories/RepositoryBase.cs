using AwesomeChilli.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AwesomeChilli.DAL.Repositories
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly Database database;
        public RepositoryBase(Database database)
        {
            this.database = database;
        }

        public Guid Create(TEntity entity)
        {
            database.Add(entity);
            database.SaveChanges();

            return entity.Id;
        }

        public void Delete(Guid id)
        {
            var entity = database.Find<TEntity>(id);
            if (entity is null)
                return;

            database.Remove(entity);
            database.SaveChanges();
        }

        public TEntity Find(Guid id)
        {
            var entity = database.Find<TEntity>(id);
            if (entity is null)
                return new();
            return entity;
        }

        public static void CopyProperties(TEntity sourceEntity, TEntity targetEntity)
        {
            var entityType = typeof(TEntity);
            var properties = entityType.GetProperties();

            foreach (var property in properties)
                if (property.CanRead && property.CanWrite)
                    property.SetValue(targetEntity, property.GetValue(sourceEntity));
        }

        public Guid Update(TEntity entity)
        {
            var existing = database.Set<TEntity>().Find(entity.Id);
            if(existing is null)
                return Guid.Empty;

            CopyProperties(entity, existing);
            database.Update(existing);
            database.SaveChanges();
            return entity.Id;
        }
    }
}
