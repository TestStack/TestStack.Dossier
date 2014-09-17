using System;
using NTestDataBuilder.DataSources.Generators;
using Shouldly;
using Xunit;
using Xunit.Extensions;

namespace NTestDataBuilder.Tests.DataSources.Generators
{
    public class RandomGeneratorTests
    {
        [Fact]
        public void WhenGeneratingRandomIntegers_ThenShouldAlwaysGenerateIntegerBetweenMinAndMaxValue()
        {
            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                int minimumValue = random.Next(0,10);
                int maximumValue = random.Next(20,30);
                var sut = new RandomGenerator(minimumValue, maximumValue);

                var result = sut.Generate();

                result.ShouldBeGreaterThanOrEqualTo(minimumValue);
                result.ShouldBeLessThanOrEqualTo(maximumValue);
            }
        }

        [Theory,
        InlineData(0,0),
        InlineData(0,-1),
        InlineData(-1,-2),
        InlineData(5,4),
        InlineData(5,5)]
        public void WhenCreatingRandomGenerator_minimumValueMustBeLessThanMaximumValue(int minValue, int maxValue)
        {
            Action factory = () => new RandomGenerator(minValue, maxValue);
            Should.Throw<ArgumentException>(factory)
                .Message.ShouldBe(string.Format("minValue must be less than maxValue"));
        }
    }
}
