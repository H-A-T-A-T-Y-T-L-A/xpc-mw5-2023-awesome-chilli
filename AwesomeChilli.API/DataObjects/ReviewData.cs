using AwesomeChilli.DAL;
using AwesomeChilli.DAL.Entities;
using AwesomeChilli.DAL.Repositories;

namespace AwesomeChilli.API.EntityViews
{
    public class ReviewData : DataObjectBase<ReviewEntity>
    {
        public ReviewData()
        {
            Title = "";
            Description = "";
            CommodityId = "";
        }

        [Map(nameof(ReviewEntity.Stars))]
        public double Stars { get; set; }

        [Map(nameof(ReviewEntity.Title))]
        public string Title { get; set; }

        [Map(nameof(ReviewEntity.Description))]
        public string Description { get; set; }

        public string CommodityId { get; set; }
    }
}
