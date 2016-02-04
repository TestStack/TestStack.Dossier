using System;
using TestStack.Dossier.EquivalenceClasses;

namespace TestStack.Dossier.Suppliers
{
    /// <summary>
    /// Supplies default anonymous value for email addresses.
    /// </summary>
    public class DefaultEmailValueSupplier : IAnonymousValueSupplier
    {
        /// <inheritdoc />
        public bool CanSupplyValue(Type type, string propertyName)
        {
            return type == typeof(string) && propertyName.ToLower().Contains("email");
        }

        /// <inheritdoc />
        public object GenerateAnonymousValue(AnonymousValueFixture any, Type type, string propertyName)
        {
            return any.EmailAddress();
        }
    }
}
