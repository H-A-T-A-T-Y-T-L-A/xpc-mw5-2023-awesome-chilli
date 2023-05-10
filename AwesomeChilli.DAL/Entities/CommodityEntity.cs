using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Queries = AwesomeChilli.DAL.Queries;

namespace AwesomeChilli.DAL.Entities
{
    public class CommodityEntity : EntityBase, Queries.GetByName.INamedEntity
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

        [Map(nameof(Category), Method = MapMethod.EntityId)]
        public CategoryEntity? Category { get; set; }

        [Map(nameof(Manufacturer), Method = MapMethod.EntityId)]
        public ManufacturerEntity? Manufacturer { get; set; }
        public ICollection<ReviewEntity> Reviews { get; set; } = new List<ReviewEntity>();

        [NotMapped, Map(nameof(CategoryName))]
        public string CategoryName => Category?.Name ?? "";

        [NotMapped, Map(nameof(ManufacturerName))]
        public string ManufacturerName => Manufacturer?.Name ?? "";

        [NotMapped, Map(nameof(ReviewsAverage))]
        public double ReviewsAverage => Reviews.Any() ? Reviews.Average(x => x.Stars) : 0;
    }
}
