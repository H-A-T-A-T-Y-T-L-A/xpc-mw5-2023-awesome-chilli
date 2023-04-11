using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AwesomeChilli.DAL;
using Entities = AwesomeChilli.DAL.Entities;
using Repositories = AwesomeChilli.DAL.Repositories;

namespace AwesomeChilli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        Repositories.ReviewRepository repository = new();

        [HttpGet("/Find[controller]")]
        public ActionResult<ReviewView> FindReview(Guid guid)
        {
            try
            {
                return Ok(new ReviewView(repository.Find(guid)));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("/Create[controller]")]
        public ActionResult<Guid> CreateReview(ReviewView newReview)
        {
            return Ok(repository.Create(newReview.MakeEntity()));
        }

        [HttpPost("/Update[controller]")]
        public ActionResult UpdateReview(ReviewView updatedReview)
        {
            try
            {
                repository.Update(updatedReview.MakeEntity());
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("/Delete[controller]")]
        public ActionResult DeleteReview(Guid guid)
        {
            try
            {
                repository.Delete(guid);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
