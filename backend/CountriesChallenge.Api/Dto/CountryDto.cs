namespace CountriesChallenge.Dto
{
    public class CountryDto
    {
        public string NumericCode { get; set; }

        public float Area { get; set; }
        public float Population { get; set; }
        public float PopulationDensity { get; set; }
        public string Capital { get; set; }

        public string TopLevelDomains { get; set; }
        public string Name { get; set; }
    }
}
