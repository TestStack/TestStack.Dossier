using System;

namespace TestStack.Dossier.EquivalenceClasses.Person
{
    /// <summary>
    /// Extension methods that describe equivalence classes for generating anonymous person-related values.
    /// </summary>
    public static class PersonEquivalenceClasses
    {
        /// <summary>
        /// Generate and return an email address.
        /// </summary>
        /// <param name="fixture">The fixture to generate a email for</param>
        /// <returns>The generated email</returns>
        [Obsolete("EmailAddress is deprecated, please use Person.EmailAddress instead.")]
        public static string EmailAddress(this AnonymousValueFixture fixture)
        {
            return fixture.Person.EmailAddress();
        }

        /// <summary>
        /// Generate and return a unique email address (within the fixture).
        /// </summary>
        /// <param name="fixture">The fixture to generate a unique email for</param>
        /// <returns>The generated unique email</returns>
        [Obsolete("UniqueEmailAddress is deprecated, please use Person.UniqueEmailAddress instead.")]
        public static string UniqueEmailAddress(this AnonymousValueFixture fixture)
        {
            return fixture.Person.UniqueEmailAddress();
        }

        /// <summary>
        /// Generate and return a language name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a language for</param>
        /// <returns>The generated language</returns>
        [Obsolete("Language is deprecated, please use Person.Language instead.")]
        public static string Language(this AnonymousValueFixture fixture)
        {
            return fixture.Person.Language();
        }

        /// <summary>
        /// Generate and return a female first name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a first name for</param>
        /// <returns>The generated female first name</returns>
        [Obsolete("FemaleFirstName is deprecated, please use Person.NameFirstFemale instead.")]
        public static string FemaleFirstName(this AnonymousValueFixture fixture)
        {
            return fixture.Person.NameFirstFemale();
        }

        /// <summary>
        /// Generate and return a male or female first name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a first name for</param>
        /// <returns>The generated first name</returns>
        [Obsolete("FirstName is deprecated, please use Person.NameFirst instead.")]
        public static string FirstName(this AnonymousValueFixture fixture)
        {
            return fixture.Person.NameFirst();
        }

        /// <summary>
        /// Generate and return a male or female full name (first and last names).
        /// </summary>
        /// <param name="fixture">The fixture to generate a full name for</param>
        /// <returns>The generated full name</returns>
        [Obsolete("FullName is deprecated, please use Person.NameFull instead.")]
        public static string FullName(this AnonymousValueFixture fixture)
        {
            return fixture.Person.NameFull();
        }

        /// <summary>
        /// Generate and return a last name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a last name for</param>
        /// <returns>The generated last name</returns>
        [Obsolete("LastName is deprecated, please use Person.NameLast instead.")]
        public static string LastName(this AnonymousValueFixture fixture)
        {
            return fixture.Person.NameLast();
        }

        /// <summary>
        /// Generate and return a male first name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a male first name for</param>
        /// <returns>The generated male first name</returns>
        [Obsolete("MaleFirstName is deprecated, please use Person.NameFirstMale instead.")]
        public static string MaleFirstName(this AnonymousValueFixture fixture)
        {
            return fixture.Person.NameFirstMale();
        }

        /// <summary>
        /// Generate and return name suffix.
        /// </summary>
        /// <param name="fixture">The fixture to generate a suffix for</param>
        /// <returns>The generated suffix</returns>
        [Obsolete("Suffix is deprecated, please use Person.NameSuffix instead.")]
        public static string Suffix(this AnonymousValueFixture fixture)
        {
            return fixture.Person.NameSuffix();
        }

        /// <summary>
        /// Generate and return a name title.
        /// </summary>
        /// <param name="fixture">The fixture to generate a title for</param>
        /// <returns>The generated title</returns>
        [Obsolete("Title is deprecated, please use Person.Title instead.")]
        public static string Title(this AnonymousValueFixture fixture)
        {
            return fixture.Person.NameTitle();
        }
    }
}
