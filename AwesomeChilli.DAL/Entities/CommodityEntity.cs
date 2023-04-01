using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeChilli.DAL.Entities
{
    internal class CommodityEntity:EntityBase
    {
        public required string Name { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public decimal? Weight { get; set; }
        public long Stock { get; set; }

        public CategoryEntity? Category { get; set; }
        public ManufacturerEntity? Manufacturer { get; set; }
        public ICollection<ReviewEntity>? Reviews { get; set; }
    }
}
