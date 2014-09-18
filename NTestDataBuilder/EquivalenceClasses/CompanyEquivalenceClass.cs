using NTestDataBuilder.DataSources;

namespace NTestDataBuilder.EquivalenceClasses
{
    public static class CompanyEquivalenceClass
    {
        private static readonly CompanySource _companySource = new CompanySource();

        public static string Company(this AnonymousValueFixture fixture)
        {
            return _companySource.Next();
        }
    }
}
