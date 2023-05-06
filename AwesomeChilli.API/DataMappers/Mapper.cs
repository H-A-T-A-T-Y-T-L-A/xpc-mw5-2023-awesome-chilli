using AwesomeChilli.API.Controllers;
using AwesomeChilli.API.DataTransferObjects;
using AwesomeChilli.DAL;
using AwesomeChilli.DAL.Entities;
using AwesomeChilli.DAL.Repositories;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace AwesomeChilli.API.DataMappers
{
    // generic mapper between entities and data objects
    public class Mapper<TEntity, TDataObject>
        where TEntity : class, IEntity, new()
        where TDataObject : DataObjectBase<TEntity>, new()
    {
        // service provider to dynamically search for the required repositories
        private readonly IServiceProvider serviceProvider;
        public Mapper(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        // mapping methods
        public TDataObject EntityToDataObject(TEntity entity)
        {
            TDataObject mappedDataObject = new();
            MapObjects(entity, ref mappedDataObject);
            return mappedDataObject;
        }
        public TEntity DataObjectToEntity(TDataObject dataObject)
        {
            TEntity mappedEntity = new();
            MapObjects(dataObject, ref mappedEntity);
            return mappedEntity;
        }

        // universal mapping method, may be used for more things later
        private void MapObjects<TFrom, TTo>(TFrom from, ref TTo to)
        {
            var fromProperties = typeof(TFrom).GetProperties();
            var toProperties = typeof(TTo).GetProperties();

            // look through every property of the object being mapped from
            foreach (var fromProperty in fromProperties)
            {
                // find those that are marked with a MapAttribute signifying they can be mapped
                var mapAttribute = fromProperty.GetCustomAttribute<MapAttribute>();
                if (mapAttribute is null)
                    continue;

                // find the corresponding property on the object being mapped to
                var toProperty = toProperties.FirstOrDefault(p => p.GetCustomAttribute<MapAttribute>()?.MapName == mapAttribute.MapName && p.CanWrite);
                if (toProperty is null)
                    continue;

                // ignore unwritable properties, this can be used for one-way mapping
                if (!toProperty.CanWrite)
                    continue;

                // use the attribute on the object being mapped from
                // to decide what mapping method to use
                switch (mapAttribute.Method)
                {
                    // by default simply copy the value
                    case MapMethod.Value:
                        if (toProperty.PropertyType.IsAssignableFrom(fromProperty.PropertyType))
                            toProperty.SetValue(to, fromProperty.GetValue(from));
                        break;

                    // if the mapping method is by the entities Id,
                    // what happens next depends on the direction of the mapping
                    case MapMethod.EntityId:
                        // if the property that's being mapped from is an IEntity,
                        // and the other entity is a string, just get the Id of the IEntity
                        // and convert it to a string
                        if (fromProperty.GetValue(from) is IEntity fromEntityProperty
                            && toProperty.PropertyType == typeof(string))
                        {
                            toProperty.SetValue(to, fromEntityProperty.Id.ToString());
                        }
                        // otherwise, if the types of the properties are the opposite way,
                        // use the service provider to locate a repository of the IEntity
                        // and find the desired entity
                        else if (fromProperty.GetValue(from) is string idString
                            && Guid.TryParse(idString, out Guid entityId))
                        {
                            var repositoryType = typeof(IRepository<>).MakeGenericType(toProperty.PropertyType);
                            var repository = serviceProvider.GetService(repositoryType);

                            var findMethod = repositoryType?.GetMethod(nameof(IRepository<IEntity>.Find));

                            if (findMethod is not null)
                                toProperty.SetValue(to, findMethod.Invoke(repository, new object[] { entityId }));
                        }
                        break;
                }
            }
        }
    }
}
