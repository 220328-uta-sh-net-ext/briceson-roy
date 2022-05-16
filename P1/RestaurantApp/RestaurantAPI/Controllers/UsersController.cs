using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantModel;
using RestaurantAPI.Repository;
using Microsoft.AspNetCore.Authorization;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IJWTManagerRepository repository;
        public UsersController(IJWTManagerRepository repository)
        {
            this.repository = repository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(User user)
        {
            var token = repository.Authenticate(user);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
