using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using RestaurantBL;
using RestaurantModel;
using Microsoft.Extensions.Caching.Memory;
using RestaurantAPI.Repository;
using System.Data.SqlClient;



namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IJWTManagerRepository repository;
        private IBL bL;
        private readonly IMemoryCache _memoryCache;


        public ReviewController(IBL bL, IMemoryCache memoryCache)
        {
            this.bL = bL;
            this._memoryCache = memoryCache;
            this.repository = repository;
        }



        [HttpGet("All/Reviews")]
        [ProducesResponseType(200, Type = typeof(List<Review>))]
        public ActionResult<List<Review>> GetAllReviews()
        {
            var reviewList = bL.GetAllReviews();
            return Ok(reviewList);
        }


        [HttpGet("GetByRestaurant")]
        [ProducesResponseType(200, Type = typeof(Review))]
        [ProducesResponseType(404)]
        public ActionResult<List<Review>> GetReviewsById(int id)
        {
            var filteredReviews = bL.GetReviewsById(id);
            if (filteredReviews.Count <= 0)
            {
                Log.Error("No Reviews exist for this restaurant currently exist...");
                return NotFound("No Reviews exist for this restaurant currently exist...");
            }
            Log.Information("New reviw Successfully added");
            return Ok(filteredReviews);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post([FromBody] Review review)
        {
           ;
            if (review.Rating < 0 || review.Rating > 5)
                Log.Error("Bad Rating Request Made");
                BadRequest("Review Rating must be between 0-5");
            bL.AddReview(review);
            return CreatedAtAction("GetReviewsById", review);
        }
    }
}
