using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TestStack.Dossier.Factories;
using TestStack.Dossier.Lists;

namespace TestStack.Dossier
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
        private readonly Dictionary<string, Func<object>> _properties = new Dictionary<string, Func<object>>();
        private ProxyBuilder<TObject> _proxyBuilder;

        /// <summary>
        /// The list builder instance (if this is a a list builder proxy).
        /// </summary>
        public ListBuilder<TObject, TBuilder> ListBuilder { get; internal set; } 

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
        /// Builds the object with implicit conversion operator.
        /// </summary>
        /// <returns>The built object</returns>
        public static implicit operator TObject(TestDataBuilder<TObject, TBuilder> builder)
        {
            return builder.Build();
        }

        /// <summary>
        /// Builds the list of objects with implicit conversion operator.
        /// </summary>
        /// <returns>The built object</returns>
        public static implicit operator List<TObject>(TestDataBuilder<TObject, TBuilder> builder)
        {
            return builder.ListBuilder;
        }

        /// <summary>
        /// Build the actual object - you can call the <see cref="BuildUsing{TFactory}"/> method to quickly build a builder.
        /// </summary>
        /// <returns>The built object</returns>
        protected virtual TObject BuildObject()
        {
            return BuildUsing<PublicPropertySettersFactory>();
        }

        /// <summary>
        /// Builds the object from this builder using an <see cref="IFactory"/>.
        /// </summary>
        /// <typeparam name="TFactory">The factory to use to build the object</typeparam>
        /// <returns>The built object</returns>
        protected TObject BuildUsing<TFactory>()
            where TFactory : IFactory, new()
        {
            var factory = new TFactory();
            return factory.BuildObject(this);
        }

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
        /// <param name="value">The value to set the property to</param>
        /// <returns>The builder so that other method calls can be chained</returns>
        public virtual TBuilder Set<TValue>(Expression<Func<TObject, TValue>> property, TValue value)
        {
            _properties[Reflector.GetPropertyNameFor(property)] = () => value;
            return this as TBuilder;
        }

        /// <summary>
        /// Records a given value provider for the given property from {TObject} and returns the builder to allow chaining.
        /// </summary>
        /// <typeparam name="TValue">The type of the property</typeparam>
        /// <param name="property">A lambda expression specifying the property to record a value for</param>
        /// <param name="factory">A method which produces instances of {TValue} for the property.</param>
        /// <returns>The builder so that other method calls can be chained</returns>
        public virtual TBuilder Set<TValue>(Expression<Func<TObject, TValue>> property, Func<TValue> factory)
        {
            _properties[Reflector.GetPropertyNameFor(property)] = () => factory() as object;
            return this as TBuilder;
        }

        /// <summary>
        /// Gets the recorded value for the given property from {TObject} or an anonymous
        ///  value if there isn't one specified.
        /// </summary>
        /// <typeparam name="TValue">The type of the property.</typeparam>
        /// <param name="property">A lambda expression specifying the property to retrieve the recorded value for</param>
        /// <returns>The recorded value of the property or an anonymous value for it</returns>
        public TValue Get<TValue>(Expression<Func<TObject, TValue>> property)
        {
            return (TValue)Get(typeof (TValue), Reflector.GetPropertyNameFor(property));
        }

        /// <summary>
        /// Gets the recorded value for the given property from {type} or an anonymous
        ///  value if there isn't one specified.
        /// </summary>
        /// <param name="type">The type of the property.</param>
        /// <param name="propertyName">The property name.</param>
        /// <returns></returns>
        public object Get(Type type, string propertyName)
        {
            Func<object> factory;
            if (_properties.TryGetValue(propertyName, out factory)) return factory();

            return Any.Get(type, propertyName);
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
            return Has(Reflector.GetPropertyNameFor(property));
        }

        /// <summary>
        /// Returns whether or not there is currently an explicit value recorded against the given property from {TObject}.
        /// </summary>
        /// <param name="propertyName">A string specifying the name of the property to retrieve the recorded value for</param>
        /// <returns>Whether or not there is a recorded value for the property</returns>
        protected bool Has(string propertyName)
        {
            return _properties.ContainsKey(propertyName);
        }

        /// <summary>
        /// Returns whether or not the builder instance is a proxy for building a list or an actual builder instance.
        /// </summary>
        /// <returns>Whether or not the instance is a list builder proxy</returns>
        public virtual bool IsListBuilderProxy()
        {
            return ListBuilder != null;
        }

        /// <summary>
        /// Creates (and optionally modifies) a child builder class of this builder; sharing the anonymous value fixture.
        /// </summary>
        /// <typeparam name="TChildObject">The type of the child object being built</typeparam>
        /// <typeparam name="TChildBuilder">The type of the builder for the child object being built</typeparam>
        /// <param name="modifier">An optional modifier lambda expression with fluent builder method calls for the child builder</param>
        /// <returns>The instance of the child builder</returns>
        protected virtual TChildBuilder GetChildBuilder<TChildObject, TChildBuilder>(Func<TChildBuilder, TChildBuilder> modifier = null)
            where TChildObject : class
            where TChildBuilder : TestDataBuilder<TChildObject, TChildBuilder>, new()
        {
            var childBuilder = new TChildBuilder {Any = Any};
            if (modifier != null)
                modifier(childBuilder);
            return childBuilder;
        }
    }
}
