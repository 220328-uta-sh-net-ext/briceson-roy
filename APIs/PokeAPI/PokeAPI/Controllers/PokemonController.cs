using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PokeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        public string Get()
        {
            return "Hello, Pummelo!";
        }
    }
}
