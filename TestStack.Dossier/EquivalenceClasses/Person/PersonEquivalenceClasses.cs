﻿using TestStack.Dossier.DataSources.Generators;
using TestStack.Dossier.DataSources.Person;

namespace TestStack.Dossier.EquivalenceClasses.Person
{
    /// <summary>
    /// Extension methods that describe equivalence classes for generating anonymous person-related values.
    /// </summary>
    public static class NameEquivalenceClasses
    {
        private static PersonEmailAddressSource _personEmailAddressSource;
        private static PersonEmailAddressSource _uniquePersonEmailAddressSource;
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
        /// <param name="fixture">The fixture to generate a email for</param>
        /// <returns>The generated email</returns>
        public static string EmailAddress(this AnonymousValueFixture fixture)
        {
            if (_personEmailAddressSource == null) _personEmailAddressSource = new PersonEmailAddressSource();
            return _personEmailAddressSource.Next();
        }

        /// <summary>
        /// Generate and return a unique email address (within the fixture).
        /// </summary>
        /// <param name="fixture">The fixture to generate a unique email for</param>
        /// <returns>The generated unique email</returns>
        public static string UniqueEmailAddress(this AnonymousValueFixture fixture)
        {
            if (_uniquePersonEmailAddressSource == null)
            {
                if (_personEmailAddressSource == null) _personEmailAddressSource = new PersonEmailAddressSource();
                var generator = new SequentialGenerator(0, _personEmailAddressSource.Data.Count, listShouldBeUnique: true);
                _uniquePersonEmailAddressSource = new PersonEmailAddressSource(generator);
            }

            return _uniquePersonEmailAddressSource.Next();
        }

        /// <summary>
        /// Generate and return a language name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a language for</param>
        /// <returns>The generated language</returns>
        public static string Language(this AnonymousValueFixture fixture)
        {
            if (_personLanguageSource == null) _personLanguageSource = new PersonLanguageSource();
            return _personLanguageSource.Next();
        }

        /// <summary>
        /// Generate and return a female first name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a first name for</param>
        /// <returns>The generated female first name</returns>
        public static string FemaleFirstName(this AnonymousValueFixture fixture)
        {
            if (_personNameFirstFemaleSource == null) _personNameFirstFemaleSource = new PersonNameFirstFemaleSource();
            return _personNameFirstFemaleSource.Next();
        }

        /// <summary>
        /// Generate and return a male or female first name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a first name for</param>
        /// <returns>The generated first name</returns>
        public static string FirstName(this AnonymousValueFixture fixture)
        {
            if (_personNameFirstSource == null) _personNameFirstSource = new PersonNameFirstSource();
            return _personNameFirstSource.Next();
        }

        /// <summary>
        /// Generate and return a male or female full name (first and last names).
        /// </summary>
        /// <param name="fixture">The fixture to generate a full name for</param>
        /// <returns>The generated full name</returns>
        public static string FullName(this AnonymousValueFixture fixture)
        {
            if (_personNameFullSource == null) _personNameFullSource = new PersonNameFullSource();
            return _personNameFullSource.Next();
        }

        /// <summary>
        /// Generate and return a last name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a last name for</param>
        /// <returns>The generated last name</returns>
        public static string LastName(this AnonymousValueFixture fixture)
        {
            if (_personNameLastSource == null) _personNameLastSource = new PersonNameLastSource();
            return _personNameLastSource.Next();
        }

        /// <summary>
        /// Generate and return a male first name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a male first name for</param>
        /// <returns>The generated male first name</returns>
        public static string MaleFirstName(this AnonymousValueFixture fixture)
        {
            if (_personNameFirstMaleSource == null) _personNameFirstMaleSource = new PersonNameFirstMaleSource();
            return _personNameFirstMaleSource.Next();
        }

        /// <summary>
        /// Generate and return name suffix.
        /// </summary>
        /// <param name="fixture">The fixture to generate a suffix for</param>
        /// <returns>The generated suffix</returns>
        public static string Suffix(this AnonymousValueFixture fixture)
        {
            if (_personNameSuffixSource == null) _personNameSuffixSource = new PersonNameSuffixSource();
            return _personNameSuffixSource.Next();
        }

        /// <summary>
        /// Generate and return a name title.
        /// </summary>
        /// <param name="fixture">The fixture to generate a title for</param>
        /// <returns>The generated title</returns>
        public static string Title(this AnonymousValueFixture fixture)
        {
            if (_personNameTitleSource == null) _personNameTitleSource = new PersonNameTitleSource();
            return _personNameTitleSource.Next();
        }

    }

}
