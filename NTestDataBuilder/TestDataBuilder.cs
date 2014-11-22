using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FizzWare.NBuilder;

namespace NTestDataBuilder
{
    /// <summary>
    /// Generates objects of type <see cref="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of object this class generates</typeparam>
    public interface ITestDataBuilder<out T> where T : class
    {
        /// <summary>
        /// Build the object.
        /// </summary>
        /// <returns>The built object</returns>
        T Build();
    }

    /// <summary>
    /// Base class definining infrastructure for a class that generates objects of type <see cref="TObject"/>.
    /// </summary>
    /// <typeparam name="TObject">The type of object this class generates</typeparam>
    /// <typeparam name="TBuilder">The type for this class, yes this is a recursive type definition</typeparam>
    public abstract class TestDataBuilder<TObject, TBuilder> : ITestDataBuilder<TObject>
        where TObject : class
        where TBuilder : class, ITestDataBuilder<TObject>
    {
        private readonly Dictionary<string, object> _properties = new Dictionary<string, object>();
        private ProxyBuilder<TObject> _proxyBuilder;

        /// <summary>
        /// Build the object.
        /// </summary>
        /// <returns>The built object</returns>
        public TObject Build()
        {
            if (_proxyBuilder != null)
            {
                var proxy = _proxyBuilder.Build();
                AlterProxy(proxy);
                return proxy;
            }

            return BuildObject();
        }

        /// <summary>
        /// Build the actual object
        /// </summary>
        /// <returns>The built object</returns>
        protected abstract TObject BuildObject();

        /// <summary>
        /// Return an NSubstitute proxy object when .Build() is called rather than a real object.
        /// </summary>
        /// <returns>The builder so that other method calls can be chained</returns>
        public TBuilder AsProxy()
        {
            _proxyBuilder = new ProxyBuilder<TObject>(_properties);
            return this as TBuilder;
        }

        /// <summary>
        /// Alter the proxy object just after it has been built and before it's returned from .Build().
        /// This allows you to add any .Returns() values that are more complex than the public properties that are proxied by default.
        /// </summary>
        /// <param name="proxy">The proxy object</param>
        protected virtual void AlterProxy(TObject proxy) {}
        
        /// <summary>
        /// Records the given value for the given property from <see cref="TObject"/>.
        /// </summary>
        /// <typeparam name="TValue">The type of the property</typeparam>
        /// <param name="property">A lambda expression specifying the property to record a value for</param>
        /// <param name="value">The value to record</param>
        public TBuilder Set<TValue>(Expression<Func<TObject, TValue>> property, TValue value)
        {
            _properties[GetPropertyName(property)] = value;
            return (TBuilder)this;
        }

        /// <summary>
        /// Gets the recorded value for the given property from <see cref="TObject"/>.
        /// </summary>
        /// <typeparam name="TValue">The type of the property</typeparam>
        /// <param name="property">A lambda expression specifying the property to retrieve the recorded value for</param>
        /// <returns>The recorded value of the property</returns>
        public TValue Get<TValue>(Expression<Func<TObject, TValue>> property)
        {
            if (!Has(property))
                throw new ArgumentException(
                    string.Format(
                        "No value has been recorded yet for {0}; consider using Has(x => x.{0}) to check for a value first.",
                        GetPropertyName(property)
                    ),
                    "property"
                );

            return (TValue)_properties[GetPropertyName(property)];
        }

        /// <summary>
        /// Gets the recorded value for the given property from <see cref="TObject"/> or if no
        /// value has been recorded the default value for <see cref="TValue"/>.
        /// </summary>
        /// <typeparam name="TValue">The type of the property</typeparam>
        /// <param name="property">A lambda expression specifying the property to retrieve the recorded value for</param>
        /// <returns>The recorded value of the property or teh default value for <see cref="TValue"/> if no value recorded</returns>
        public TValue GetOrDefault<TValue>(Expression<Func<TObject, TValue>> property)
        {
            return Has(property)
                ? Get(property)
                : default(TValue);
        }

        /// <summary>
        /// Creates an NBuilder list builder expression that allows you to create a list of builders.
        /// When you are done call .Build().Select(b => b.Build()) to get the list of entities.
        /// </summary>
        /// <param name="size">The size of list</param>
        /// <returns>The NBuilder list builder for a list of <see cref="TBuilder"/> of the specified size</returns>
        public static IListBuilder<TBuilder> CreateListOfSize(int size)
        {
            return Builder<TBuilder>.CreateListOfSize(size);
        }

        /// <summary>
        /// Returns whether or not there is currently a value recorded against the given property from <see cref="TObject"/>.
        /// </summary>
        /// <typeparam name="TValue">The type of the property</typeparam>
        /// <param name="property">A lambda expression specifying the property to retrieve the recorded value for</param>
        /// <returns>Whether or not there is a recorded value for the property</returns>
        protected bool Has<TValue>(Expression<Func<TObject, TValue>> property)
        {
            return _properties.ContainsKey(GetPropertyName(property));
        }

        private static string GetPropertyName<TValue>(Expression<Func<TObject, TValue>> property)
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
