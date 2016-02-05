using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Ploeh.AutoFixture;
using TestStack.Dossier.DataSources.Dictionaries;
using TestStack.Dossier.Suppliers;

namespace TestStack.Dossier
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
                new DefaultEmailValueSupplier(),
                new DefaultFirstNameValueSupplier(),
                new DefaultLastNameValueSupplier(),
                new DefaultStringValueSupplier(),
                new DefaultValueTypeValueSupplier(),
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
            Bag = new NullingExpandoObject();
            RegexGenerator = new RegularExpressionGenerator();
        }

        /// <summary>
        /// An AutoFixture RegularExpressionGenerator instance that can be used to generate
        ///   strings matching a regex pattern.
        /// </summary>
        public RegularExpressionGenerator RegexGenerator { get; private set; }

        /// <summary>
        /// An AutoFixture Fixture instance that is scoped to this anonymous value fixture
        ///   and can be used to generate anonymous values using AutoFixture.
        /// </summary>
        public Fixture Fixture { get; private set; }

        /// <summary>
        /// Dynamic bag of objects that can be used by equivalence classes / anonymous value suppliers to store state.
        /// </summary>
        public dynamic Bag { get; private set; }

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
            var propertyName = Reflector.GetPropertyNameFor(property);
            var valueSupplier = LocalValueSuppliers
                .Concat(GlobalValueSuppliers)
                .Concat(DefaultValueSuppliers)
                .First(s => s.CanSupplyValue(typeof(T), propertyName));

            return (T) valueSupplier.GenerateAnonymousValue(this, typeof(T), propertyName);
        }

        /// <summary>
        /// Automatically generate an anonymous value for the given property expression.
        /// </summary>
        /// <param name="type">The type of the property</param>
        /// <param name="propertyName">The name of the property</param>
        /// <returns>The anonymous value, taking into account any registered conventions</returns>
        public object Get(Type type, string propertyName)
        {
            var valueSupplier = LocalValueSuppliers
                .Concat(GlobalValueSuppliers)
                .Concat(DefaultValueSuppliers)
                .First(s => s.CanSupplyValue(type, propertyName));

            return valueSupplier.GenerateAnonymousValue(this, type, propertyName);
        }

        /// <summary>
        /// Gets a data source for a file dictionary, which can be built-in or a user-supplied text file.
        /// </summary>
        /// <param name="dictionaryName">The name of the file dictionary, without the extension.
        /// Recommended to use the FromDictionary list of constants for the built-in file dictionaries.
        /// Just use a normal string for user-supplied text files.</param>
        /// <returns></returns>
        public Words Words(string dictionaryName)
        {
            return WordsCache.Get(dictionaryName);
        }
    }
}
