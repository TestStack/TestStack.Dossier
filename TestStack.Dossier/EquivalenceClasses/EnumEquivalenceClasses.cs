using System;
using System.Linq;
using Ploeh.AutoFixture;

// ReSharper disable once CheckNamespace
namespace TestStack.Dossier
{
    /// <summary>
    /// Extension methods that describe equivalence classes for generating anonymous enum values.
    /// </summary>
    public static class EnumEquivalenceClasses
    {
        /// <summary>
        /// Generate and return an enum from any available values in the enum.
        /// </summary>
        /// <param name="fixture">The fixture to generate an enum for</param>
        /// <returns>The generated enum</returns>
        public static TEnum Of<TEnum>(this AnonymousValueFixture fixture)
            where TEnum : struct,  IComparable, IFormattable, IConvertible
        {
            return fixture.Fixture.Create<TEnum>();
        }

        /// <summary>
        /// Generate and return an enum from any values in the enum except the provided exceptions.
        /// </summary>
        /// <param name="fixture">The fixture to generate an enum for</param>
        /// <param name="except">A list of exceptions; recommend you specify by label for readability</param>
        /// <returns>The generated enum</returns>
        public static TEnum Except<TEnum>(this AnonymousValueFixture fixture, params TEnum[] except)
            where TEnum : struct,  IComparable, IFormattable, IConvertible
        {
            var value = fixture.Fixture.Create<TEnum>();
            while (except.Contains(value))
                value = fixture.Fixture.Create<TEnum>();

            return value;
        }
    }
}
