using NTestDataBuilder.EquivalenceClasses;
using NUnit.Framework;

namespace NTestDataBuilder.Tests
{
    public class AnyTests
    {
        public AnonymousValueFixture Any { get; private set; }

        [SetUp]
        public void Setup()
        {
            Any = new AnonymousValueFixture();
        }

        [Test]
        public void WhenGettingAnyString_ThenDifferentGuidStringsEveryTime()
        {
            var s1 = Any.String();
            var s2 = Any.String();

            Assert.That(s1, Is.Not.EqualTo(s2), "Generated strings aren't different");
            Assert.That(new[] { s1, s2 }, Has.All.StringMatching("^[a-f0-9]{8}(?:-[a-f0-9]{4}){3}-[a-f0-9]{12}$"));
        }
    }
}
