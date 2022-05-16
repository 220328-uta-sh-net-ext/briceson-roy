using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using RestaurantAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RestaurantBL;
using RestaurantDL;
using RestaurantModel;


namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IBL bL;
        private IRepository _repository;
        private readonly IJWTManagerRepository repository;

        public AdminController(IBL bL, IJWTManagerRepository repository)
        {
            this.bL = bL;
            this.repository = repository;
        }
        
        [Authorize(Roles = "admin")]
        [HttpGet("All/Users")]
        [ProducesResponseType(200, Type = typeof(List<User>))]
        public ActionResult<List<User>> GetAllUsers()
        {
            var restaurntList = _repository.GetAllUsers();
            return Ok(restaurntList);
        }

        [Authorize(Roles = "admin")]
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

        [Authorize(Roles = "admin")]
        [HttpDelete("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Delete([FromQuery] string username)
        {
            if (username == null)
            {
                return BadRequest("Delete Cannot happen without a name");
            }
            bL.BanUser(username);
            return Ok($"Ok, {username} deleted");

        }
    }
}
