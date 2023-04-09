﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AwesomeChilli.DAL;
using Entities = AwesomeChilli.DAL.Entities;
using Repositories = AwesomeChilli.DAL.Repositories;
using AwesomeChilli.API.EntityViews;

namespace AwesomeChilli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        Repositories.ReviewRepository repository = new();

        [HttpGet("/Find[controller]")]
        public ReviewView FindReview(Guid guid)
        {
            return new ReviewView(repository.Find(guid));
        }

        [HttpPost("/Create[controller]")]
        public Guid CreateReview(Entities.ReviewEntity newReview)
        {
            return repository.Create(newReview);
        }

        [HttpPost("/Update[controller]")]
        public void UpdateReview(Entities.ReviewEntity updatedReview)
        {
            repository.Update(updatedReview);
        }

        [HttpPost("/Delete[controller]")]
        public void DeleteReview(Guid guid)
        {
            repository.Delete(guid);
        }
    }
}
