using AwesomeChilli.DAL.Entities;

namespace AwesomeChilli.API.EntityViews
{
    public class ManufacturerView : ViewBase<ManufacturerEntity>
    {
        public ManufacturerView(ManufacturerEntity entity) : base(entity)
        {
            Name = entity.Name;
            Image = entity.Image ?? "";
            Description = entity.Description ?? "";
            Country = entity.Country ?? "";
            CommodityCount = entity.Commodities?.Count ?? 0;
        }

        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public long CommodityCount { get; set; }
    }
}
