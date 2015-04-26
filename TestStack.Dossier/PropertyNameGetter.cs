using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

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

        public static ConstructorInfo GetConstructor(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            var ctors = type.GetConstructors()
                .OrderByDescending(x => x.GetParameters().Length)
                .ToArray();

            if (ctors.Length == 0)
                throw new InvalidOperationException(string.Format("The given type {0} does not contain any public constructors.", type.Name));

            if (ctors.Length > 1 && ctors[0].GetParameters().Length == ctors[1].GetParameters().Length)
                throw new InvalidOperationException(string.Format("Can't select best suited constructor between {0} and {1}.", GetConstructorSignature(ctors[0]), GetConstructorSignature(ctors[1])));

            return ctors[0];
        }

        public static string GetConstructorSignature(ConstructorInfo ctor)
        {
            var typeName = ctor.DeclaringType == null ? "" : ctor.DeclaringType.Name;
            return typeName + ctor.ToString().Substring("Void ".Length);
        }
    }
}
