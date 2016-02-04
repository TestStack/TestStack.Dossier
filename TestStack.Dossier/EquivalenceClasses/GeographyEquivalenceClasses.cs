using TestStack.Dossier.DataSources.Dictionaries;

// ReSharper disable once CheckNamespace
namespace TestStack.Dossier
{
    /// <summary>
    /// Extension methods that describe equivalence classes for generating anonymous geography-related values.
    /// </summary>
    public static class GeographyEquivalenceClasses
    {
        /// <summary>
        /// Generate and return a continent name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a continent for</param>
        /// <returns>The generated continent</returns>
        public static string Continent(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.GeoContinent).Next();
        }

        /// <summary>
        /// Generate and return a country name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a country for</param>
        /// <returns>The generated country</returns>
        public static string Country(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.GeoCountry).Next();
        }

        /// <summary>
        /// Generate and return a country code.
        /// </summary>
        /// <param name="fixture">The fixture to generate a country code for</param>
        /// <returns>The generated country code</returns>
        public static string CountryCode(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.GeoCountryCode).Next();
        }

        /// <summary>
        /// Generate and return a latitude coordinate.
        /// </summary>
        /// <param name="fixture">The fixture to generate a latitutde for</param>
        /// <returns>The generated latitude</returns>
        public static string Latitude(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.GeoLatitude).Next();
        }

        /// <summary>
        /// Generate and return a longitude coordinate.
        /// </summary>
        /// <param name="fixture">The fixture to generate a longitude for</param>
        /// <returns>The generated longitude</returns>
        public static string Longitude(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.GeoLongitude).Next();
        }
    }
}
