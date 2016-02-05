using System;

namespace TestStack.Dossier.Suppliers
{
    /// <summary>
    /// Supplies default anonymous value for a string type.
    /// </summary>
    public class DefaultStringValueSupplier : IAnonymousValueSupplier
    {
        /// <inheritdoc />
        public bool CanSupplyValue(Type type, string propertyName)
        {
            return type == typeof(string);
        }

        /// <inheritdoc />
        public object GenerateAnonymousValue(AnonymousValueFixture any, Type type, string propertyName)
        {
            return any.StringStartingWith(propertyName);
        }
    }
}
