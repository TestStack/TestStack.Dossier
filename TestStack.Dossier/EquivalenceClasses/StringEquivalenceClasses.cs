using System.Text;
using AutoFixture;
using AutoFixture.Kernel;

namespace TestStack.Dossier.EquivalenceClasses
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
        /// Generate and return a string matching the given regex.
        /// Only a limited subset of regex expressions are supported: http://www.brics.dk/automaton/faq.html.
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <param name="regexPattern">The regex pattern to match</param>
        /// <returns>The generated string</returns>
        public static string StringMatching(this AnonymousValueFixture fixture, string regexPattern)
        {
            return fixture.RegexGenerator.Create(new RegularExpressionRequest(regexPattern), new DummyContext()).ToString();
        }

        class DummyContext : ISpecimenContext
        {
            /// <inerhitdoc />
            public object Resolve(object request)
            {
                return null;
            }
        }

        /// <summary>
        /// Generate and return a string starting with the given prefix.
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <param name="prefix">String to prefix the returned anonymous string with</param>
        /// <returns>The generated string</returns>
        public static string StringStartingWith(this AnonymousValueFixture fixture, string prefix)
        {
            //return fixture.Fixture.Create<string>(prefix);
            return string.Format("{0}{1}", prefix, fixture.Fixture.Create<string>());
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

        /// <summary>
        /// Generate and return a string of the given length.
        /// </summary>
        /// <param name="fixture">The fixture to generate a string for</param>
        /// <param name="length">The length of string to generate</param>
        /// <returns>The generated string</returns>
        public static string StringOfLength(this AnonymousValueFixture fixture, int length)
        {
            var sb = new StringBuilder();
            while (sb.Length < length)
            {
                sb.Append(String(fixture));
            }
            return sb.ToString().Substring(0, length);
        }
    }
}
