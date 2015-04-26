using System;
using TestStack.Dossier.EquivalenceClasses.Person;

namespace TestStack.Dossier.Suppliers
{
    /// <summary>
    /// Supplies default anonymous value for last names.
    /// </summary>
    public class DefaultLastNameValueSupplier : IAnonymousValueSupplier
    {
        /// <inheritdoc />
        public bool CanSupplyValue(Type type, string propertyName)
        {
            return type == typeof(string) &&
                (propertyName.ToLower() == "lastname" || propertyName.ToLower() == "surname");
        }

        /// <inheritdoc />
        public TValue GenerateAnonymousValue<TObject, TValue>(AnonymousValueFixture any, string propertyName)
        {
            return (TValue)(object)any.LastName();
        }

        /// <inheritdoc />
        public object GenerateAnonymousValue(AnonymousValueFixture any, Type type, string propertyName)
        {
            return any.LastName();
        }
    }
}
