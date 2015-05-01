using Ploeh.AutoFixture;

namespace TestStack.Dossier.BuildStrategies
{
    /// <summary>
    /// Creates an instance of an object by setting all public and private properties.
    /// </summary>
    public class AllProperties : IBuildStrategy
    {
        /// <inheritdoc />
        public TObject BuildObject<TObject, TBuilder>(TestDataBuilder<TObject, TBuilder> builder)
            where TObject : class
            where TBuilder : TestDataBuilder<TObject, TBuilder>, new()
        {
            var model = builder.Any.Fixture.Create<TObject>();

            var properties = Reflector.GetSettablePropertiesFor<TObject>();
            foreach (var property in properties)
            {
                if (property.CanWrite)
                {
                    var val = builder.Get(property.PropertyType, property.Name);
                    property.SetValue(model, val, null);
                }
            }

            return model;
        }
    }
}