// ReSharper disable once CheckNamespace
namespace TestStack.Dossier
{
    /// <summary>
    /// Extension methods that describe equivalence classes for generating anonymous values.
    /// </summary>
    public static class Equivalence
    {
        /// <summary>
        /// Extension methods that describe equivalence classes for generating anonymous Australian address-related values.
        /// </summary>
        public static AddressAusEquivalence AddressAus(this AnonymousValueFixture fixture)
        {
            return new AddressAusEquivalence(fixture);
        }

        /// <summary>
        /// Extension methods that describe equivalence classes for generating anonymous United Kingdom address-related values.
        /// </summary>
        public static AddressUkEquivalence AddressUk(this AnonymousValueFixture fixture)
        {
            return new AddressUkEquivalence(fixture);
        }

        /// <summary>
        /// Extension methods that describe equivalence classes for generating anonymous United States address-related values.
        /// </summary>
        public static AddressUsEquivalence AddressUs(this AnonymousValueFixture fixture)
        {
            return new AddressUsEquivalence(fixture);
        }

        /// <summary>
        /// Extension methods that describe equivalence classes for generating anonymous colour-related values.
        /// </summary>
        public static ColourEquivalence Colour(this AnonymousValueFixture fixture)
        {
            return new ColourEquivalence(fixture);
        }

        /// <summary>
        /// Extension methods that describe equivalence classes for generating anonymous company-related values.
        /// </summary>
        public static CompanyEquivalence Company(this AnonymousValueFixture fixture)
        {
            return new CompanyEquivalence(fixture);
        }

        /// <summary>
        /// Extension methods that describe equivalence classes for generating anonymous finance-related values.
        /// </summary>
        public static FinanceEquivalence Finance(this AnonymousValueFixture fixture)
        {
            return new FinanceEquivalence(fixture);
        }
    }
}