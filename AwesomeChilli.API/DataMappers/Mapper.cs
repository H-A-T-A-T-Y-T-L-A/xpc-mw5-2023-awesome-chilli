using AwesomeChilli.API.EntityViews;
using AwesomeChilli.DAL;
using AwesomeChilli.DAL.Entities;
using System.Reflection;

namespace AwesomeChilli.API.DataMappers
{
    public static class Mapper
    {
        public static TDataObject ToDataObject<TEntity, TDataObject> (this TEntity entity)
            where TEntity: class, IEntity
            where TDataObject: DataObjectBase<TEntity>, new()
        {
            TDataObject mappedDataObject = new();
            MapObjects(entity, ref mappedDataObject);
            return mappedDataObject;
        }

        public static TEntity ToEntity<TEntity, TDataObject> (this TDataObject dataObject)
            where TEntity: class, IEntity, new()
            where TDataObject: DataObjectBase<TEntity>
        {
            TEntity mappedEntity = new();
            MapObjects(dataObject, ref mappedEntity);
            return mappedEntity;
        }

        private static void MapObjects<TFrom, TTo>(TFrom from, ref TTo to)
        {
            var fromProperties = typeof(TFrom).GetProperties();
            var toProperties = typeof(TTo).GetProperties();

            foreach(var fromProperty in fromProperties)
            {
                if (fromProperty.GetCustomAttribute<MapAttribute>()
                    is MapAttribute mapAttribute and not null)
                    if (toProperties.FirstOrDefault(x => x?.GetCustomAttribute<MapAttribute>()?.MapName == mapAttribute.MapName)
                        is PropertyInfo toProperty and not null)
                    {
                        toProperty.SetValue(to, fromProperty.GetValue(from));
                        continue;
                    }
            }
        }
    }
}
