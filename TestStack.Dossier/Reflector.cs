using System;
using System.Linq.Expressions;
using System.Reflection;

namespace TestStack.Dossier
{
    internal static class Reflector
    {
        public static string GetPropertyFor<TObject, TValue>(Expression<Func<TObject, TValue>> property)
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

        public static PropertyInfo[] GetSettablePropertiesFor<TObject>()
        {
            return typeof (TObject).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }
    }
}
