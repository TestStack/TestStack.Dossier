using TestStack.Dossier.DataSources.Dictionaries;

// ReSharper disable once CheckNamespace
namespace TestStack.Dossier
{
    /// <summary>
    /// Extension methods that describe equivalence classes for generating anonymous Identifier-related values.
    /// </summary>
    public static class IdentifierEquivalence
    {
        /// <summary>
        /// Generate and return an identifier bitcoing address.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string IdentifierBitcoinAddress(this AnonymousValueFixture fixture)
        {
            return fixture.Words(FromDictionary.IdentifierBitcoinAddress).Next();
        }

        /// <summary>
        /// Generate and return an identifier IBAN.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string IdentifierIban(this AnonymousValueFixture fixture)
        {
            return fixture.Words(FromDictionary.IdentifierIban).Next();
        }

        /// <summary>
        /// Generate and return an identifier IP address v4.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string IdentifierIpAddressV4(this AnonymousValueFixture fixture)
        {
            return fixture.Words(FromDictionary.IdentifierIpAddressV4).Next();
        }

        /// <summary>
        /// Generate and return an identifier IP address v6.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string IdentifierIpAddressV6(this AnonymousValueFixture fixture)
        {
            return fixture.Words(FromDictionary.IdentifierIpAddressV6).Next();
        }

        /// <summary>
        /// Generate and return an identifier ISBN.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string IdentifierIsbn(this AnonymousValueFixture fixture)
        {
            return fixture.Words(FromDictionary.IdentifierIsbn).Next();
        }

        /// <summary>
        /// Generate and return an identifier MAC address.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string IdentifierMacAddress(this AnonymousValueFixture fixture)
        {
            return fixture.Words(FromDictionary.IdentifierMacAddress).Next();
        }
    }
}