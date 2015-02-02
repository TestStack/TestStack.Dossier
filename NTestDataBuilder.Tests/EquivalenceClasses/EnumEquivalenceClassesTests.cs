using NTestDataBuilder.EquivalenceClasses;
using Shouldly;
using Xunit;

namespace NTestDataBuilder.Tests.EquivalenceClasses
{
    public class EnumEquivalenceClassesTests
    {
        public AnonymousValueFixture Any { get; private set; }

        public EnumEquivalenceClassesTests()
        {
            Any = new AnonymousValueFixture();
        }

        [Fact]
        public void WhenGettingAnyOfEnum_ThenReturnSequentialEnumValueEveryTimeUntilItWrapsAroundAgain()
        {
            var values = new[]
            {
                Any.Of<TestEnum>(),
                Any.Of<TestEnum>(),
                Any.Of<TestEnum>(),
                Any.Of<TestEnum>(),
                Any.Of<TestEnum>()
            };

            values.ShouldBe(new []{TestEnum.One, TestEnum.Two, TestEnum.Three, TestEnum.Four, TestEnum.One});
        }

        [Fact]
        public void WhenGettingAnyEnumExceptOneValue_ThenReturnSequentialEnumValueExceptTheExceptionEveryTimeUntilItWrapsAroundAgain()
        {
            var values = new[]
            {
                Any.Except(TestEnum.Two),
                Any.Except(TestEnum.Two),
                Any.Except(TestEnum.Two),
                Any.Except(TestEnum.Two)
            };

            values.ShouldBe(new[] { TestEnum.One, TestEnum.Three, TestEnum.Four, TestEnum.One });
        }
    }

    enum TestEnum
    {
        One,
        Two,
        Three,
        Four
    }
}
