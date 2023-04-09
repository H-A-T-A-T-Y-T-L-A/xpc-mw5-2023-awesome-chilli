using AwesomeChilli.DAL.Entities;

namespace AwesomeChilli.API.EntityViews
{
    public class ReviewView : ViewBase<ReviewEntity>
    {
        public ReviewView(ReviewEntity entity) : base(entity)
        {
            Stars = entity.Stars;
            Title = entity.Title;
            Description = entity.Description ?? "";
        }

        public double Stars { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
