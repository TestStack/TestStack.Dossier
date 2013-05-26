using NTestDataBuilder.Tests.Builders;
using NUnit.Framework;

namespace NTestDataBuilder.Tests
{
    class GetOrDefaultTests
    {
        private BasicCustomerBuilder _b;
        const string SetValue = "Value";

        [SetUp]
        public void Setup()
        {
            _b = new BasicCustomerBuilder();
        }

        [Test]
        public void GivenAValueHasBeenSetAgainstAProperty_WhenRetrievingTheValueForThatProperty_ThenTheSetValueIsReturned()
        {
            _b.Set(x => x.FirstName, SetValue);

            var retrieved = _b.GetOrDefault(x => x.FirstName);

            Assert.That(retrieved, Is.EqualTo(SetValue));
        }

        [Test]
        public void GivenNoValueHasBeenSetForAStringProperty_WhenRetrievingTheValueForThatProperty_ThenReturnNull()
        {
            var retrieved = _b.GetOrDefault(x => x.FirstName);

            Assert.That(retrieved, Is.EqualTo(null));
        }

        [Test]
        public void GivenNoValueHasBeenSetForAnIntProperty_WhenRetrievingTheValueForThatProperty_ThenReturn0()
        {
            var retrieved = _b.GetOrDefault(x => x.YearJoined);

            Assert.That(retrieved, Is.EqualTo(0));
        }
    }
}
