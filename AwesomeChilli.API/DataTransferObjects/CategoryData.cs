using AwesomeChilli.DAL;
using AwesomeChilli.DAL.Entities;

namespace AwesomeChilli.API.DataTransferObjects
{
    public class CategoryData : DataObjectBase<CategoryEntity>
    {
        [Map(nameof(CategoryEntity.Name))]
        public string Name { get; set; } = "";
    }
}
