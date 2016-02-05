using TestStack.Dossier.DataSources.Dictionaries;

// ReSharper disable once CheckNamespace
namespace TestStack.Dossier
{
    /// <summary>
    /// Extension methods that describe equivalence classes for generating anonymous Colour-related values.
    /// </summary>
    public static class ColourEquivalence
    {
        /// <summary>
        /// Generate and return a Colour Hex value.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string ColourHex(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.ColourHex).Next();
        }

        /// <summary>
        /// Generate and return a Colour name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string ColourName(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.ColourName).Next();
        }
    }
}