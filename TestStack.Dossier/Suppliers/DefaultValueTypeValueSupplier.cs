using System;
using System.Linq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Kernel;

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
            return type.IsValueType;
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
