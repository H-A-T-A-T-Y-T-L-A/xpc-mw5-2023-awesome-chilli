using AwesomeChilli.DAL.Entities;

namespace AwesomeChilli.API.EntityViews
{
    public class CategoryView : ViewBase<CategoryEntity>
    {
        public CategoryView(CategoryEntity entity) : base(entity)
        {
            Name = entity.Name;
        }

        public string Name { get; set; }
    }
}
