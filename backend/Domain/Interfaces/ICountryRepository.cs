namespace CountriesChallenge.Domain.Interfaces
{
    public interface ICountryRepository
    {
        Country GetByCode(string code);
        void Save(Country country);
    }
}
