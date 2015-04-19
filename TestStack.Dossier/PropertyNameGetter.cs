using System;
using System.Linq.Expressions;

namespace TestStack.Dossier
{
    internal static class PropertyNameGetter
    {
        public static string Get<TObject, TValue>(Expression<Func<TObject, TValue>> property)
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
    }
}
