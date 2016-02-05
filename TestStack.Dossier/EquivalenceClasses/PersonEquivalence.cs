using TestStack.Dossier.DataSources.Dictionaries;
using TestStack.Dossier.DataSources.Generators;

// ReSharper disable once CheckNamespace
namespace TestStack.Dossier
{
    /// <summary>
    /// Extension methods that describe equivalence classes for generating anonymous Person-related values.
    /// </summary>
    public static class PersonEquivalence
    {
        private static Words _personEmailAddressSource;
        private static Words _uniquePersonEmailAddressSource;

        /// <summary>
        /// Generate and return a unique email address (within the fixture).
        /// </summary>
        /// <param name="fixture">The fixture to generate a unique email for</param>
        /// <returns>The generated unique email</returns>
        public static string UniqueEmailAddress(this AnonymousValueFixture fixture)
        {
            if (_uniquePersonEmailAddressSource == null)
            {
                if (_personEmailAddressSource == null) _personEmailAddressSource = fixture.DictionaryFor(FromDictionary.PersonEmailAddress);
                var generator = new SequentialGenerator(0, _personEmailAddressSource.Data.Count, listShouldBeUnique: true);
                _uniquePersonEmailAddressSource = new Words(generator, new CachedFileDictionaryRepository(), FromDictionary.PersonEmailAddress);
            }

            return _uniquePersonEmailAddressSource.Next();
        }

        /// <summary>
        /// Generate and return a person email address.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string PersonEmailAddress(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.PersonEmailAddress).Next();
        }

        /// <summary>
        /// Generate and return a person language.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string PersonLanguage(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.PersonLanguage).Next();
        }

        /// <summary>
        /// Generate and return a person first name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string PersonNameFirst(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.PersonNameFirst).Next();
        }

        /// <summary>
        /// Generate and return a person female first name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string PersonNameFirstFemale(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.PersonNameFirstFemale).Next();
        }

        /// <summary>
        /// Generate and return a person male first name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string PersonNameFirstMale(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.PersonNameFirstMale).Next();
        }

        /// <summary>
        /// Generate and return a person full name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string PersonNameFull(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.PersonNameFull).Next();
        }

        /// <summary>
        /// Generate and return a person last name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string PersonNameLast(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.PersonNameLast).Next();
        }

        /// <summary>
        /// Generate and return a person name suffix.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string PersonNameSuffix(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.PersonNameSuffix).Next();
        }

        /// <summary>
        /// Generate and return a person name title.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string PersonNameTitle(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.PersonNameTitle).Next();
        }

        /// <summary>
        /// Generate and return a person password.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string PersonPassword(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.PersonPassword).Next();
        }

        /// <summary>
        /// Generate and return a person race.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string PersonRace(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.PersonRace).Next();
        }

        /// <summary>
        /// Generate and return a person user name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public static string PersonUsername(this AnonymousValueFixture fixture)
        {
            return fixture.DictionaryFor(FromDictionary.PersonUsername).Next();
        }

    }
}