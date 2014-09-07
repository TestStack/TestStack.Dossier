namespace NTestDataBuilder.Tests.TestHelpers
{
    public class StaticAnonymousValueSupplier : IAnonymousValueSupplier
    {
        private readonly object _valueToSupply;

        public StaticAnonymousValueSupplier(object valueToSupply)
        {
            _valueToSupply = valueToSupply;
        }

        public bool CanSupplyValue<TObject, TValue>(string propertyName)
        {
            return typeof(TValue) == _valueToSupply.GetType();
        }

        public TValue GenerateAnonymousValue<TObject, TValue>(AnonymousValueFixture fixture, string propertyName)
        {
            return (TValue) _valueToSupply;
        }
    }
}
