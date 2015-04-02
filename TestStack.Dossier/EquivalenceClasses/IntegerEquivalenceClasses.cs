using System.Linq;
using Ploeh.AutoFixture;

namespace TestStack.Dossier.EquivalenceClasses
{
    /// <summary>
    /// Extension methods that describe equivalence classes for generating anonymous integer values.
    /// </summary>
    public static class IntegerEquivalenceClasses
    {
        /// <summary>
        /// Generate and return a positive integer.
        /// </summary>
        /// <param name="fixture">The fixture to generate an integer for</param>
        /// <returns>The generated integer</returns>
        public static int PositiveInteger(this AnonymousValueFixture fixture)
        {
            return fixture.Fixture.Create<int>();
        }

        /// <summary>
        /// Generate and return a negative integer.
        /// </summary>
        /// <param name="fixture">The fixture to generate an integer for</param>
        /// <returns>The generated integer</returns>
        public static int NegativeInteger(this AnonymousValueFixture fixture)
        {
            return 0 - fixture.PositiveInteger();
        }

        /// <summary>
        /// Generate and return an integer except for the passed in integer(s).
        /// </summary>
        /// <param name="fixture">The fixture to generate an integer for</param>
        /// <param name="exceptFor">A list of integers to not return</param>
        /// <returns>The generated integer</returns>
        public static int IntegerExcept(this AnonymousValueFixture fixture, params int[] exceptFor)
        {
            int result;
            do
            {
                result = fixture.PositiveInteger();
            } while (exceptFor.Contains(result));
            return result;
        }
    }
}
