using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using RestaurantBL;
using RestaurantModel;
using Microsoft.Extensions.Caching.Memory;
using System.Data.SqlClient;



namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private IBL bL;
        private readonly IMemoryCache _memoryCache;


        public ReviewController(IBL bL, IMemoryCache memoryCache)
        {
            this.bL = bL;
            this._memoryCache = memoryCache;
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
                return NotFound("No Reviews exist for this restaurant currently exist...");
            }
            return Ok(filteredReviews);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post([FromBody] Review review)
        {
           ;
            if (review.Rating < 0 || review.Rating > 5)
                BadRequest("Review Rating must be between 0-5");
            bL.AddReview(review);
            return CreatedAtAction("GetReviewsById", review);
        }
    }
}
