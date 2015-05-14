using System;
using System.Linq;

namespace TestStack.Dossier.Factories
{
    /// <summary>
    /// Builds the object using the constructor with the most arguments using values stored in the builder that match
    ///   the constructor parameter name case insensitively.
    /// If there is no value specified in the builder for an argument then the builder will supply an anonymous value.
    /// </summary>
    public class CallConstructorFactory : IFactory
    {
        /// <inheritdoc />
        public virtual TObject BuildObject<TObject, TBuilder>(TestDataBuilder<TObject, TBuilder> builder)
            where TObject : class
            where TBuilder : TestDataBuilder<TObject, TBuilder>, new()
        {
            var longestConstructor = Reflector.GetLongestConstructor<TObject>();

            if (longestConstructor == null)
                throw new InvalidOperationException("Could not find callable constructor for class " + typeof(TObject).Name);

            var parameterValues = longestConstructor
                .GetParameters()
                .Select(x => Reflector.GetPropertyValueFromTestDataBuilder(x.Name, x.ParameterType, typeof(TObject), typeof(TBuilder), builder))
                .ToArray();

            return (TObject) longestConstructor.Invoke(parameterValues);
        }
    }
}