using System;

namespace TestStack.Dossier.EquivalenceClasses.Geo
{
    /// <summary>
    /// Extension methods that describe equivalence classes for generating anonymous geography-related values.
    /// </summary>
    public static class GeographyEquivalenceClassescs
    {
        /// <summary>
        /// Generate and return a continent name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a continent for</param>
        /// <returns>The generated continent</returns>
        [Obsolete("Continent is deprecated, please use Geography.Continent instead.")]
        public static string Continent(this AnonymousValueFixture fixture)
        {
            return fixture.Geography.Continent();
        }

        /// <summary>
        /// Generate and return a country name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a country for</param>
        /// <returns>The generated country</returns>
        [Obsolete("Country is deprecated, please use Geography.Country instead.")]
        public static string Country(this AnonymousValueFixture fixture)
        {
            return fixture.Geography.Country();
        }

        /// <summary>
        /// Generate and return a country code.
        /// </summary>
        /// <param name="fixture">The fixture to generate a country code for</param>
        /// <returns>The generated country code</returns>
        [Obsolete("CountryCode is deprecated, please use Geography.CountryCode instead.")]
        public static string CountryCode(this AnonymousValueFixture fixture)
        {
            return fixture.Geography.CountryCode();
        }

        /// <summary>
        /// Generate and return a latitude coordinate.
        /// </summary>
        /// <param name="fixture">The fixture to generate a latitutde for</param>
        /// <returns>The generated latitude</returns>
        [Obsolete("Latitude is deprecated, please use Geography.Latitude instead.")]
        public static string Latitude(this AnonymousValueFixture fixture)
        {
            return fixture.Geography.Latitude();
        }

        /// <summary>
        /// Generate and return a longitude coordinate.
        /// </summary>
        /// <param name="fixture">The fixture to generate a longitude for</param>
        /// <returns>The generated longitude</returns>
        [Obsolete("Longitude is deprecated, please use Geography.Longitude instead.")]
        public static string Longitude(this AnonymousValueFixture fixture)
        {
            return fixture.Geography.Longitude();
        }
    }
}
