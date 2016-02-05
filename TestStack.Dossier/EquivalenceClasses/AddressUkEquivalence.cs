using TestStack.Dossier.DataSources.Dictionaries;

// ReSharper disable once CheckNamespace
namespace TestStack.Dossier
{
    /// <summary>
    /// Extension methods that describe equivalence classes for generating anonymous UK address-related values.
    /// </summary>
    public static class AddressUkEquivalence
    {
        /// <summary>
        /// Generate and return a UK address city name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string AddressUkCity(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.AddressUkCity).Next();
        }

        /// <summary>
        /// Generate and return a UK address company name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string AddressUkCompany(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.AddressUkCompany).Next();
        }

        /// <summary>
        /// Generate and return a UK address county name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string AddressUkCounty(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.AddressUkCounty).Next();
        }

        /// <summary>
        /// Generate and return a UK address phone number.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string AddressUkPhone(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.AddressUkPhone).Next();
        }

        /// <summary>
        /// Generate and return a UK address post code.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string AddressUkPostCode(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.AddressUkPostCode).Next();
        }

        /// <summary>
        /// Generate and return a UK address street name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string AddressUkStreet(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.AddressUkStreet).Next();
        }

        /// <summary>
        /// Generate and return a UK address website name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string AddressUkWebsite(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.AddressUkWebsite).Next();
        }

    }
}