using TestStack.Dossier.DataSources.Dictionaries;

// ReSharper disable once CheckNamespace
namespace TestStack.Dossier
{
    /// <summary>
    /// Methods that describe equivalence classes for generating anonymous Colour-related values.
    /// </summary>
    public class ColourEquivalence
    {
        private readonly AnonymousValueFixture _fixture;

        /// <summary>
        /// Creates a new <see cref="ColourEquivalence"/> with the AnonymousValueFixture from the extension method.
        /// </summary>
        /// <param name="fixture">The </param>
        public ColourEquivalence(AnonymousValueFixture fixture)
        {
            _fixture = fixture;
        }

        /// <summary>
        /// Generate and return a Colour Hex value.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string Hex()
        {
            return _fixture.Words(FromDictionary.ColourHex).Next();
        }

        /// <summary>
        /// Generate and return a Colour name.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string Name()
        {
            return _fixture.Words(FromDictionary.ColourName).Next();
        }
    }
}