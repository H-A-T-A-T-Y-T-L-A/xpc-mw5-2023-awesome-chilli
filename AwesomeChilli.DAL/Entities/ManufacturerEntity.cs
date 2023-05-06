using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeChilli.DAL.Entities
{
    public class ManufacturerEntity : EntityBase
    {
        [Map(nameof(Name))]
        public string Name { get; set; } = "";

        [Map(nameof(Image))]
        public string? Image { get; set; }

        [Map(nameof(Description))]
        public string? Description { get; set; }

        [Map(nameof(Country))]
        public string? Country { get; set; }

        public ICollection<CommodityEntity>? Commodities { get; set; }
    }
}
