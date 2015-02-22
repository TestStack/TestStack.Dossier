using NTestDataBuilder.EquivalenceClasses;
using NTestDataBuilder.EquivalenceClasses.Person;

namespace NTestDataBuilder.Suppliers
{
    /// <summary>
    /// Supplies default anonymous value for email addresses.
    /// </summary>
    public class DefaultEmailValueSupplier : IAnonymousValueSupplier
    {
        /// <inheritdoc />
        public bool CanSupplyValue<TObject, TValue>(string propertyName)
        {
            return typeof (TValue) == typeof(string) && propertyName.ToLower().Contains("email");
        }

        /// <inheritdoc />
        public TValue GenerateAnonymousValue<TObject, TValue>(AnonymousValueFixture any, string propertyName)
        {
            return (TValue) (object) any.EmailAddress();
        }
    }
}
