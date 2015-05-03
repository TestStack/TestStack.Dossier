using Ploeh.AutoFixture;

namespace TestStack.Dossier.Factories
{
    /// <summary>
    /// Creates an instance of an object by setting all public properties but not private properties.
    /// </summary>
    public class PublicPropertiesFactory : IFactory
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
                if (property.CanWrite && property.GetSetMethod().IsPublic)
                {
                    var val = builder.Get(property.PropertyType, property.Name);
                    property.SetValue(model, val, null);
                }
            }

            return model;
        }
    }
}