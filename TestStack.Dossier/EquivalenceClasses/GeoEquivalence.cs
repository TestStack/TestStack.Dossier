using TestStack.Dossier.DataSources.Dictionaries;

// ReSharper disable once CheckNamespace
namespace TestStack.Dossier
{
    /// <summary>
    /// Methods that describe equivalence classes for generating anonymous Geography-related values.
    /// </summary>
    public class GeoEquivalence
    {
        private readonly AnonymousValueFixture _fixture;

        /// <summary>
        /// Creates a new <see cref="GeoEquivalence"/> with the AnonymousValueFixture from the extension method.
        /// </summary>
        /// <param name="fixture">The </param>
        public GeoEquivalence(AnonymousValueFixture fixture)
        {
            _fixture = fixture;
        }

        /// <summary>
        /// Generate and return a geography continent name.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string Continent()
        {
            return _fixture.Words(FromDictionary.GeoContinent).Next();
        }

        /// <summary>
        /// Generate and return a geography country name.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string Country()
        {
            return _fixture.Words(FromDictionary.GeoCountry).Next();
        }

        /// <summary>
        /// Generate and return a geography country code.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string CountryCode()
        {
            return _fixture.Words(FromDictionary.GeoCountryCode).Next();
        }

        /// <summary>
        /// Generate and return a geography latitude.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string Latitude()
        {
            return _fixture.Words(FromDictionary.GeoLatitude).Next();
        }

        /// <summary>
        /// Generate and return a geography longitude.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string Longitude()
        {
            return _fixture.Words(FromDictionary.GeoLongitude).Next();
        }
    }
}