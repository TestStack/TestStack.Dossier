using System.Reflection;

namespace TestStack.Dossier.Factories
{
    /// <summary>
    /// Creates an instance of an object by setting all public properties but not private properties.
    /// </summary>
    public class PublicPropertySettersFactory : CallConstructorFactory
    {
        /// <inheritdoc />
        public override TObject BuildObject<TObject, TBuilder>(TestDataBuilder<TObject, TBuilder> builder)
        {
            var model = base.BuildObject(builder);

            var properties = Reflector.GetSettablePropertiesFor<TObject>();
            foreach (var property in properties)
            {
                if (PropertySetterIsPublic(property))
                {
                    var val = builder.Get(property.PropertyType, property.Name);
                    property.SetValue(model, val, null);
                }
            }

            return model;
        }

        private static bool PropertySetterIsPublic(PropertyInfo property)
        {
            return property.CanWrite && property.GetSetMethod() != null;
        }
    }
}