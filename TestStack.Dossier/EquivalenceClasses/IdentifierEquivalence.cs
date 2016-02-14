using TestStack.Dossier.DataSources.Dictionaries;

// ReSharper disable once CheckNamespace
namespace TestStack.Dossier
{
    /// <summary>
    /// Methods that describe equivalence classes for generating anonymous Identifier-related values.
    /// </summary>
    public class IdentifierEquivalence
    {
        private readonly AnonymousValueFixture _fixture;

        /// <summary>
        /// Creates a new <see cref="IdentifierEquivalence"/> with the AnonymousValueFixture from the extension method.
        /// </summary>
        /// <param name="fixture">The </param>
        public IdentifierEquivalence(AnonymousValueFixture fixture)
        {
            _fixture = fixture;
        }

        /// <summary>
        /// Generate and return an identifier bitcoing address.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string BitcoinAddress()
        {
            return _fixture.Words(FromDictionary.IdentifierBitcoinAddress).Next();
        }

        /// <summary>
        /// Generate and return an identifier IBAN.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string Iban()
        {
            return _fixture.Words(FromDictionary.IdentifierIban).Next();
        }

        /// <summary>
        /// Generate and return an identifier IP address v4.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string IpAddressV4()
        {
            return _fixture.Words(FromDictionary.IdentifierIpAddressV4).Next();
        }

        /// <summary>
        /// Generate and return an identifier IP address v6.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string IpAddressV6()
        {
            return _fixture.Words(FromDictionary.IdentifierIpAddressV6).Next();
        }

        /// <summary>
        /// Generate and return an identifier ISBN.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string Isbn()
        {
            return _fixture.Words(FromDictionary.IdentifierIsbn).Next();
        }

        /// <summary>
        /// Generate and return an identifier MAC address.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string MacAddress()
        {
            return _fixture.Words(FromDictionary.IdentifierMacAddress).Next();
        }
    }
}