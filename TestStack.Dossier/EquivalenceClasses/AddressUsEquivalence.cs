using TestStack.Dossier.DataSources.Dictionaries;

namespace TestStack.Dossier.EquivalenceClasses
{
    /// <summary>
    /// Extension methods that describe equivalence classes for generating anonymous US adress-related values.
    /// </summary>
    public static class AddressUsEquivalence
    {
        /// <summary>
        /// Generate and return a US address city name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string AddressUsCity(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.AddressUsCity).Next();
        }

        /// <summary>
        /// Generate and return a US address company name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string AddressUsCompany(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.AddressUsCompany).Next();
        }

        /// <summary>
        /// Generate and return a US address phone number.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string AddressUsPhone(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.AddressUsPhone).Next();
        }

        /// <summary>
        /// Generate and return a US address social security number.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string AddressUsSocialSecurityNumber(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.AddressUsSocialSecurityNumber).Next();
        }

        /// <summary>
        /// Generate and return a US address state name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string AddressUsState(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.AddressUsState).Next();
        }

        /// <summary>
        /// Generate and return a US address state abbreviation.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string AddressUsStateAbbreviation(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.AddressUsStateAbbreviation).Next();
        }

        /// <summary>
        /// Generate and return a US address street name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string AddressUsStreet(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.AddressUsStreet).Next();
        }

        /// <summary>
        /// Generate and return a US address website name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string AddressUsWebsite(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.AddressUsWebsite).Next();
        }

        /// <summary>
        /// Generate and return a US address zip code.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string AddressUsZipCode(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.AddressUsZipCode).Next();
        }
    }
}