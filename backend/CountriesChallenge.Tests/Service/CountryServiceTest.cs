using Bogus;
using CountriesChallenge.Domain;
using CountriesChallenge.Domain.Interfaces;
using CountriesChallenge.Service;
using FluentAssertions;
using Moq;
using Xunit;

namespace CountriesChallenge.Tests.Service
{
    public class CountryServiceTest
    {
        [Fact]
        public void Should_return_country_when_code_ok()
        {
            // Arrange
            var countryFake = new Faker<Country>("pt_BR")
                .RuleFor(x => x.Id, f => f.Random.Guid())
                .RuleFor(x => x.Name, f => f.Address.County())
                .RuleFor(x => x.Capital, f => f.Address.City())
                .RuleFor(x => x.Code, f => f.Address.CountryCode())
                .RuleFor(x => x.Population, f => f.Random.Float(150000, 2000000))
                .RuleFor(x => x.PopulationDensity, f => f.Random.Float(10, 50))
                .RuleFor(x => x.TopLevelDomains, f => f.Internet.DomainSuffix())
                .Generate();

            var repository = new Mock<ICountryRepository>();
            repository.Setup(f => f.GetByCode(countryFake.Code)).Returns(countryFake);

            var service = new CountryService(repository.Object);

            // Act
            var result = service.GetByCode(countryFake.Code);

            // Assert
            result.NumericCode.Should().Be(countryFake.Code);
        }
    }
}
