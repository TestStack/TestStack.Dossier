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
        private static CompanySource _companySource;
        private static StreetSource _streetSource;
        private static CitySource _citySource;
        private static CountySource _countySource;
        private static PostCodeSource _postCodeSource;
        private static PhoneSource _phoneSource;
        private static EmailSource _emailSource;
        private static WebsiteSource _websiteSource;

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

        /// <summary>
        /// Generate and return a company name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <returns>The generated string</returns>
        public static string Company(this AnonymousValueFixture fixture)
        {
            if (_companySource == null) _companySource = new CompanySource();
            return _companySource.Next();
        }

        /// <summary>
        /// Generate and return a UK street name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <returns>The generated string</returns>
        public static string Street(this AnonymousValueFixture fixture)
        {
            if (_streetSource == null) _streetSource = new StreetSource();
            return _streetSource.Next();
        }

        /// <summary>
        /// Generate and return a city name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <returns>The generated string</returns>
        public static string City(this AnonymousValueFixture fixture)
        {
            if (_citySource == null) _citySource = new CitySource();
            return _citySource.Next();
        }

        /// <summary>
        /// Generate and return a UK county name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <returns>The generated string</returns>
        public static string County(this AnonymousValueFixture fixture)
        {
            if (_countySource == null) _countySource = new CountySource();
            return _countySource.Next();
        }

        /// <summary>
        /// Generate and return a UK post code.
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <returns>The generated string</returns>
        public static string PostCode(this AnonymousValueFixture fixture)
        {
            if (_postCodeSource == null) _postCodeSource = new PostCodeSource();
            return _postCodeSource.Next();
        }

        /// <summary>
        /// Generate and return a UK phone number.
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <returns>The generated string</returns>
        public static string Phone(this AnonymousValueFixture fixture)
        {
            if (_phoneSource == null) _phoneSource = new PhoneSource();
            return _phoneSource.Next();
        }

        /// <summary>
        /// Generate and return an email.
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <returns>The generated string</returns>
        public static string Email(this AnonymousValueFixture fixture)
        {
            if (_emailSource == null) _emailSource = new EmailSource();
            return _emailSource.Next();
        }

        /// <summary>
        /// Generate and return a website.
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <returns>The generated string</returns>
        public static string Website(this AnonymousValueFixture fixture)
        {
            if (_websiteSource == null) _websiteSource = new WebsiteSource();
            return _websiteSource.Next();
        }
    }

}
