using NTestDataBuilder.DataSources;

namespace NTestDataBuilder.EquivalenceClasses
{
    public static class PersonEquivalenceClasses
    {
        private static readonly FirstNameSource _firstNameSource = new FirstNameSource();
        private static readonly LastNameSource _lastNameSource = new LastNameSource();
        private static readonly FullNameSource _fullNameSource = new FullNameSource();

        public static string FirstName(this AnonymousValueFixture fixture)
        {
            return _firstNameSource.Next();
        }
        public static string LastName(this AnonymousValueFixture fixture)
        {
            return _lastNameSource.Next();
        }
        public static string FullName(this AnonymousValueFixture fixture)
        {
            return _fullNameSource.Next();
        }

    }

}
