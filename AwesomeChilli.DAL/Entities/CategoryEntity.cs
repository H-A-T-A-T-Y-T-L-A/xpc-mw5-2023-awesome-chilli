using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeChilli.DAL.Entities
{
    public class CategoryEntity : EntityBase
    {
        public required string Name { get; set; }
        public ICollection<CommodityEntity>? Commodities { get; set; }
    }
}
