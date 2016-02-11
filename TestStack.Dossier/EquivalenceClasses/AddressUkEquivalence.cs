using TestStack.Dossier.DataSources.Dictionaries;

// ReSharper disable once CheckNamespace
namespace TestStack.Dossier
{
    /// <summary>
    /// Methods that describe equivalence classes for generating anonymous UK address-related values.
    /// </summary>
    public class AddressUkEquivalence
    {
        private readonly AnonymousValueFixture _fixture;

        /// <summary>
        /// Creates a new <see cref="AddressUkEquivalence"/> with the AnonymousValueFixture from the extension method.
        /// </summary>
        /// <param name="fixture">The </param>
        public AddressUkEquivalence(AnonymousValueFixture fixture)
        {
            _fixture = fixture;
        }

        /// <summary>
        /// Generate and return a UK address city name.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string City()
        {
            return _fixture.Words(FromDictionary.AddressUkCity).Next();
        }

        /// <summary>
        /// Generate and return a UK address company name.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string Company()
        {
            return _fixture.Words(FromDictionary.AddressUkCompany).Next();
        }

        /// <summary>
        /// Generate and return a UK address county name.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string County()
        {
            return _fixture.Words(FromDictionary.AddressUkCounty).Next();
        }

        /// <summary>
        /// Generate and return a UK address phone number.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string Phone()
        {
            return _fixture.Words(FromDictionary.AddressUkPhone).Next();
        }

        /// <summary>
        /// Generate and return a UK address post code.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string PostCode()
        {
            return _fixture.Words(FromDictionary.AddressUkPostCode).Next();
        }

        /// <summary>
        /// Generate and return a UK address street name.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string Street()
        {
            return _fixture.Words(FromDictionary.AddressUkStreet).Next();
        }

        /// <summary>
        /// Generate and return a UK address website name.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string Website()
        {
            return _fixture.Words(FromDictionary.AddressUkWebsite).Next();
        }
    }
}