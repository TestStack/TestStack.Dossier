namespace NTestDataBuilder.Suppliers
{
    /// <summary>
    /// Supplies default value for the value type.
    /// </summary>
    public class DefaultValueSupplier : IAnonymousValueSupplier
    {
        /// <inheritdoc />
        public bool CanSupplyValue<TObject, TValue>(string propertyName)
        {
            return true;
        }

        /// <inheritdoc />
        public TValue GenerateAnonymousValue<TObject, TValue>(AnonymousValueFixture fixture, string propertyName)
        {
            return default(TValue);
        }
    }
}
