using TestStack.Dossier.DataSources.Dictionaries;

// ReSharper disable once CheckNamespace
namespace TestStack.Dossier
{
    /// <summary>
    /// Methods that describe equivalence classes for generating anonymous Company-related values.
    /// </summary>
    public class CompanyEquivalence
    {
        private readonly AnonymousValueFixture _fixture;

        /// <summary>
        /// Creates a new <see cref="CompanyEquivalence"/> with the AnonymousValueFixture from the extension method.
        /// </summary>
        /// <param name="fixture">The </param>
        public CompanyEquivalence(AnonymousValueFixture fixture)
        {
            _fixture = fixture;
        }

        /// <summary>
        /// Generate and return a company industry name.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string Industry()
        {
            return _fixture.Words(FromDictionary.CompanyIndustry).Next();
        }

        /// <summary>
        /// Generate and return a company job title.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string JobTitle()
        {
            return _fixture.Words(FromDictionary.CompanyJobTitle).Next();
        }

        /// <summary>
        /// Generate and return a company location name.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string Location()
        {
            return _fixture.Words(FromDictionary.CompanyLocation).Next();
        }

        /// <summary>
        /// Generate and return a company name.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string Name()
        {
            return _fixture.Words(FromDictionary.CompanyName).Next();
        }
    }
}