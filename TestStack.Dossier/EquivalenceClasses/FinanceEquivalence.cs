using TestStack.Dossier.DataSources.Dictionaries;

// ReSharper disable once CheckNamespace
namespace TestStack.Dossier
{
    /// <summary>
    /// Methods that describe equivalence classes for generating anonymous Finance-related values.
    /// </summary>
    public class FinanceEquivalence
    {
        private readonly AnonymousValueFixture _fixture;

        /// <summary>
        /// Creates a new <see cref="FinanceEquivalence"/> with the AnonymousValueFixture from the extension method.
        /// </summary>
        /// <param name="fixture">The </param>
        public FinanceEquivalence(AnonymousValueFixture fixture)
        {
            _fixture = fixture;
        }

        /// <summary>
        /// Generate and return a finance credit card number.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public string CreditCardNumber()
        {
            return _fixture.Words(FromDictionary.FinanceCreditCardNumber).Next();
        }

        /// <summary>
        /// Generate and return a finance credit card type.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public string CreditCardType()
        {
            return _fixture.Words(FromDictionary.FinanceCreditCardType).Next();
        }

        /// <summary>
        /// Generate and return a finance currency name.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public string Currency()
        {
            return _fixture.Words(FromDictionary.FinanceCurrency).Next();
        }

        /// <summary>
        /// Generate and return a finance currency code.
        /// </summary>
        /// <param name="fixture">The fixture to generate a value for.</param>
        /// <returns>The generated value.</returns>
        public string CurrencyCode()
        {
            return _fixture.Words(FromDictionary.FinanceCurrencyCode).Next();
        }

    }
}