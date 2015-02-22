using NTestDataBuilder.DataSources.Geography;

namespace NTestDataBuilder.EquivalenceClasses.Geo
{
    /// <summary>
    /// Extension methods that describe equivalence classes for generating anonymous geography-related values.
    /// </summary>
    public static class GeographyEquivalenceClassescs
    {
        private static GeoContinentSource _geoContinentSource;
        private static GeoCountrySource _geoCountrySource;
        private static GeoCountryCodeSource _geoCountryCodeSource;
        private static GeoLatitudeSource _geoLatitudeSource;
        private static GeoLongitudeSource _geoLongitudeSource;

        /// <summary>
        /// Generate and return a continent name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <returns>The generated string</returns>
        public static string Continent(this AnonymousValueFixture fixture)
        {
            if (_geoContinentSource == null) _geoContinentSource = new GeoContinentSource();
            return _geoContinentSource.Next();
        }

        /// <summary>
        /// Generate and return a country name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <returns>The generated string</returns>
        public static string Country(this AnonymousValueFixture fixture)
        {
            if (_geoCountrySource == null) _geoCountrySource = new GeoCountrySource();
            return _geoCountrySource.Next();
        }

        /// <summary>
        /// Generate and return a country code.
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <returns>The generated string</returns>
        public static string CountryCode(this AnonymousValueFixture fixture)
        {
            if (_geoCountryCodeSource == null) _geoCountryCodeSource = new GeoCountryCodeSource();
            return _geoCountryCodeSource.Next();
        }


        /// <summary>
        /// Generate and return a latitude coordinate.
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <returns>The generated string</returns>
        public static string Latitude(this AnonymousValueFixture fixture)
        {
            if (_geoLatitudeSource == null) _geoLatitudeSource = new GeoLatitudeSource();
            return _geoLatitudeSource.Next();
        }

        /// <summary>
        /// Generate and return a longitude coordinate.
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <returns>The generated string</returns>
        public static string Longitude(this AnonymousValueFixture fixture)
        {
            if (_geoLongitudeSource == null) _geoLongitudeSource = new GeoLongitudeSource();
            return _geoLongitudeSource.Next();
        }
    }
}
