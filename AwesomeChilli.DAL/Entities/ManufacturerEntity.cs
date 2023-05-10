using AwesomeChilli.DAL.Queries.GetByName;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Queries = AwesomeChilli.DAL.Queries;

namespace AwesomeChilli.DAL.Entities
{
    public class ManufacturerEntity : EntityBase, Queries.GetByName.INamedEntity
    {
        [Map(nameof(Name))]
        public string Name { get; set; } = "";

        [Map(nameof(Image))]
        public string? Image { get; set; }

        [Map(nameof(Description))]
        public string? Description { get; set; }

        [Map(nameof(Country))]
        public string? Country { get; set; }

        public ICollection<CommodityEntity> Commodities { get; set; } = new List<CommodityEntity>();

        [NotMapped, Map(nameof(CommodityCount))]
        public long CommodityCount => Commodities.Count;
    }
}
