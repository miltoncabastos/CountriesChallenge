using Microsoft.AspNetCore.Mvc;

namespace CountriesChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OpenApiController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("https://github.com/miltoncabastos/countries-challenge");
        }

    }
}
