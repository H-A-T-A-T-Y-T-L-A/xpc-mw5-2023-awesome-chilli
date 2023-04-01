using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeChilli.DAL.Entities
{
    internal class ReviewEntity : EntityBase
    {
        public double Stars { get; set; }
        public string Title { get; set; } = "";
        public string? Description { get; set; }
        public CommodityEntity? Commodity { get; set; }
    }
}
