using TestStack.Dossier.DataSources.Dictionaries;

// ReSharper disable once CheckNamespace
namespace TestStack.Dossier
{
    /// <summary>
    /// Extension methods that describe equivalence classes for generating anonymous Australian address-related values.
    /// </summary>
    public static class AddressAusEquivalence
    {
        /// <summary>
        /// Generate and return an Australian address city name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string AddressAusCity(this AnonymousValueFixture fixture)
        {
            return fixture.Words(FromDictionary.AddressAusCity).Next();
        }

        /// <summary>
        /// Generate and return an Australian address company name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string AddressAusCompany(this AnonymousValueFixture fixture)
        {
            return fixture.Words(FromDictionary.AddressAusCompany).Next();
        }

        /// <summary>
        /// Generate and return an Australian address phone number.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string AddressAusPhone(this AnonymousValueFixture fixture)
        {
            return fixture.Words(FromDictionary.AddressAusPhone).Next();
        }

        /// <summary>
        /// Generate and return an Australian address post code.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string AddressAusPostCode(this AnonymousValueFixture fixture)
        {
            return fixture.Words(FromDictionary.AddressAusPostCode).Next();
        }

        /// <summary>
        /// Generate and return an Australian address state name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string AddressAusState(this AnonymousValueFixture fixture)
        {
            return fixture.Words(FromDictionary.AddressAusState).Next();
        }

        /// <summary>
        /// Generate and return an Australian address state abbreviation.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string AddressAusStateAbbreviation(this AnonymousValueFixture fixture)
        {
            return fixture.Words(FromDictionary.AddressAusStateAbbreviation).Next();
        }

        /// <summary>
        /// Generate and return an Australian address street name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string AddressAusStreet(this AnonymousValueFixture fixture)
        {
            return fixture.Words(FromDictionary.AddressAusStreet).Next();
        }

        /// <summary>
        /// Generate and return an Australian address website name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string AddressAusWebsite(this AnonymousValueFixture fixture)
        {
            return fixture.Words(FromDictionary.AddressAusWebsite).Next();
        }

    }
}