using System;
using System.Linq;
using System.Reflection;
using AutoFixture;
using AutoFixture.Kernel;

namespace TestStack.Dossier.Suppliers
{
    /// <summary>
    /// Supplies default anonymous value for a value type e.g. int, double, etc.
    /// </summary>
    public class DefaultValueTypeValueSupplier : IAnonymousValueSupplier
    {
        /// <inerhitdoc />
        public bool CanSupplyValue(Type type, string propertyName)
        {
            return type.GetTypeInfo().IsValueType;
        }

        /// <inerhitdoc />
        public object GenerateAnonymousValue(AnonymousValueFixture any, Type type, string propertyName)
        {
            // http://autofixture.codeplex.com/workitem/4229
            var context = new SpecimenContext(any.Fixture);
            var specimen = context.Resolve(type);
            return specimen;
        }
    }
}
