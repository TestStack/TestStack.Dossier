using System;
using System.Linq.Expressions;
using Ploeh.AutoFixture.Kernel;
using TestStack.Dossier.Factories;
using TestStack.Dossier.Lists;

namespace TestStack.Dossier
{
    /// <summary>
    /// A generic Test Data Builder implementation for building objects on the fly
    ///   without needing to create a custom builder.
    /// </summary>
    /// <typeparam name="T">The type of object this class generates.</typeparam>
    public class Builder<T> : TestDataBuilder<T, Builder<T>>
        where T : class
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Builder()
        {
            Factory = new AllPropertiesFactory();
        }

        private IFactory Factory { get; set; }

        internal Builder<T> SetFactory(IFactory factory)
        {
            Factory = factory;
            return this;
        }

        /// <summary>
        /// Initialises a new Builder.
        /// </summary>
        /// <param name="factory">The type of factory to use to construct the object, uses <see cref="AllPropertiesFactory"/> by default</param>
        /// <returns>Returns a new instance of a Builder for the type of T</returns>
        public static Builder<T> CreateNew(IFactory factory = null)
        {
            return new Builder<T>
            {
                Factory = factory ?? new AllPropertiesFactory()
            };
        }

        /// <summary>
        /// Creates an list builder expression that allows you to create a list of entities.
        /// You can call .First(x), .Last(x), etc. methods followed by chained builder method calls.
        /// When you are done call .BuildList() to get the list of entities.
        /// This override allows you to specify the factory that is used to construct the objects,
        ///   the default implementation uses the <see cref="AllPropertiesFactory"/>.
        /// </summary>
        /// <param name="size">The size of list</param>
        /// <param name="factory">The factory to use to construct the object</param>
        /// <returns>The list builder for a list of {TBuilder} of the specified size</returns>
        public static ListBuilder<T, Builder<T>> CreateListOfSize(int size, IFactory factory)
        {
            var lb = new ListBuilder<T, Builder<T>>(size);
            lb.All().With(b => b.SetFactory(factory));
            return lb;
        } 

        /// <inheritdoc />
        protected override T BuildObject()
        {
            return Factory.BuildObject(this);
        }

        /// <summary>
        /// Set a property value using a custom builder.
        /// </summary>
        /// <typeparam name="TPropertyType">The type of the property being set</typeparam>
        /// <typeparam name="TPropertyBuilder">The type of the custom builder to build the property value using</typeparam>
        /// <param name="property">The property to set</param>
        /// <param name="modifier">An optional modifier to customise the builder</param>
        /// <returns>The builder so that other method calls can be chained</returns>
        public virtual Builder<T> SetUsingBuilder<TPropertyType, TPropertyBuilder>(
            Expression<Func<T, TPropertyType>> property,
            Func<TPropertyBuilder, TPropertyBuilder> modifier = null)
            where TPropertyType : class
            where TPropertyBuilder : TestDataBuilder<TPropertyType, TPropertyBuilder>, new()
        {
            return Set(property, GetChildBuilder<TPropertyType, TPropertyBuilder>(modifier));
        }

        /// <summary>
        /// Set a property value using a <see cref="Builder{TPropertyType}"/>.
        /// </summary>
        /// <typeparam name="TPropertyType">The type of the property being set</typeparam>
        /// <param name="property">The property to set</param>
        /// <param name="modifier">An optional modifier to customise the builder</param>
        /// <returns>The builder so that other method calls can be chained</returns>
        public virtual Builder<T> SetUsingBuilder<TPropertyType>(
            Expression<Func<T, TPropertyType>> property,
            Func<Builder<TPropertyType>, Builder<TPropertyType>> modifier = null)
            where TPropertyType : class
        {
            return Set(property, GetChildBuilder<TPropertyType, Builder<TPropertyType>>(modifier));
        }
    }
}
