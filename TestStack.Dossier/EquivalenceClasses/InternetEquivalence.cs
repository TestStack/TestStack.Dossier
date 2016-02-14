using TestStack.Dossier.DataSources.Dictionaries;

// ReSharper disable once CheckNamespace
namespace TestStack.Dossier
{
    /// <summary>
    /// Methods that describe equivalence classes for generating anonymous Internet-related values.
    /// </summary>
    public class InternetEquivalence
    {
        private readonly AnonymousValueFixture _fixture;

        /// <summary>
        /// Creates a new <see cref="InternetEquivalence"/> with the AnonymousValueFixture from the extension method.
        /// </summary>
        /// <param name="fixture">The </param>
        public InternetEquivalence(AnonymousValueFixture fixture)
        {
            _fixture = fixture;
        }

        /// <summary>
        /// Generate and return an internet domain country code top level domain.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string DomainCountryCodeTopLevelDomain()
        {
            return _fixture.Words(FromDictionary.InternetDomainCountryCodeTopLevelDomain).Next();
        }

        /// <summary>
        /// Generate and return an internet domain name.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string DomainName()
        {
            return _fixture.Words(FromDictionary.InternetDomainName).Next();
        }

        /// <summary>
        /// Generate and return a an internet domain top level name.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string DomainTopLevel()
        {
            return _fixture.Words(FromDictionary.InternetDomainTopLevel).Next();
        }

        /// <summary>
        /// Generate and return an internet URL.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string Url()
        {
            return _fixture.Words(FromDictionary.InternetUrl).Next();
        }
    }
}