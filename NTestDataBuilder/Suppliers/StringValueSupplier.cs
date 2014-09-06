using System;

namespace NTestDataBuilder.Suppliers
{
    public class StringValueSupplier : IAnonymousValueSupplier
    {
        public bool CanSupplyValue<TObject, TValue>(string propertyName)
        {
            return typeof (TValue) == typeof(string);
        }

        public TValue GenerateAnonymousValue<TObject, TValue>(AnonymousValueFixture fixture, string propertyName)
        {
            return (TValue) (object) string.Format("{0}{1}", propertyName, Guid.NewGuid());
        }
    }
}
