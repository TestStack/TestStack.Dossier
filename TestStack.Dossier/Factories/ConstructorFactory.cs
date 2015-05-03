using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Ploeh.AutoFixture;

namespace TestStack.Dossier.Factories
{
    /// <summary>
    /// Builds the object using the constructor with the most arguments.
    /// </summary>
    public class ConstructorFactory : IFactory
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
                .Select(x => CallGetWithType(x.Name, x.ParameterType, typeof(TObject), typeof(TBuilder), builder));

            return (TObject)longestConstructor.Invoke(parameterValues.ToArray());
        }

        private static object CallGetWithType(string propertyName, Type propertyType, Type objectType, Type builderType, object builder)
        {
            // Make a Func<TObj, TPropertyType>
            var expressionDelegateType = typeof(Func<,>).MakeGenericType(objectType, propertyType);
            var tObjParameterType = Expression.Parameter(objectType);

            var closedGenericGetMethod = builderType
                .GetMethods()
                .First(IsGenericGetMethod()) 
                .MakeGenericMethod(propertyType);
            var valueStoredInBuilder = closedGenericGetMethod.Invoke(builder, new object[]
                {
                    Expression.Lambda(
                        expressionDelegateType,
                        Expression.Property(tObjParameterType, propertyName),
                        tObjParameterType)
                });

            return valueStoredInBuilder;
        }

        private static Func<MethodInfo, bool> IsGenericGetMethod()
        {
            return method => method.Name == "Get" && method.ContainsGenericParameters && method.GetGenericArguments().Length == 1;
        }
    }
}