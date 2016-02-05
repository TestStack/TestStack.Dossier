using TestStack.Dossier.DataSources.Dictionaries;

namespace TestStack.Dossier.EquivalenceClasses
{
    /// <summary>
    /// Extension methods that describe equivalence classes for generating anonymous Shirt Size-related values.
    /// </summary>
    public static class ShirtSizeEquivalence
    {
        /// <summary>
        /// Generate and return a shirt size.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string ShirtSize(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.ShirtSize).Next();
        }

    }


}
