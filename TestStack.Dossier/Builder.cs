using TestStack.Dossier.Factories;

namespace TestStack.Dossier
{
    /// <summary>
    /// A stand-alone class for building objects on the fly.
    /// </summary>
    /// <typeparam name="T">The type of object this class generates.</typeparam>
    public class Builder<T> : TestDataBuilder<T, Builder<T>>
        where T : class
    {
        /// <inheritdoc />
        public Builder() 
            : this(new AllPropertiesFactory())
        {
            
        }

        /// <inheritdoc />
        public Builder(IFactory factory) 
            : base(factory) { }

        /// <summary>
        /// Initialises a new Builder.
        /// </summary>
        /// <returns>Returns a new instance of a Builder for the type of T</returns>
        public static Builder<T> CreateNew(IFactory factory = null)
        {
            if (factory == null)
            {
                factory = new AllPropertiesFactory();
            }
            return new Builder<T>(factory);
        } 
    }
}
