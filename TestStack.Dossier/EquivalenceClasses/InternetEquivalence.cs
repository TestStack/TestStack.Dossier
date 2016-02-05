using TestStack.Dossier.DataSources.Dictionaries;

// ReSharper disable once CheckNamespace
namespace TestStack.Dossier
{
    /// <summary>
    /// Extension methods that describe equivalence classes for generating anonymous Internet-related values.
    /// </summary>
    public static class InternetEquivalence
    {
        /// <summary>
        /// Generate and return an internet domain country code top level domain.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string InternetDomainCountryCodeTopLevelDomain(this AnonymousValueFixture fixture)
        {
            return fixture.Words(FromDictionary.InternetDomainCountryCodeTopLevelDomain).Next();
        }

        /// <summary>
        /// Generate and return an internet domain name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string InternetDomainName(this AnonymousValueFixture fixture)
        {
            return fixture.Words(FromDictionary.InternetDomainName).Next();
        }

        /// <summary>
        /// Generate and return a an internet domain top level name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string InternetDomainTopLevel(this AnonymousValueFixture fixture)
        {
            return fixture.Words(FromDictionary.InternetDomainTopLevel).Next();
        }

        /// <summary>
        /// Generate and return an internet URL.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string InternetUrl(this AnonymousValueFixture fixture)
        {
            return fixture.Words(FromDictionary.InternetUrl).Next();
        }

    }
}