using TestStack.Dossier.EquivalenceClasses.Person;

namespace TestStack.Dossier.Suppliers
{
    /// <summary>
    /// Supplies default anonymous value for first names.
    /// </summary>
    public class DefaultFirstNameValueSupplier : IAnonymousValueSupplier
    {
        /// <inheritdoc />
        public bool CanSupplyValue<TObject, TValue>(string propertyName)
        {
            return typeof (TValue) == typeof(string) && propertyName.ToLower() == "firstname";
        }

        /// <inheritdoc />
        public TValue GenerateAnonymousValue<TObject, TValue>(AnonymousValueFixture any, string propertyName)
        {
            return (TValue) (object) any.FirstName();
        }
    }
}
