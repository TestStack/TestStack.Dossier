namespace TestStack.Dossier
{
    /// <summary>
    /// A stand-alone class for building objects on the fly.
    /// </summary>
    /// <typeparam name="T">The type of object this class generates.</typeparam>
    public class Builder<T> : TestDataBuilder<T, Builder<T>>
        where T : class
    {
        /// <summary>
        /// Initialises a new Builder.
        /// </summary>
        /// <returns>Returns a new instance of a Builder for the type of T</returns>
        public static Builder<T> CreateNew()
        {
            return new Builder<T>();
        } 
    }
}
