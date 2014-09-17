using System;
using NTestDataBuilder.DataSources.Generators;
using Shouldly;
using Xunit;
using Xunit.Extensions;

namespace NTestDataBuilder.Tests.DataSources.Generators
{
    public class SequentiaGeneratorTests
    {
        [Theory,
        InlineData(0, 0),
        InlineData(5, 4),
        InlineData(5, 5)]
        public void WhenCreatingRandomGenerator_ThenStartIndexMustBeLessThanListSize(int startIndex, int listSize)
        {
            Action factory = () => new SequentialGenerator(startIndex, listSize);
            Should.Throw<ArgumentException>(factory)
                .Message.ShouldBe(string.Format("startIndex must be less than listSize"));
        }

        [Fact]
        public void WhenCreatingRandomGenerator_ThenStartIndexMustBeZeroOrMore()
        {
            Action factory = () => new SequentialGenerator(-1, 1);
            Should.Throw<ArgumentException>(factory)
                .Message.ShouldBe(string.Format("startIndex must be zero or more"));
        }

        [Theory,
        InlineData(0, 0),
        InlineData(0, -1)]
        public void WhenCreatingRandomGenerator_ThenListSizeMustBeGreaterThanZero(int startIndex, int listSize)
        {
            Action factory = () => new SequentialGenerator(startIndex, listSize);
            Should.Throw<ArgumentException>(factory)
                .Message.ShouldBe(string.Format("listSize must be greater than zero"));
        }


        [Fact]
        public void WhenGeneratingIntegers_ThenShouldBeSequential()
        {
            var sut = new SequentialGenerator(0, 11);
            for (int index = sut.StartIndex; index <= sut.ListSize; index++)
            {
                sut.Generate().ShouldBe(index);
            }
        }

        [Fact]
        public void GivenGeneratorIsNotUnique_WhenGeneratingIntegers_ThenShouldResetAtEndOfList()
        {
            var sut = new SequentialGenerator(0, 2);
            for (int index = sut.StartIndex; index <= sut.ListSize; index++)
            {
                sut.Generate().ShouldBe(index);
            }

            sut.Generate().ShouldBe(sut.StartIndex);
        }

        [Fact]
        public void GivenGeneratorIsUnique_WhenGeneratingIntegers_ThenShouldResetAtEndOfList()
        {
            var sut = new SequentialGenerator(0, 2, true);
            for (int index = sut.StartIndex; index <= sut.ListSize; index++)
            {
                sut.Generate().ShouldBe(index);
            }

            Should.Throw<InvalidOperationException>(()=>sut.Generate())
                .Message.ShouldBe("There are not enough elements in the data source to continue adding items");
        }


    }
}
