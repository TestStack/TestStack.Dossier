using NTestDataBuilder.DataSources;

namespace NTestDataBuilder.EquivalenceClasses
{
    /// <summary>
    /// Extension methods that describe equivalence classes for generating anonymous person-related values.
    /// </summary>
    public static class PersonEquivalenceClasses
    {
        private static FirstNameSource _firstNameSource;
        private static LastNameSource _lastNameSource;
        private static FullNameSource _fullNameSource;

        /// <summary>
        /// Generate and return a first name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <returns>The generated string</returns>
        public static string FirstName(this AnonymousValueFixture fixture)
        {
            if(_firstNameSource == null) _firstNameSource = new FirstNameSource();
            return _firstNameSource.Next();
        }

        /// <summary>
        /// Generate and return a last name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <returns>The generated string</returns>
        public static string LastName(this AnonymousValueFixture fixture)
        {
            if (_lastNameSource == null) _lastNameSource = new LastNameSource();
            return _lastNameSource.Next();
        }

        /// <summary>
        /// Generate and return a first and last name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <returns>The generated string</returns>
        public static string FullName(this AnonymousValueFixture fixture)
        {
            if (_fullNameSource == null) _fullNameSource = new FullNameSource();
            return _fullNameSource.Next();
        }
    }

}
