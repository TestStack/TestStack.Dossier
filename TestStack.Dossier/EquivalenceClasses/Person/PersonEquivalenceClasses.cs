namespace TestStack.Dossier.EquivalenceClasses.Person
{
    /// <summary>
    /// Extension methods that describe equivalence classes for generating anonymous person-related values.
    /// </summary>
    public static class NameEquivalenceClasses
    {
        /// <summary>
        /// Generate and return an email address.
        /// </summary>
        /// <param name="fixture">The fixture to generate a email for</param>
        /// <returns>The generated email</returns>
        public static string EmailAddress(this AnonymousValueFixture fixture)
        {
            return fixture.PersonEmailAddress();
        }

        /// <summary>
        /// Generate and return a unique email address (within the fixture).
        /// </summary>
        /// <param name="fixture">The fixture to generate a unique email for</param>
        /// <returns>The generated unique email</returns>
        public static string UniqueEmailAddress(this AnonymousValueFixture fixture)
        {
            return fixture.PersonUniqueEmailAddress();
        }

        /// <summary>
        /// Generate and return a language name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a language for</param>
        /// <returns>The generated language</returns>
        public static string Language(this AnonymousValueFixture fixture)
        {
            return fixture.PersonLanguage();
        }

        /// <summary>
        /// Generate and return a female first name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a first name for</param>
        /// <returns>The generated female first name</returns>
        public static string FemaleFirstName(this AnonymousValueFixture fixture)
        {
            return fixture.PersonNameFirstFemale();
        }

        /// <summary>
        /// Generate and return a male or female first name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a first name for</param>
        /// <returns>The generated first name</returns>
        public static string FirstName(this AnonymousValueFixture fixture)
        {
            return fixture.PersonNameFirst();
        }

        /// <summary>
        /// Generate and return a male or female full name (first and last names).
        /// </summary>
        /// <param name="fixture">The fixture to generate a full name for</param>
        /// <returns>The generated full name</returns>
        public static string FullName(this AnonymousValueFixture fixture)
        {
            return fixture.PersonNameFull();
        }

        /// <summary>
        /// Generate and return a last name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a last name for</param>
        /// <returns>The generated last name</returns>
        public static string LastName(this AnonymousValueFixture fixture)
        {
            return fixture.PersonNameLast();
        }

        /// <summary>
        /// Generate and return a male first name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a male first name for</param>
        /// <returns>The generated male first name</returns>
        public static string MaleFirstName(this AnonymousValueFixture fixture)
        {
            return fixture.PersonNameFirstMale();
        }

        /// <summary>
        /// Generate and return name suffix.
        /// </summary>
        /// <param name="fixture">The fixture to generate a suffix for</param>
        /// <returns>The generated suffix</returns>
        public static string Suffix(this AnonymousValueFixture fixture)
        {
            return fixture.PersonNameSuffix();
        }

        /// <summary>
        /// Generate and return a name title.
        /// </summary>
        /// <param name="fixture">The fixture to generate a title for</param>
        /// <returns>The generated title</returns>
        public static string Title(this AnonymousValueFixture fixture)
        {
            return fixture.PersonNameTitle();
        }
    }
}
