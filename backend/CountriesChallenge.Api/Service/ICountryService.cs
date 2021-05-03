using CountriesChallenge.Dto;

namespace CountriesChallenge.Service
{
    public interface ICountryService
    {
        CountryDto GetByCode(string code);
        void Save(CountryDto countryDto);
    }
}
