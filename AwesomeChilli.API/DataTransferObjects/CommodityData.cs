using AwesomeChilli.DAL;
using AwesomeChilli.DAL.Entities;
using AwesomeChilli.DAL.Repositories;

namespace AwesomeChilli.API.DataTransferObjects
{
    public class CommodityData : DataObjectBase<CommodityEntity>
    {
        [Map(nameof(CommodityEntity.Name))]
        public string Name { get; set; } = "";

        [Map(nameof(CommodityEntity.Image))]
        public string Image { get; set; } = "";

        [Map(nameof(CommodityEntity.Description))]
        public string Description { get; set; } = "";

        [Map(nameof(CommodityEntity.Price))]
        public decimal? Price { get; set; }

        [Map(nameof(CommodityEntity.Weight))]
        public decimal? Weight { get; set; }

        [Map(nameof(CommodityEntity.Stock))]
        public long Stock { get; set; } = 0;

        [Map(nameof(CommodityEntity.Category), Method = MapMethod.EntityId)]
        public string CategoryId { get; set; } = "";

        [Map(nameof(CommodityEntity.CategoryName))]
        public string Category { get; set; } = "";

        [Map(nameof(CommodityEntity.Manufacturer), Method = MapMethod.EntityId)]
        public string ManufacturerId { get; set; } = "";

        [Map(nameof(CommodityEntity.ManufacturerName))]
        public string Manufacturer { get; set; } = "";

        [Map(nameof(ReviewsAverage))]
        public double? ReviewsAverage { get; set; }
    }
}
