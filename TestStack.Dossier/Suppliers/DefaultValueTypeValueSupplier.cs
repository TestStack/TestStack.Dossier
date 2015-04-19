using Ploeh.AutoFixture;

namespace TestStack.Dossier.Suppliers
{
    /// <summary>
    /// Supplies default anonymous value for a value type e.g. int, double, etc.
    /// </summary>
    public class DefaultValueTypeValueSupplier : IAnonymousValueSupplier
    {
        /// <inerhitdoc />
        public bool CanSupplyValue<TObject, TValue>(string propertyName)
        {
            return typeof (TValue).IsValueType;
        }

        /// <inerhitdoc />
        public TValue GenerateAnonymousValue<TObject, TValue>(AnonymousValueFixture any, string propertyName)
        {
            return any.Fixture.Create<TValue>();
        }
    }
}
