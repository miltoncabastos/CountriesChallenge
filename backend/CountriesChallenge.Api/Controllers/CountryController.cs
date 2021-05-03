using CountriesChallenge.Dto;
using CountriesChallenge.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CountriesChallenge.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/country")]
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
            if (string.IsNullOrEmpty(numericCode))
                return NoContent();

            return Execute(() => _countryService.GetByCode(numericCode));
        }

        [HttpPost]
        public IActionResult Save([FromBody] CountryDto country)
        {
            return Execute(() =>
            {
                _countryService.Save(country);
                return true;
            });
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }  
}
