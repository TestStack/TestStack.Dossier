using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using NTestDataBuilder.Suppliers;
using Ploeh.AutoFixture;

namespace NTestDataBuilder
{
    /// <summary>
    /// Allows you to create extension methods to generate anonymous values and to set up
    ///   conventions for automatic generation of anonymous values based on property expressions.
    /// </summary>
    public class AnonymousValueFixture
    {
        static AnonymousValueFixture()
        {
            GlobalValueSuppliers = new List<IAnonymousValueSupplier>();
            DefaultValueSuppliers = new IAnonymousValueSupplier[]
            {
                new DefaultStringValueSupplier(),
                new DefaultValueSupplier()
            };
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public AnonymousValueFixture()
        {
            LocalValueSuppliers = new List<IAnonymousValueSupplier>();
            Fixture = new Fixture();
        }

        /// <summary>
        /// An AutoFixture Fixture instance that is scoped to this anonymous value fixture
        ///   and can be used to generate anonymous values using AutoFixture.
        /// </summary>
        public Fixture Fixture { get; private set; }

        /// <summary>
        /// Ordered, immutable collection of default anonymous value suppliers to interrogate when automatically generating an anonymous value.
        /// These have the lowest priority and are a fallback if there are no local or global value suppliers that apply.
        /// </summary>
        public static IEnumerable<IAnonymousValueSupplier> DefaultValueSuppliers { get; private set; }

        /// <summary>
        /// Ordered, mutable collection of global anonymous value suppliers to interrogate when automatically generating an anonymous value.
        /// These have a higher priority than the defaut value suppliers, but a lower priority than the local value suppliers.
        /// </summary>
        public static ICollection<IAnonymousValueSupplier> GlobalValueSuppliers { get; private set; }

        /// <summary>
        /// Ordered, mutable collection of fixture-specific anonymous value suppliers to interrogate when automatically generating an anonymous value.
        /// These have the highest priority.
        /// </summary>
        public ICollection<IAnonymousValueSupplier> LocalValueSuppliers { get; private set; }

        /// <summary>
        /// Automatically generate an anonymous value for the given property expression.
        /// </summary>
        /// <typeparam name="TObject">The type of the parent object of the property</typeparam>
        /// <typeparam name="T">The type of the property</typeparam>
        /// <param name="property">The expression identifying the property</param>
        /// <returns>The anonymous value, taking into account any registered conventions</returns>
        public T Get<TObject, T>(Expression<Func<TObject, T>> property)
        {
            var propertyName = PropertyNameGetter.Get(property);
            var valueSupplier = LocalValueSuppliers
                .Concat(GlobalValueSuppliers)
                .Concat(DefaultValueSuppliers)
                .First(s => s.CanSupplyValue<TObject, T>(propertyName));

            return valueSupplier.GenerateAnonymousValue<TObject, T>(this, propertyName);
        }
    }
}
