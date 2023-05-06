using AwesomeChilli.DAL;
using AwesomeChilli.DAL.Entities;

namespace AwesomeChilli.API.DataTransferObjects
{
    public class ManufacturerData : DataObjectBase<ManufacturerEntity>
    {
        [Map(nameof(ManufacturerEntity.Name))]
        public string Name { get; set; } = "";

        [Map(nameof(ManufacturerEntity.Image))]
        public string Image { get; set; } = "";

        [Map(nameof(ManufacturerEntity.Description))]
        public string Description { get; set; } = "";

        [Map(nameof(ManufacturerEntity.Country))]
        public string Country { get; set; } = "";

        public long CommodityCount { get; set; }
    }
}
