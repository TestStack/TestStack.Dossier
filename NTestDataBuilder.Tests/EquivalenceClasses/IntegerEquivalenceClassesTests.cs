using System.Collections.Generic;
using System.Linq;
using NTestDataBuilder.EquivalenceClasses;
using Shouldly;
using Xunit;

namespace NTestDataBuilder.Tests.EquivalenceClasses
{
    public class IntegerEquivalenceClassesTests
    {
        public AnonymousValueFixture Any { get; private set; }

        public IntegerEquivalenceClassesTests()
        {
            Any = new AnonymousValueFixture();
        }

        [Fact]
        public void WhenGettingAnyPositiveInteger_ThenReturnDifferentPositiveIntegersEveryTime()
        {
            var s1 = Any.PositiveInteger();
            var s2 = Any.PositiveInteger();

            s1.ShouldBeOfType<int>();
            s2.ShouldBeOfType<int>();
            s1.ShouldBeGreaterThan(0);
            s2.ShouldBeGreaterThan(0);
            s1.ShouldNotBe(s2);
        }

        [Fact]
        public void WhenGettingAnyNegativeInteger_ThenReturnDifferentNegativeIntegersEveryTime()
        {
            var s1 = Any.NegativeInteger();
            var s2 = Any.NegativeInteger();

            s1.ShouldBeOfType<int>();
            s2.ShouldBeOfType<int>();
            s1.ShouldBeLessThan(0);
            s2.ShouldBeLessThan(0);
            s1.ShouldNotBe(s2);
        }

        [Fact]
        public void WhenGettingAnyIntegerExceptASetOfIntegers_ThenReturnDifferentIntegersExceptTheGivenIntegersEveryTime()
        {
            var generated = new List<int>();

            for (var i = 0; i < 1000; i++)
            {
                var integer = Any.IntegerExcept(1, 5, 200, 356, 4, 53);
                generated.Add(integer);
            }

            generated.ShouldAllBe(i => i != 1
                && i != 5
                && i != 200
                && i != 356
                && i != 4
                && i != 53);
            generated.Distinct().Count()
                .ShouldBe(generated.Count);
        }
    }
}
