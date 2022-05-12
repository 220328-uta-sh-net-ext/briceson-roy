using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PokedexAPI.Controllers
{
    [Route("api/[controller]")]
    //decorator/attribute : its like processing the before the class or method
    [ApiController]
    public class PokedexController : ControllerBase
    {
        public string Get()
        {
            return "Hello, Pummelo!";
        }
    }
}
