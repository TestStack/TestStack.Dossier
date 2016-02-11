using TestStack.Dossier.DataSources.Dictionaries;

// ReSharper disable once CheckNamespace
namespace TestStack.Dossier
{
    /// <summary>
    /// Methods that describe equivalence classes for generating anonymous Australian address-related values.
    /// </summary>
    public class AddressAusEquivalence
    {
        private readonly AnonymousValueFixture _fixture;

        /// <summary>
        /// Creates a new <see cref="AddressAusEquivalence"/> with the AnonymousValueFixture from the extension method.
        /// </summary>
        /// <param name="fixture">The </param>
        public AddressAusEquivalence(AnonymousValueFixture fixture)
        {
            _fixture = fixture;
        }

        /// <summary>
        /// Generate and return an Australian address city name.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string City()
        {
            return _fixture.Words(FromDictionary.AddressAusCity).Next();
        }

        /// <summary>
        /// Generate and return an Australian address company name.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string Company()
        {
            return _fixture.Words(FromDictionary.AddressAusCompany).Next();
        }

        /// <summary>
        /// Generate and return an Australian address phone number.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string Phone()
        {
            return _fixture.Words(FromDictionary.AddressAusPhone).Next();
        }

        /// <summary>
        /// Generate and return an Australian address post code.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string PostCode()
        {
            return _fixture.Words(FromDictionary.AddressAusPostCode).Next();
        }

        /// <summary>
        /// Generate and return an Australian address state name.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string State()
        {
            return _fixture.Words(FromDictionary.AddressAusState).Next();
        }

        /// <summary>
        /// Generate and return an Australian address state abbreviation.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string StateAbbreviation()
        {
            return _fixture.Words(FromDictionary.AddressAusStateAbbreviation).Next();
        }

        /// <summary>
        /// Generate and return an Australian address street name.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string Street()
        {
            return _fixture.Words(FromDictionary.AddressAusStreet).Next();
        }

        /// <summary>
        /// Generate and return an Australian address website name.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string Website()
        {
            return _fixture.Words(FromDictionary.AddressAusWebsite).Next();
        }
    }
}