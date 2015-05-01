using Ploeh.AutoFixture;

namespace TestStack.Dossier.BuildStrategies
{
    /// <summary>
    /// Creates an instance of an object with AutoFixture.
    /// </summary>
    public class AutoFixture : IBuildStrategy
    {
        /// <inheritdoc />
        public TObject BuildObject<TObject, TBuilder>(TestDataBuilder<TObject, TBuilder> builder) 
            where TObject : class 
            where TBuilder : TestDataBuilder<TObject, TBuilder>, new()
        {
            return builder.Any.Fixture.Create<TObject>();
        }
    }
}