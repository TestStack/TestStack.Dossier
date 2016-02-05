using TestStack.Dossier.DataSources.Dictionaries;

// ReSharper disable once CheckNamespace
namespace TestStack.Dossier
{
    /// <summary>
    /// Extension methods that describe equivalence classes for generating anonymous Lorem Ipsum values.
    /// </summary>
    public static class LoremIpsumEquivalence
    {
        /// <summary>
        /// Generate and return a lorem ipsum value.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string LoremIpsum(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.LoremIpsum).Next();
        }

    }
}