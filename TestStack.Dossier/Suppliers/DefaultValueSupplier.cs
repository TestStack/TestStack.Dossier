namespace TestStack.Dossier.Suppliers
{
    /// <summary>
    /// Supplies default value for any type.
    /// </summary>
    public class DefaultValueSupplier : IAnonymousValueSupplier
    {
        /// <inheritdoc />
        public bool CanSupplyValue<TObject, TValue>(string propertyName)
        {
            return true;
        }

        /// <inheritdoc />
        public TValue GenerateAnonymousValue<TObject, TValue>(AnonymousValueFixture any, string propertyName)
        {
            return default(TValue);
        }
    }
}
