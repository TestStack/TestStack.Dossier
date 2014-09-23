using NTestDataBuilder.DataSources.Geography;

namespace NTestDataBuilder.EquivalenceClasses
{
    /// <summary>
    /// Extension methods that describe equivalence classes for generating anonymous geography-related values.
    /// </summary>
    public static class GeographyEquivalenceClassescs
    {
        private static GeoContinentSource _geoContinentSource;

        /// <summary>
        /// Generate and return a continent name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <returns>The generated string</returns>
        public static string GeoContinent(this AnonymousValueFixture fixture)
        {
            if (_geoContinentSource == null) _geoContinentSource = new GeoContinentSource();
            return _geoContinentSource.Next();
        }

        private static GeoCountrySource _geoCountrySource;

        /// <summary>
        /// Generate and return a country name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <returns>The generated string</returns>
        public static string GeoCountry(this AnonymousValueFixture fixture)
        {
            if (_geoCountrySource == null) _geoCountrySource = new GeoCountrySource();
            return _geoCountrySource.Next();
        }

    }
}
