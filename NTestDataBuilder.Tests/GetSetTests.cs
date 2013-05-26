using NTestDataBuilder.Tests.Builders;
using NUnit.Framework;

namespace NTestDataBuilder.Tests
{
    class GetSetTests
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

            var retrieved = _b.Get(x => x.FirstName);

            Assert.That(retrieved, Is.EqualTo(SetValue));
        }

        [Test]
        public void GivenTwoValuesHaveBeenSetAgainstAProperty_WhenRetrievingTheValueForThatProperty_ThenTheLastSetValueIsReturned()
        {
            _b.Set(x => x.FirstName, "random");
            _b.Set(x => x.FirstName, SetValue);

            var retrieved = _b.Get(x => x.FirstName);

            Assert.That(retrieved, Is.EqualTo(SetValue));
        }

        [Test]
        public void GivenAValueHasBeenSetAgainstTwoProperties_WhenRetrievingTheValueForTheFirstSetProperty_ThenTheSetValueIsReturned()
        {
            _b.Set(x => x.FirstName, SetValue);
            _b.Set(x => x.LastName, "random");

            var retrieved = _b.Get(x => x.FirstName);

            Assert.That(retrieved, Is.EqualTo(SetValue));
        }

        [Test]
        public void GivenAValueHasBeenSetAgainstTwoProperties_WhenRetrievingTheValueForTheSecondSetProperty_ThenTheSetValueIsReturned()
        {
            _b.Set(x => x.FirstName, "random");
            _b.Set(x => x.LastName, SetValue);

            var retrieved = _b.Get(x => x.LastName);

            Assert.That(retrieved, Is.EqualTo(SetValue));
        }
    }
}
