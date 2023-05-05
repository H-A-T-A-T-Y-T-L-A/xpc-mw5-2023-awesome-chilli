using AwesomeChilli.API.Controllers;
using AwesomeChilli.API.EntityViews;
using AwesomeChilli.DAL;
using AwesomeChilli.DAL.Entities;
using AwesomeChilli.DAL.Repositories;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace AwesomeChilli.API.DataMappers
{
    public class Mapper<TEntity, TDataObject>
        where TEntity : class, IEntity, new()
        where TDataObject : DataObjectBase<TEntity>, new()
    {
        private readonly IServiceProvider serviceProvider;
        public Mapper(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

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

        private void MapObjects<TFrom, TTo>(TFrom from, ref TTo to)
        {
            var fromProperties = typeof(TFrom).GetProperties();
            var toProperties = typeof(TTo).GetProperties();

            foreach (var fromProperty in fromProperties)
            {
                if (fromProperty.GetCustomAttribute<MapAttribute>()
                    is MapAttribute mapAttribute and not null)
                    if (toProperties.FirstOrDefault(x => x?.GetCustomAttribute<MapAttribute>()?.MapName == mapAttribute.MapName)
                        is PropertyInfo toProperty and not null)
                    {
                        if (!toProperty.CanWrite)
                            continue;

                        switch (mapAttribute.Method)
                        {
                            case MapMethod.Value:
                                if (toProperty.PropertyType.IsAssignableFrom(fromProperty.PropertyType))
                                    toProperty.SetValue(to, fromProperty.GetValue(from));
                                break;

                            case MapMethod.EntityId:
                                if (fromProperty.GetValue(from) is IEntity fromEntityProperty
                                    && toProperty.PropertyType == typeof(string))
                                {
                                    toProperty.SetValue(to, fromEntityProperty.Id.ToString());
                                }
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
}
