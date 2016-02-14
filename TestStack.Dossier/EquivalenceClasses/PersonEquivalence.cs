using TestStack.Dossier.DataSources.Dictionaries;

// ReSharper disable once CheckNamespace
namespace TestStack.Dossier
{
    /// <summary>
    /// Methods that describe equivalence classes for generating anonymous Person-related values.
    /// </summary>
    public class PersonEquivalence
    {
        private readonly AnonymousValueFixture _fixture;

        /// <summary>
        /// Creates a new <see cref="PersonEquivalence"/> with the AnonymousValueFixture from the extension method.
        /// </summary>
        /// <param name="fixture">The </param>
        public PersonEquivalence(AnonymousValueFixture fixture)
        {
            _fixture = fixture;
        }

        /// <summary>
        /// Generate and return a person email address.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string EmailAddress()
        {
            return _fixture.Words(FromDictionary.PersonEmailAddress).Next();
        }

        /// <summary>
        /// Generate and return a person language.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string Language()
        {
            return _fixture.Words(FromDictionary.PersonLanguage).Next();
        }

        /// <summary>
        /// Generate and return a person first name.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string NameFirst()
        {
            return _fixture.Words(FromDictionary.PersonNameFirst).Next();
        }

        /// <summary>
        /// Generate and return a person female first name.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string NameFirstFemale()
        {
            return _fixture.Words(FromDictionary.PersonNameFirstFemale).Next();
        }

        /// <summary>
        /// Generate and return a person male first name.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string NameFirstMale()
        {
            return _fixture.Words(FromDictionary.PersonNameFirstMale).Next();
        }

        /// <summary>
        /// Generate and return a person full name.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string NameFull()
        {
            return _fixture.Words(FromDictionary.PersonNameFull).Next();
        }

        /// <summary>
        /// Generate and return a person last name.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string NameLast()
        {
            return _fixture.Words(FromDictionary.PersonNameLast).Next();
        }

        /// <summary>
        /// Generate and return a person name suffix.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string NameSuffix()
        {
            return _fixture.Words(FromDictionary.PersonNameSuffix).Next();
        }

        /// <summary>
        /// Generate and return a person name title.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string NameTitle()
        {
            return _fixture.Words(FromDictionary.PersonNameTitle).Next();
        }

        /// <summary>
        /// Generate and return a person password.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string Password()
        {
            return _fixture.Words(FromDictionary.PersonPassword).Next();
        }

        /// <summary>
        /// Generate and return a person race.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string Race()
        {
            return _fixture.Words(FromDictionary.PersonRace).Next();
        }

        /// <summary>
        /// Generate and return a person user name.
        /// </summary>
        /// <returns>The generated value.</returns>
        public string Username()
        {
            return _fixture.Words(FromDictionary.PersonUsername).Next();
        }
    }
}