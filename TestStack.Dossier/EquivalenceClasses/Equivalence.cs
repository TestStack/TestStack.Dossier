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
        /// Equivalence classes for generating anonymous frequency-related values.
        /// </summary>
        public FrequencyEquivalence Frequency
        {
            get { return new FrequencyEquivalence(this); }
        }
    }
}