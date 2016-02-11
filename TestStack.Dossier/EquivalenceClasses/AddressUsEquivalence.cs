using TestStack.Dossier.DataSources.Dictionaries;

// ReSharper disable once CheckNamespace
namespace TestStack.Dossier
{
    /// <summary>
    /// Methods that describe equivalence classes for generating anonymous US adress-related values.
    /// </summary>
    public class AddressUsEquivalence
    {
        private readonly AnonymousValueFixture _fixture;

        /// <summary>
        /// Creates a new <see cref="AddressUsEquivalence"/> with the AnonymousValueFixture from the extension method.
        /// </summary>
        /// <param name="fixture">The </param>
        public AddressUsEquivalence(AnonymousValueFixture fixture)
        {
            _fixture = fixture;
        }

        /// <summary>
        /// Generate and return a US address city name.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string City()
        {
            return _fixture.Words(FromDictionary.AddressUsCity).Next();
        }

        /// <summary>
        /// Generate and return a US address company name.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string Company()
        {
            return _fixture.Words(FromDictionary.AddressUsCompany).Next();
        }

        /// <summary>
        /// Generate and return a US address phone number.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string Phone()
        {
            return _fixture.Words(FromDictionary.AddressUsPhone).Next();
        }

        /// <summary>
        /// Generate and return a US address social security number.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string SocialSecurityNumber()
        {
            return _fixture.Words(FromDictionary.AddressUsSocialSecurityNumber).Next();
        }

        /// <summary>
        /// Generate and return a US address state name.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string State()
        {
            return _fixture.Words(FromDictionary.AddressUsState).Next();
        }

        /// <summary>
        /// Generate and return a US address state abbreviation.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string StateAbbreviation()
        {
            return _fixture.Words(FromDictionary.AddressUsStateAbbreviation).Next();
        }

        /// <summary>
        /// Generate and return a US address street name.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string Street()
        {
            return _fixture.Words(FromDictionary.AddressUsStreet).Next();
        }

        /// <summary>
        /// Generate and return a US address website name.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string Website()
        {
            return _fixture.Words(FromDictionary.AddressUsWebsite).Next();
        }

        /// <summary>
        /// Generate and return a US address zip code.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string ZipCode()
        {
            return _fixture.Words(FromDictionary.AddressUsZipCode).Next();
        }
    }
}