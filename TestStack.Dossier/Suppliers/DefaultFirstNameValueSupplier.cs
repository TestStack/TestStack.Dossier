using System;
using TestStack.Dossier.EquivalenceClasses;

namespace TestStack.Dossier.Suppliers
{
    /// <summary>
    /// Supplies default anonymous value for first names.
    /// </summary>
    public class DefaultFirstNameValueSupplier : IAnonymousValueSupplier
    {
        /// <inheritdoc />
        public bool CanSupplyValue(Type type, string propertyName)
        {
            return type == typeof(string) && propertyName.ToLower() == "firstname";
        }

        /// <inheritdoc />
        public object GenerateAnonymousValue(AnonymousValueFixture any, Type type, string propertyName)
        {
            return any.Person.NameFirst();
        }
    }
}
