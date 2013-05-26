using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NTestDataBuilder
{
    /// <summary>
    /// Generates objects of type <see cref="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of object this class generates</typeparam>
    public interface IDataBuilder<out T> where T : class
    {
        /// <summary>
        /// Build the object.
        /// </summary>
        /// <returns>The built object</returns>
        T Build();
    }

    /// <summary>
    /// Base class definining infrastructure for a class that generates objects of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of object this class generates</typeparam>
    /// <typeparam name="TBuilder">The type for this class, yes this is a recursive type definition</typeparam>
    public abstract class DataBuilder<TEntity, TBuilder> : IDataBuilder<TEntity>
        where TEntity : class
        where TBuilder : class, IDataBuilder<TEntity>
    {
        private readonly Dictionary<string, object> _properties = new Dictionary<string, object>();

        /// <summary>
        /// Build the object.
        /// </summary>
        /// <returns>The built object</returns>
        public abstract TEntity Build();

        /// <summary>
        /// Records the given value for the given property from <see cref="TEntity"/>.
        /// </summary>
        /// <typeparam name="TValue">The type of the property</typeparam>
        /// <param name="property">A lambda expression specifying the property to record a value for</param>
        /// <param name="value">The value to record</param>
        public void Set<TValue>(Expression<Func<TEntity, TValue>> property, TValue value)
        {
            _properties[GetPropertyName(property)] = value;
        }

        /// <summary>
        /// Gets the recorded value for the given property from <see cref="TEntity"/>.
        /// </summary>
        /// <typeparam name="TValue">The type of the property</typeparam>
        /// <param name="property">A lambda expression specifying the property to retrieve the recorded value for</param>
        /// <returns>The recorded value of the property</returns>
        public TValue Get<TValue>(Expression<Func<TEntity, TValue>> property)
        {
            return (TValue)_properties[GetPropertyName(property)];
        }

        private static string GetPropertyName<TValue>(Expression<Func<TEntity, TValue>> property)
        {
            var memExp = property.Body as MemberExpression;
            if (memExp == null)
                throw new ArgumentException("Property must be valid on the entity object", "property");

            return memExp.Member.Name;
        }
    }
}
