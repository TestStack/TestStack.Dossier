using System;
using System.Linq;
using System.Linq.Expressions;
using Ploeh.AutoFixture;

namespace TestStack.Dossier.ObjectBuilders
{
    /// <summary>
    /// Builds the object using the constructor with the most arguments.
    /// </summary>
    public class ConstructorObjectBuilder : IObjectBuilder
    {
        /// <inheritdoc />
        public TObject BuildObject<TObject, TBuilder>(TestDataBuilder<TObject, TBuilder> builder)
            where TObject : class
            where TBuilder : TestDataBuilder<TObject, TBuilder>, new()
        {
            var longestConstructor = typeof(TObject)
                .GetConstructors()
                .OrderByDescending(x => x.GetParameters().Length)
                .FirstOrDefault();

            if (longestConstructor == null) throw new ObjectCreationException();

            var parameterValues = longestConstructor
                .GetParameters()
                .Select(x => CallGetWithType(x.Name, x.ParameterType, typeof(TObject), typeof(TBuilder)));

            return (TObject)longestConstructor.Invoke(parameterValues.ToArray());
        }

        private object CallGetWithType(string propertyName, Type propertyType, Type objectType, Type builderType)
        {
            // Make a Func<TObj, TPropertyType>
            var expressionDelegateType = typeof(Func<,>).MakeGenericType(objectType, propertyType);

            // Make an expression parameter of type TObj
            var tObjParameterType = Expression.Parameter(objectType);

            var valueStoredInBuilder = builderType
                .GetMethods()
                .First(method => method.Name == "Get" && method.ContainsGenericParameters && method.GetGenericArguments().Length == 1)
                .MakeGenericMethod(propertyType)
                .Invoke(this, new object[]
                {
                    Expression.Lambda(
                        expressionDelegateType,
                        Expression.Property(tObjParameterType, propertyName),
                        tObjParameterType)
                });

            return valueStoredInBuilder;
        }

    }
}