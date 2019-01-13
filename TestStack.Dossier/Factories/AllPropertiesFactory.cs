using AutoFixture;

namespace TestStack.Dossier.Factories
{
    /// <summary>
    /// Builds the object using the constructor with the most arguments using values stored in the builder that match
    ///   the constructor parameter name case insensitively and then sets all public and private property setters with
    ///   values from the builder.
    /// If there is no value specified in the builder for a ctor argument / property then the builder will supply an anonymous value.
    /// </summary>
    public class AllPropertiesFactory : CallConstructorFactory
    {
        /// <inheritdoc />
        public override TObject BuildObject<TObject, TBuilder>(TestDataBuilder<TObject, TBuilder> builder)
        {
            var model = base.BuildObject(builder);

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