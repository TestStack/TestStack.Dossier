using NTestDataBuilder.DataSources.Person;

namespace NTestDataBuilder.EquivalenceClasses
{
    /// <summary>
    /// Extension methods that describe equivalence classes for generating anonymous person-related values.
    /// </summary>
    public static class NameEquivalenceClasses
    {
        private static PersonEmailAddressSource _personEmailAddressSource;
        private static PersonLanguageSource _personLanguageSource;
        private static PersonNameFirstFemaleSource _personNameFirstFemaleSource;
        private static PersonNameFirstSource _personNameFirstSource;
        private static PersonNameFullSource _personNameFullSource;
        private static PersonNameLastSource _personNameLastSource;
        private static PersonNameFirstMaleSource _personNameFirstMaleSource;
        private static PersonNameSuffixSource _personNameSuffixSource;
        private static PersonNameTitleSource _personNameTitleSource;

        /// <summary>
        /// Generate and return an email address.
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <returns>The generated string</returns>
        public static string PersonEmailAddress(this AnonymousValueFixture fixture)
        {
            if (_personEmailAddressSource == null) _personEmailAddressSource = new PersonEmailAddressSource();
            return _personEmailAddressSource.Next();
        }

        /// <summary>
        /// Generate and return a language name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <returns>The generated string</returns>
        public static string PersonLanguage(this AnonymousValueFixture fixture)
        {
            if (_personLanguageSource == null) _personLanguageSource = new PersonLanguageSource();
            return _personLanguageSource.Next();
        }

        /// <summary>
        /// Generate and return a female first name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <returns>The generated string</returns>
        public static string PersonNameFirstFemale(this AnonymousValueFixture fixture)
        {
            if (_personNameFirstFemaleSource == null) _personNameFirstFemaleSource = new PersonNameFirstFemaleSource();
            return _personNameFirstFemaleSource.Next();
        }

        /// <summary>
        /// Generate and return a male or female first name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <returns>The generated string</returns>
        public static string PersonNameFirst(this AnonymousValueFixture fixture)
        {
            if (_personNameFirstSource == null) _personNameFirstSource = new PersonNameFirstSource();
            return _personNameFirstSource.Next();
        }

        /// <summary>
        /// Generate and return a male or female full name (first and last names).
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <returns>The generated string</returns>
        public static string PersonNameFull(this AnonymousValueFixture fixture)
        {
            if (_personNameFullSource == null) _personNameFullSource = new PersonNameFullSource();
            return _personNameFullSource.Next();
        }

        /// <summary>
        /// Generate and return a last name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <returns>The generated string</returns>
        public static string PersonNameLast(this AnonymousValueFixture fixture)
        {
            if (_personNameLastSource == null) _personNameLastSource = new PersonNameLastSource();
            return _personNameLastSource.Next();
        }

        /// <summary>
        /// Generate and return a male first name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <returns>The generated string</returns>
        public static string PersonNameFirstMale(this AnonymousValueFixture fixture)
        {
            if (_personNameFirstMaleSource == null) _personNameFirstMaleSource = new PersonNameFirstMaleSource();
            return _personNameFirstMaleSource.Next();
        }

        /// <summary>
        /// Generate and return name suffix.
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <returns>The generated string</returns>
        public static string PersonNameSuffix(this AnonymousValueFixture fixture)
        {
            if (_personNameSuffixSource == null) _personNameSuffixSource = new PersonNameSuffixSource();
            return _personNameSuffixSource.Next();
        }

        /// <summary>
        /// Generate and return a name title.
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <returns>The generated string</returns>
        public static string PersonNameTitle(this AnonymousValueFixture fixture)
        {
            if (_personNameTitleSource == null) _personNameTitleSource = new PersonNameTitleSource();
            return _personNameTitleSource.Next();
        }

    }

}
