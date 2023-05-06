using AwesomeChilli.DAL;
using AwesomeChilli.DAL.Entities;
using AwesomeChilli.DAL.Repositories;

namespace AwesomeChilli.API.DataTransferObjects
{
    public class ReviewData : DataObjectBase<ReviewEntity>
    {
        [Map(nameof(ReviewEntity.Stars))]
        public double Stars { get; set; }

        [Map(nameof(ReviewEntity.Title))]
        public string Title { get; set; } = "";

        [Map(nameof(ReviewEntity.Description))]
        public string Description { get; set; } = "";

        [Map(nameof(ReviewEntity.Commodity), Method = MapMethod.EntityId)]
        public string CommodityId { get; set; } = "";
    }
}
