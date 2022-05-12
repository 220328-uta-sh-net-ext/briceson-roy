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
    public class RestaurantsController : ControllerBase
    {
        private IBL bL;
        private IMemoryCache memoryCache;

        public RestaurantsController(IBL bL, IMemoryCache memoryCache)
        {
            this.bL = bL;
            this.memoryCache = memoryCache;
        }


        [HttpGet("All/Restaurants")]
        [ProducesResponseType(200, Type = typeof(List<Restaurant>))]
        public ActionResult<List<Restaurant>> GetAllRestaurants()
        {
            var restaurntList = bL.GetAllRestaurants();
            return Ok(restaurntList);
        }  

        [HttpGet("SearchByName")]
        [ProducesResponseType(200, Type = typeof(Restaurant))]
        [ProducesResponseType(404)]
        public ActionResult<List<Restaurant>> GetRestaurantByName(string name)
        {
            var filteredRestaurant = bL.SearchRestaurants(name);    
            if (filteredRestaurant.Count <= 0)
            {
                return NotFound("The Restaurant in question does not exist");
            }
            return Ok(filteredRestaurant);
        }


        [HttpGet("SearchByZip")]
        [ProducesResponseType(200, Type = typeof(Restaurant))]
        [ProducesResponseType(404)]
        public ActionResult<List<Restaurant>> GetRestaurantByZip(int zip)
        {
            var filteredRestaurant = bL.SearchRestaurantByZipCode(zip);
            if (filteredRestaurant.Count <= 0)
            {
                return NotFound("The Restaurant in question does not exist");
            }
            return Ok(filteredRestaurant);
        }

        [HttpGet("SearchByState")]
        [ProducesResponseType(200, Type = typeof(Restaurant))]
        [ProducesResponseType(404)]
        public ActionResult<List<Restaurant>> GetRestaurantByState(string state)
        {
            var filteredRestaurant = bL.SearchRestaurantsByState(state);
            if (filteredRestaurant.Count <= 0)
            {
                return NotFound("The Restaurant in question does not exist");
            }
            return Ok(filteredRestaurant);
        }


        [HttpPost("Add/Restaurant")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post([FromBody] Restaurant restaurant)
        {
            if (restaurant == null)
                return BadRequest("Bad Restaurant Input. Try Again...");
            bL.AddRestaurant(restaurant);
            return CreatedAtAction("GetRestaurantByName", restaurant);
        }
    }
}
