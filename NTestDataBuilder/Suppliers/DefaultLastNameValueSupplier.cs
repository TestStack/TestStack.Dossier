using NTestDataBuilder.EquivalenceClasses;
using NTestDataBuilder.EquivalenceClasses.Person;

namespace NTestDataBuilder.Suppliers
{
    /// <summary>
    /// Supplies default anonymous value for last names.
    /// </summary>
    public class DefaultLastNameValueSupplier : IAnonymousValueSupplier
    {
        /// <inheritdoc />
        public bool CanSupplyValue<TObject, TValue>(string propertyName)
        {
            return typeof (TValue) == typeof(string) &&
                (propertyName.ToLower() == "lastname" || propertyName.ToLower() == "surname");
        }

        /// <inheritdoc />
        public TValue GenerateAnonymousValue<TObject, TValue>(AnonymousValueFixture any, string propertyName)
        {
            return (TValue) (object) any.LastName();
        }
    }
}
