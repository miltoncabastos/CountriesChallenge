using CountriesChallenge.Domain;
using CountriesChallenge.Domain.Interfaces;
using CountriesChallenge.Dto;

namespace CountriesChallenge.Service
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public CountryDto GetByCode(string code)
        {
            var country = _countryRepository.GetByCode(code);

            if (country == null) return default;

            return new CountryDto
            {
                NumericCode = country.Code,
                Capital = country.Capital,
                Area = country.Area,
                Population = country.Population,
                Name = country.Name,
                TopLevelDomains = country.TopLevelDomains
            };
        }

        public void Save(CountryDto countryDto)
        {
            var country = _countryRepository.GetByCode(countryDto.NumericCode);

            if (country == null)
                country = new Country();

            MountCountry(country, countryDto);

            _countryRepository.Save(country);
        }

        private Country MountCountry(Country country, CountryDto countryDto)
        {
            country.Code = countryDto.NumericCode;
            country.Capital = countryDto.Capital;
            country.Area = countryDto.Area;
            country.Population = countryDto.Population;
            country.Name = countryDto.Name;
            country.TopLevelDomains = countryDto.TopLevelDomains;

            return country;
        }
    }
}
