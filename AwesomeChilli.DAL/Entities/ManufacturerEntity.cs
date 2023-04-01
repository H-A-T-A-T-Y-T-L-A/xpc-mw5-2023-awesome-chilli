using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeChilli.DAL.Entities
{
    internal class ManufacturerEntity : EntityBase
    {
        public required string Name { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public string? Country { get; set; }
        public ICollection<CommodityEntity>? Commodities { get; set; }
    }
}
