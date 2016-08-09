using TestStack.Dossier.DataSources.Dictionaries;
using TestStack.Dossier.DataSources.Generators;

// ReSharper disable once CheckNamespace
namespace TestStack.Dossier
{
    /// <summary>
    /// Extension methods that describe equivalence classes for generating anonymous Person-related values.
    /// </summary>
    public static class PersonEquivalenceExtensions
    {
        private static Words _uniquePersonEmailAddressSource;
        private static readonly AnonymousValueFixture Fixture = new AnonymousValueFixture();

        /// <summary>
        /// Generate and return a unique email address (within the fixture).
        /// </summary>
        /// <param name="personEquivalence">The fixture to generate a unique email for</param>
        /// <returns>The generated unique email</returns>
        public static string UniqueEmailAddress(this PersonEquivalence personEquivalence)
        {
            if (_uniquePersonEmailAddressSource == null)
            {
                InitializeUniqueEmailAddressSource();
            }

            return _uniquePersonEmailAddressSource.Next();
        }

        internal static void InitializeUniqueEmailAddressSource()
        {
            var recordCount = Fixture.Words(FromDictionary.PersonEmailAddress).Data.Count;
            var generator = new SequentialGenerator(0, recordCount, listShouldBeUnique: true);
            _uniquePersonEmailAddressSource = new Words(generator, new CachedFileDictionaryRepository(),
                FromDictionary.PersonEmailAddress);
        }
    }
}