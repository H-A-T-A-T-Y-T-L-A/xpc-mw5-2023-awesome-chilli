using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeChilli.DAL.Entities
{
    public class CommodityEntity:EntityBase
    {
        [Map(nameof(Name))]
        public string Name { get; set; } = "";

        [Map(nameof(Image))]
        public string? Image { get; set; }

        [Map(nameof(Description))]
        public string? Description { get; set; }

        [Map(nameof(Price))]
        public decimal? Price { get; set; }

        [Map(nameof(Weight))]
        public decimal? Weight { get; set; }

        [Map(nameof(Stock))]
        public long Stock { get; set; }

        public CategoryEntity? Category { get; set; }
        public ManufacturerEntity? Manufacturer { get; set; }
        public ICollection<ReviewEntity>? Reviews { get; set; }
    }
}
