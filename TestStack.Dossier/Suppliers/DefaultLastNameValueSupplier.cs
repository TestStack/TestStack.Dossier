using System;

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
        public object GenerateAnonymousValue(AnonymousValueFixture any, Type type, string propertyName)
        {
            return any.PersonNameLast();
        }
    }
}
