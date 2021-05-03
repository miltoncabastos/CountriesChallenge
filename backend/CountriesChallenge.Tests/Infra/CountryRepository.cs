using Bogus;
using CountriesChallenge.Domain;
using CountriesChallenge.Infra.Repositories;
using FluentAssertions;
using Xunit;

namespace CountriesChallenge.Tests.Infra
{
    public class CountryRepositoryTest
    {
        [Fact]
        public void Should_return_coutry_when_informed_code()
        {
            var context = DbContextFake.GetDbContext();

            var countryFake = new Faker<Country>("pt_BR")
                .RuleFor(x => x.Id, f => f.Random.Guid())
                .RuleFor(x => x.Name, f => f.Address.County())
                .RuleFor(x => x.Capital, f => f.Address.City())
                .RuleFor(x => x.Code, f => f.Address.CountryCode())
                .RuleFor(x => x.Population, f => f.Random.Float(150000, 2000000))
                .RuleFor(x => x.PopulationDensity, f => f.Random.Float(10, 50))
                .RuleFor(x => x.TopLevelDomains, f => f.Internet.DomainSuffix())
                .Generate();

            context.Add(countryFake);
            context.SaveChanges();

            var repository = new CountryRepository(context);

            var result = repository.GetByCode(countryFake.Code);

            result.Should().BeEquivalentTo(countryFake);
        }
    }
}
