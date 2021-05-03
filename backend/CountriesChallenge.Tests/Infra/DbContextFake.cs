using CountriesChallenge.Infra;
using Microsoft.EntityFrameworkCore;

namespace CountriesChallenge.Tests.Infra
{
    public static class DbContextFake
    {
        public static Context GetDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseInMemoryDatabase("InMemory");
            return new Context(optionsBuilder.Options);
        }
    }
}
