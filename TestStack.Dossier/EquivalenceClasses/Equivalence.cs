// ReSharper disable once CheckNamespace
namespace TestStack.Dossier
{
    /// <summary>
    /// Equivalence classes for generating anonymous values.
    /// </summary>
    public partial class AnonymousValueFixture
    {
        /// <summary>
        /// Equivalence classes for generating anonymous Australian address-related values.
        /// </summary>
        public AddressAusEquivalence AddressAus
        {
            get { return new AddressAusEquivalence(this); }
        }

        /// <summary>
        /// Equivalence classes for generating anonymous United Kingdom address-related values.
        /// </summary>
        public AddressUkEquivalence AddressUk
        {
            get { return new AddressUkEquivalence(this);}
        }

        /// <summary>
        /// Equivalence classes for generating anonymous United States address-related values.
        /// </summary>
        public AddressUsEquivalence AddressUs
        {
            get { return new AddressUsEquivalence(this); }
        }

        /// <summary>
        /// Equivalence classes for generating anonymous colour-related values.
        /// </summary>
        public ColourEquivalence Colour
        {
            get { return new ColourEquivalence(this); }
        }

        /// <summary>
        /// Equivalence classes for generating anonymous company-related values.
        /// </summary>
        public CompanyEquivalence Company
        {
            get { return new CompanyEquivalence(this); }
        }

        /// <summary>
        /// Equivalence classes for generating anonymous finance-related values.
        /// </summary>
        public FinanceEquivalence Finance
        {
            get { return new FinanceEquivalence(this); }
        }

        /// <summary>
        /// Equivalence classes for generating anonymous geography-related values.
        /// </summary>
        public GeoEquivalence Geography
        {
            get { return new GeoEquivalence(this); }
        }

        /// <summary>
        /// Equivalence classes for generating anonymous identifier-related values.
        /// </summary>
        public IdentifierEquivalence Identifier
        {
            get { return new IdentifierEquivalence(this); }
        }

        /// <summary>
        /// Equivalence classes for generating anonymous internet-related values.
        /// </summary>
        public InternetEquivalence Internet
        {
            get { return new InternetEquivalence(this); }
        }

        /// <summary>
        /// Equivalence classes for generating anonymous person-related values.
        /// </summary>
        public PersonEquivalence Person
        {
            get { return new PersonEquivalence(this); }
        }
    }
}