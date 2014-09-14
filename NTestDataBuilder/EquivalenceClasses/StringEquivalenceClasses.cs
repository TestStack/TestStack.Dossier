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

        /// <summary>
        /// Generate and return a string starting with the given prefix.
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <param name="prefix">String to prefix the returned anonymous string with</param>
        /// <returns>The generated string</returns>
        public static string StringStartingWith(this AnonymousValueFixture fixture, string prefix)
        {
            return fixture.Fixture.Create(prefix);
        }

        /// <summary>
        /// Generate and return a string ending with the given suffix.
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <param name="suffix">String to end the returned anonymous string with</param>
        /// <returns>The generated string</returns>
        public static string StringEndingWith(this AnonymousValueFixture fixture, string suffix)
        {
            return string.Format("{0}{1}", fixture.Fixture.Create<string>(), suffix);
        }
    }
}
