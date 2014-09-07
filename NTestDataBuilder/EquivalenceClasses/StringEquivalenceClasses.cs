using Ploeh.AutoFixture;

namespace NTestDataBuilder.EquivalenceClasses
{
    /// <summary>
    /// Extension methods that describe equivalence classes for generating anonymous string values.
    /// </summary>
    public static class StringEquivalenceClasses
    {
        /// <summary>
        /// Generate and return a string.
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <returns>The generated string</returns>
        public static string String(this AnonymousValueFixture fixture)
        {
            return fixture.Fixture.Create<string>();
        }
    }
}
