using System;
using System.Collections.Generic;
using Shouldly;
using TestStack.Dossier.DataSources.Generators;
using Xunit;

namespace TestStack.Dossier.Tests.DataSources.Generators
{
    public class RandomGeneratorTests
    {
        [Theory,
        InlineData(5,4),
        InlineData(5,5)]
        public void WhenCreatingRandomGenerator_ThenStartIndexMustBeLessThanListSize(int startIndex, int listSize)
        {
            Action factory = () => new RandomGenerator(startIndex, listSize);
            Should.Throw<ArgumentException>(factory)
                .Message.ShouldBe(string.Format("startIndex must be less than listSize"));
        }

        [Fact]
        public void WhenGeneratingRandomIntegers_ThenShouldAlwaysGenerateIntegerBetweenStartIndexAndListSize()
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

        [Fact]
        public void WhenGeneratingRandomIntegers_ThenShouldBeAbleToGenerateLowerBoundaryValue()
        {
            var results = new List<int>();
            var sut = new RandomGenerator(0, 3);
            for (int i = 0; i < 20; i++)
            {
                results.Add(sut.Generate());
            }
            results.ShouldContain(0);
        }

        [Fact]
        public void WhenGeneratingRandomIntegers_ThenShouldBeAbleToGenerateUpperBoundaryValue()
        {
            var results = new List<int>();
            var sut = new RandomGenerator(0, 3);
            for (int i = 0; i < 20; i++)
            {
                results.Add(sut.Generate());
            }
            results.ShouldContain(2);
            results.ShouldNotContain(3);
        }


    }
}
