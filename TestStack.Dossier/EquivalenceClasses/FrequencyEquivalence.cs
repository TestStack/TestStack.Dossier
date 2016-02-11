using TestStack.Dossier.DataSources.Dictionaries;

// ReSharper disable once CheckNamespace
namespace TestStack.Dossier
{
    /// <summary>
    /// Methods that describe equivalence classes for generating anonymous Frequency-related values.
    /// </summary>
    public class FrequencyEquivalence
    {
        private readonly AnonymousValueFixture _fixture;

        /// <summary>
        /// Creates a new <see cref="FrequencyEquivalence"/> with the AnonymousValueFixture from the extension method.
        /// </summary>
        /// <param name="fixture">The </param>
        public FrequencyEquivalence(AnonymousValueFixture fixture)
        {
            _fixture = fixture;
        }

        /// <summary>
        /// Generate and return a frequency.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string Frequency()
        {
            return _fixture.Words(FromDictionary.Frequency).Next();
        }
    }
}