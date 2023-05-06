using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeChilli.DAL.Entities
{
    public class ReviewEntity : EntityBase
    {
        [Map(nameof(Stars))]
        public double Stars { get; set; } = 0;

        [Map(nameof(Title))]
        public string Title { get; set; } = "";

        [Map(nameof(Description))]
        public string Description { get; set; } = "";

        [Map(nameof(Commodity), Method = MapMethod.EntityId)]
        public CommodityEntity? Commodity { get; set; }
    }
}
