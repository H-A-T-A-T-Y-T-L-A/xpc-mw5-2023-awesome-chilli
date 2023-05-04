using AwesomeChilli.DAL;
using AwesomeChilli.DAL.Entities;

namespace AwesomeChilli.API.EntityViews
{
    public class CategoryData : DataObjectBase<CategoryEntity>
    {
        public CategoryData()
        {
            Name = "";
        }

        // public CategoryData(CategoryEntity entity) : base(entity)
        // {
        //     Name = entity.Name;
        // }

        [Map(nameof(CategoryEntity.Name))]
        public string Name { get; set; }

        //public override CategoryEntity MakeEntity()
        //{
        //    return new()
        //    {
        //        Id = Id,
        //        Name = Name
        //    };
        //}
    }
}
