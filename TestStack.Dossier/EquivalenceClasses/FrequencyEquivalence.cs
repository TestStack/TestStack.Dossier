using TestStack.Dossier.DataSources.Dictionaries;

namespace TestStack.Dossier.EquivalenceClasses
{
    /// <summary>
    /// Extension methods that describe equivalence classes for generating anonymous Frequency-related values.
    /// </summary>
    public static class FrequencyEquivalence
    {
        /// <summary>
        /// Generate and return a frequency.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string Frequency(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.Frequency).Next();
        }

    }
}