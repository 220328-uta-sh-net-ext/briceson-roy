using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantModel;
using RestaurantAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using RestaurantBL;
using RestaurantDL;


namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IBL bL;
        private IRepository _repository;
        private readonly IJWTManagerRepository repository;

        public UsersController(IJWTManagerRepository repository, IBL bL)
        {
            this.repository = repository;
            this.bL = bL;
        }


        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post([FromQuery] string userName, string password)
        {
            User user = new()
            {
                Username = userName,
                Password = password
            };
            if (user.Username == null || user.Password == null)
            {
                Log.Error("Failed to create user due to bad input");
                return BadRequest("The Username and/or Password cannot be blank please add a valid username and/or password");
            }
                
            _repository.AddUser(user);
            Log.Information("New user successfully created.");
            return Ok("User Account successfully created.");
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate([FromQuery] string userName, string password)
        {
            User user = new()
            {
                Username = userName,
                Password = password
            };
            var token = bL.Authenticate(user);
            if (token == null)
            {
                Log.Error("Unauthorized activity detected");
                return Unauthorized();
            }
            Log.Information("Token successfully issued");
            return Ok(token);
        }
    }
}
