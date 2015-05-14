using Ploeh.AutoFixture;

namespace TestStack.Dossier.Factories
{
    /// <summary>
    /// Creates an instance of an object with AutoFixture.
    /// </summary>
    public class AutoFixtureFactory : IFactory
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