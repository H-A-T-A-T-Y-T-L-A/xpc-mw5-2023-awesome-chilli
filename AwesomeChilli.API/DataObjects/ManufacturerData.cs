using AwesomeChilli.DAL;
using AwesomeChilli.DAL.Entities;

namespace AwesomeChilli.API.EntityViews
{
    public class ManufacturerData : DataObjectBase<ManufacturerEntity>
    {
        public ManufacturerData()
        {
            Name = "";
            Image = "";
            Description = "";
            Country = "";
        }

        [Map(nameof(ManufacturerEntity.Name))]
        public string Name { get; set; }

        [Map(nameof(ManufacturerEntity.Image))]
        public string Image { get; set; }

        [Map(nameof(ManufacturerEntity.Description))]
        public string Description { get; set; }

        [Map(nameof(ManufacturerEntity.Country))]
        public string Country { get; set; }

        public long CommodityCount { get; set; }
    }
}
