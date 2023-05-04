using AwesomeChilli.DAL;
using AwesomeChilli.DAL.Entities;
using AwesomeChilli.DAL.Repositories;

namespace AwesomeChilli.API.EntityViews
{
    public class CommodityData : DataObjectBase<CommodityEntity>
    {
        public CommodityData()
        {
            Name = "";
            Image = "";
            Description = "";
            Category = "";
            Manufacturer = "";
            CategoryId = "";
            ManufacturerId = "";
        }

        [Map(nameof(CommodityEntity.Name))]
        public string Name { get; set; }

        [Map(nameof(CommodityEntity.Image))]
        public string Image { get; set; }

        [Map(nameof(CommodityEntity.Description))]
        public string Description { get; set; }

        [Map(nameof(CommodityEntity.Price))]
        public decimal? Price { get; set; }

        [Map(nameof(CommodityEntity.Weight))]
        public decimal? Weight { get; set; }

        [Map(nameof(CommodityEntity.Stock))]
        public long Stock { get; set; }

        public string CategoryId { get; set; }
        public string Category { get; set; }

        public string ManufacturerId { get; set; }
        public string Manufacturer { get; set; }

        public double? ReviewsAverage { get; set; }
    }
}
