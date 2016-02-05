using TestStack.Dossier.DataSources.Dictionaries;

// ReSharper disable once CheckNamespace
namespace TestStack.Dossier
{
    /// <summary>
    /// Extension methods that describe equivalence classes for generating anonymous Geography-related values.
    /// </summary>
    public static class GeoEquivalence
    {
        /// <summary>
        /// Generate and return a geography continent name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string GeoContinent(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.GeoContinent).Next();
        }

        /// <summary>
        /// Generate and return a geography country name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string GeoCountry(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.GeoCountry).Next();
        }

        /// <summary>
        /// Generate and return a geography country code.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string GeoCountryCode(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.GeoCountryCode).Next();
        }

        /// <summary>
        /// Generate and return a geography latitude.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string GeoLatitude(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.GeoLatitude).Next();
        }

        /// <summary>
        /// Generate and return a geography longitude.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string GeoLongitude(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.GeoLongitude).Next();
        }

    }
}