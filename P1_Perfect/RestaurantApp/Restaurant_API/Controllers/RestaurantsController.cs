using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using RestaurantBL;
using RestaurantModel;
using Microsoft.Extensions.Caching.Memory;
using System.Data.SqlClient;
using RestaurantAPI.Repository;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IJWTManagerRepository repository;
        private IBL bL;
        private IMemoryCache memoryCache;

        public RestaurantsController(IBL bL, IMemoryCache memoryCache)
        {
            this.bL = bL;
            this.memoryCache = memoryCache;
            this.repository = repository;
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
                Log.Error($"Restaurant with the name, {name}, does not exist");
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
                Log.Error($"Restaurant with the name, {zip}, does not exist");
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
                Log.Error($"Restaurant with the name, {state}, does not exist");
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

        [HttpDelete("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Delete([FromQuery] string name)
        {
            if(name == null)
            {
                return BadRequest("Delete Cannot happen without a name");
            }
            bL.DeleteRestaurant(name);
            return Ok($"Ok, {name} deleted");

        }
    }
}
