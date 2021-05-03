using System;
using System.Text.Json;

namespace CountriesChallenge.Domain
{
    public class Country
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        private float _area;
        public float Area
        {
            get => _area;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(Area), "Area must be greater zero");
                _area = value;
            }
        }

        private float _population;
        public float Population
        {
            get => _population;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(Population), "Population must be greater zero");
                _population = value;
            }
        }

        private float _populationDensity;
        public float PopulationDensity
        {
            get => _populationDensity;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(PopulationDensity),"Population Density must be greater zero");
                _populationDensity = value;
            }
        }

        private string _capital;
        public string Capital
        {
            get => _capital;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(Capital), "Capital must be informaded");
                _capital = value;
            }
        }

        public string CountryInfo { get; private set; }
        private void SetCountryInfo()
        {
            var countryInfo = new CountryInfo
            {
                Name = Name,
                TopLevelDomains = TopLevelDomains
            };            

            CountryInfo = JsonSerializer.Serialize(countryInfo);
        }


        private string _name;
        public string Name
        {
            get 
            {
                if (!string.IsNullOrEmpty(_name))
                    return _name;

                if (!string.IsNullOrEmpty(CountryInfo))
                {
                    var countryInfo = JsonSerializer.Deserialize<CountryInfo>(CountryInfo);
                    return countryInfo.Name;
                }

                return string.Empty;
            }
            set
            {
                _name = value;
                SetCountryInfo();
            }
        }

        private string _topLevelDomains;
        public string TopLevelDomains
        {
            get
            {
                if (!string.IsNullOrEmpty(_topLevelDomains))
                    return _topLevelDomains;

                if (!string.IsNullOrEmpty(CountryInfo))
                {
                    var countryInfo = JsonSerializer.Deserialize<CountryInfo>(CountryInfo);
                    return countryInfo.TopLevelDomains;
                }

                return string.Empty;
            }
            set
            {
                _topLevelDomains = value;
                SetCountryInfo();
            }
        }
    }
}
