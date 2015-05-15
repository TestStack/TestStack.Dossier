using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace TestStack.Dossier
{
    // todo: Cache reflection information once per type for decent performance when building a lot of objects
    internal static class Reflector
    {
        public static string GetPropertyNameFor<TObject, TValue>(Expression<Func<TObject, TValue>> property)
        {
            var memExp = property.Body as MemberExpression;
            if (memExp == null)
                throw new ArgumentException(
                    string.Format(
                        "Given property expression ({0}) didn't specify a property on {1}",
                        property,
                        typeof(TObject).Name
                    ),
                    "property"
                );

            return memExp.Member.Name;
        }

        public static PropertyInfo[] GetSettablePropertiesFor<T>()
        {
            return typeof (T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }

        public static ConstructorInfo GetLongestConstructor<T>()
        {
            return typeof (T)
                .GetConstructors()
                .OrderByDescending(x => x.GetParameters().Length)
                .FirstOrDefault();
        }

        public static object GetPropertyValueFromTestDataBuilder(string propertyName, Type propertyType, Type objectType, Type builderType, object builder)
        {
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
