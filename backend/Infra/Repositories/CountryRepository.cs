using CountriesChallenge.Domain;
using CountriesChallenge.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CountriesChallenge.Infra.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly Context _context;
        private readonly DbSet<Country> _set;

        public CountryRepository(Context context)
        {
            _context = context;
            _set = context.Set<Country>();
        }

        public Country GetByCode(string code)
        {
            return _set.FirstOrDefault(x => x.Code.Equals(code));
        }

        public void Save(Country country)
        {
            if (country.Id == Guid.Empty)
                _set.Add(country);
            else
                _set.Update(country);

            _context.SaveChanges();
        }
    }
}
