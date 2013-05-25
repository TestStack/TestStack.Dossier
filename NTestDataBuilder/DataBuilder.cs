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
        /// <summary>
        /// Build the object.
        /// </summary>
        /// <returns>The built object</returns>
        public abstract TEntity Build();
    }
}
