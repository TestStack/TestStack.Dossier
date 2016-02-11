using TestStack.Dossier.DataSources.Dictionaries;

// ReSharper disable once CheckNamespace
namespace TestStack.Dossier
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
            return fixture.Words(FromDictionary.ShirtSize).Next();
        }

    }
}
