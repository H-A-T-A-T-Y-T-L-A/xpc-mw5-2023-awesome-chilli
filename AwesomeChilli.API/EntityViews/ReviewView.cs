using AwesomeChilli.DAL.Entities;
using AwesomeChilli.DAL.Repositories;

namespace AwesomeChilli.API.EntityViews
{
    public class ReviewView : ViewBase<ReviewEntity>
    {
        public ReviewView()
        {
            Title = "";
            Description = "";
        }

        public ReviewView(ReviewEntity entity) : base(entity)
        {
            Stars = entity.Stars;
            Title = entity.Title;
            Description = entity.Description ?? "";
        }

        public double Stars { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CommodityId { get; set; }

        public override ReviewEntity MakeEntity()
        {
            CommodityEntity? commodity = null;
            if (Guid.TryParse(CommodityId, out Guid id))
                commodity = new CommodityRepository().Find(id);

            return new()
            {
                Stars = Stars,
                Title = Title,
                Description = Description,
                Commodity = commodity
            };
        }
    }
}
