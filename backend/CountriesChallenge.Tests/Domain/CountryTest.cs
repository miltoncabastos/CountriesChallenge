using CountriesChallenge.Domain;
using FluentAssertions;
using System;
using Xunit;

namespace CountriesChallenge.Tests.Domain
{
    public class CountryTest
    {
        [Fact]
        public void Should_return_exception_when_area_equal_zero()
        {
            var country = new Country();
            
            Action action = () => country.Area = 0;

            action.Should().ThrowExactly<ArgumentOutOfRangeException>()
                .WithMessage("Area must be greater zero (Parameter 'Area')");
        }

        [Fact]
        public void Should_return_exception_when_population_equal_zero()
        {
            var country = new Country();

            Action action = () => country.Population = 0;

            action.Should().ThrowExactly<ArgumentOutOfRangeException>()
                .WithMessage("Population must be greater zero (Parameter 'Population')");
        }

        [Fact]
        public void Should_return_exception_when_population_density_equal_zero()
        {
            var country = new Country();

            Action action = () => country.PopulationDensity = 0;

            action.Should().ThrowExactly<ArgumentOutOfRangeException>()
                .WithMessage("Population Density must be greater zero (Parameter 'PopulationDensity')");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Should_return_exception_when_capital_equal_spaces_or_null(string capital)
        {
            var country = new Country();

            Action action = () => country.Capital = capital;

            action.Should().ThrowExactly<ArgumentNullException>()
                .WithMessage("Capital must be informaded (Parameter 'Capital')");
        }
    }
}
