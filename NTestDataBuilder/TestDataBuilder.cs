using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using NTestDataBuilder.Lists;

namespace NTestDataBuilder
{
    /// <summary>
    /// Base class definining infrastructure for a class that generates objects of type {TObject}.
    /// </summary>
    /// <typeparam name="TObject">The type of object this class generates</typeparam>
    /// <typeparam name="TBuilder">The type for this class, yes this is a recursive type definition</typeparam>
    public abstract class TestDataBuilder<TObject, TBuilder>
        where TObject : class
        where TBuilder : TestDataBuilder<TObject, TBuilder>, new()
    {
        private readonly Dictionary<string, object> _properties = new Dictionary<string, object>();
        private ProxyBuilder<TObject> _proxyBuilder;
        internal ListBuilder<TObject, TBuilder> ListBuilder { get; set; } 

        /// <summary>
        /// Default Constructor.
        /// </summary>
        protected TestDataBuilder()
        {
            Any = new AnonymousValueFixture();
        }

        /// <summary>
        /// Generate anonymous data using this fixture - one instance per builder instance.
        /// </summary>
        public AnonymousValueFixture Any { get; internal set; }

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
        /// Build the actual object - override this and call the constructor and any other methods.
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
        /// Records the given value for the given property from {TObject} and returns the builder to allow chaining.
        /// </summary>
        /// <typeparam name="TValue">The type of the property</typeparam>
        /// <param name="property">A lambda expression specifying the property to record a value for</param>
        /// <param name="value">The value to record</param>
        protected TBuilder Set<TValue>(Expression<Func<TObject, TValue>> property, TValue value)
        {
            _properties[PropertyNameGetter.Get(property)] = value;
            return this as TBuilder;
        }

        /// <summary>
        /// Gets the recorded value for the given property from {TObject} or an anonymous
        ///  value if there isn't one specified.
        /// </summary>
        /// <typeparam name="TValue">The type of the property</typeparam>
        /// <param name="property">A lambda expression specifying the property to retrieve the recorded value for</param>
        /// <returns>The recorded value of the property or an anonymous value for it</returns>
        public TValue Get<TValue>(Expression<Func<TObject, TValue>> property)
        {
            if (!Has(property))
                return Any.Get(property);

            return (TValue)_properties[PropertyNameGetter.Get(property)];
        }

        /// <summary>
        /// Gets the recorded value for the given property from {TObject} or if no
        /// value has been recorded the default value for {TValue}.
        /// </summary>
        /// <typeparam name="TValue">The type of the property</typeparam>
        /// <param name="property">A lambda expression specifying the property to retrieve the recorded value for</param>
        /// <returns>The recorded value of the property or teh default value for {TValue} if no value recorded</returns>
        public TValue GetOrDefault<TValue>(Expression<Func<TObject, TValue>> property)
        {
            return Has(property)
                ? Get(property)
                : default(TValue);
        }

        /// <summary>
        /// Creates an list builder expression that allows you to create a list of entities.
        /// You can call .First(x), .Last(x), etc. methods followed by chained builder method calls.
        /// When you are done call .BuildList() to get the list of entities.
        /// </summary>
        /// <param name="size">The size of list</param>
        /// <returns>The list builder for a list of {TBuilder} of the specified size</returns>
        public static ListBuilder<TObject, TBuilder> CreateListOfSize(int size)
        {
            return new ListBuilder<TObject, TBuilder>(size);
        } 

        /// <summary>
        /// Returns whether or not there is currently an explicit value recorded against the given property from {TObject}.
        /// </summary>
        /// <typeparam name="TValue">The type of the property</typeparam>
        /// <param name="property">A lambda expression specifying the property to retrieve the recorded value for</param>
        /// <returns>Whether or not there is a recorded value for the property</returns>
        protected bool Has<TValue>(Expression<Func<TObject, TValue>> property)
        {
            return _properties.ContainsKey(PropertyNameGetter.Get(property));
        }
    }
}
