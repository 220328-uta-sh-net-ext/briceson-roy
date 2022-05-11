using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RestaurantBL;
using RestaurantModel;


namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IBL bL;
        private readonly IMemoryCache memoryCache;

        public UsersController(IBL bL, IMemoryCache memoryCache)
        {
            this.bL = bL;
            this.memoryCache = memoryCache;
        }

        [HttpGet("All/Users")]
        [ProducesResponseType(200, Type = typeof(List<User>))]
        public ActionResult<List<User>> GetAllUser()
        {
            var restaurntList = new List<User>();
            return Ok(restaurntList);
        }


        [HttpGet("Username")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(404)]
        public ActionResult<List<User>> GetUserAccount(string name)
        {
            var filteredUsers = bL.GetUserAccounts(name);
            if (filteredUsers.Count <= 0)
            {
                return NotFound("User in Question does not exist...");
            }
            return Ok(filteredUsers);
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post([FromBody] User user)
        {
            if (user.Username == null || user.Password == null)
                return BadRequest("The Username and/or Password cannot be blank please add a valid username and/or password");
            bL.AddUser(user);
            return CreatedAtAction("Get", user);
        }
    }
}
