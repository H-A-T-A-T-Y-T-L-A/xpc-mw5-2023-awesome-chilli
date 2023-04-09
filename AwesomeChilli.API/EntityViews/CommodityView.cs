using AwesomeChilli.DAL.Entities;

namespace AwesomeChilli.API.EntityViews
{
    public class CommodityView : ViewBase<CommodityEntity>
    {
        public CommodityView(CommodityEntity entity) : base(entity)
        {
            Name = entity.Name;
            Image = entity.Image ?? "";
            Description = entity.Description ?? "";
            Price = entity.Price;
            Weight = entity.Weight;
            Stock = entity.Stock;
            Category = entity.Category?.Name ?? "";
            Manufacturer = entity.Manufacturer?.Name ?? "";
            ReviewsAverage = entity.Reviews?.Average(rev => rev.Stars);
        }

        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public decimal? Weight { get; set; }
        public long Stock { get; set; }

        public string Category { get; set; }
        public string Manufacturer { get; set; }
        public double? ReviewsAverage { get; set; }
    }
}
