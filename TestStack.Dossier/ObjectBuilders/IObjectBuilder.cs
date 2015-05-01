namespace TestStack.Dossier.ObjectBuilders
{
    /// <summary>
    /// Interface for object building strategies
    /// </summary>
    public interface IObjectBuilder
    {
        /// <summary>
        /// Takes a builder and generates an object of the specified type.
        /// </summary>
        /// <param name="builder">An instance of the TestDataBuilder.</param>
        /// <typeparam name="TObject">The generic type of the object that will be generated.</typeparam>
        /// <typeparam name="TBuilder">The generic type of the TestDataBuilder.</typeparam>
        /// <returns>An instance of the created object.</returns>
        TObject BuildObject<TObject, TBuilder>(TestDataBuilder<TObject, TBuilder> builder)
            where TObject : class
            where TBuilder : TestDataBuilder<TObject, TBuilder>, new();
    }
}