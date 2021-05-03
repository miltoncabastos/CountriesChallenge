using CountriesChallenge.Dto;
using CountriesChallenge.Service;
using Microsoft.AspNetCore.Mvc;

namespace CountriesChallenge.Controllers
{
    [ApiController]    
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("{numericCode}")]
        public IActionResult GetByNumericCode(string numericCode)
        {
            var country = _countryService.GetByCode(numericCode);

            if (country == null)
                return NoContent();

            return Ok(country);
        }

        [HttpPost]
        public IActionResult Save([FromBody] CountryDto country)
        {
            _countryService.Save(country);
            return NoContent();
        }
    }  
}
