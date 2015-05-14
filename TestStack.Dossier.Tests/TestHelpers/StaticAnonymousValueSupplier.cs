using System;

namespace TestStack.Dossier.Tests.TestHelpers
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

        public bool CanSupplyValue(Type type, string propertyName)
        {
            return type == _valueToSupply.GetType();
        }

        public TValue GenerateAnonymousValue<TObject, TValue>(AnonymousValueFixture any, string propertyName)
        {
            return (TValue) _valueToSupply;
        }

        public object GenerateAnonymousValue(AnonymousValueFixture any, Type type, string propertyName)
        {
            return _valueToSupply;
        }
    }
}
