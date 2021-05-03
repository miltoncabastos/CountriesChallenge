using System;
using System.Text.Json;

namespace CountriesChallenge.Domain
{
    public class Country
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Capital { get; set; }
        public double Area { get; set; }
        public double Population { get; set; }        

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
