using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AwesomeChilli.DAL;
using Entities = AwesomeChilli.DAL.Entities;
using Repositories = AwesomeChilli.DAL.Repositories;
using AwesomeChilli.API.DataTransferObjects;
using AwesomeChilli.DAL.Entities;
using AwesomeChilli.DAL.Repositories;
using AwesomeChilli.API.DataMappers;
using AwesomeChilli.DAL.Queries;

namespace AwesomeChilli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : RepositoryControllerBase<ReviewEntity, ReviewData>
    {
        public ReviewController(IRepository<ReviewEntity> repository, Mapper<ReviewEntity, ReviewData> mapper, GetAllQuery<ReviewEntity> getAllQuery) : base(repository, mapper, getAllQuery)
        {
        }
    }
}
