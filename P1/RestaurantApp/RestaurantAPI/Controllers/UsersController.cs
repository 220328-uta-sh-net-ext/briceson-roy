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
        private IRepository _repository = new SqlRepository();
        private readonly IJWTManagerRepository repository;

        public UsersController(IJWTManagerRepository repository)
        {
            this.repository = repository;
            this.bL = bL;
        }


        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post([FromBody] User user)
        {
            if (user.Username == null || user.Password == null)
                Log.Error("Failed to create user due to bad input");
                return BadRequest("The Username and/or Password cannot be blank please add a valid username and/or password");
            _repository.AddUser(user);
            return CreatedAtAction("GetUserAccount", user);
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(User user)
        {
            var token = bL.Authenticate(user);

            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
