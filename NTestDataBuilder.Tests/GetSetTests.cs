using NTestDataBuilder.Tests.Builders;
using NUnit.Framework;

namespace NTestDataBuilder.Tests
{
    class GetSetTests
    {
        [Test]
        public void GivenAValueHasBeenSetAgainstAProperty_WhenRetrievingTheValueForThatProperty_ThenTheSetValueIsReturned()
        {
            const string set = "Value";
            var b = new BasicCustomerBuilder();
            b.Set(x => x.FirstName, set);

            var retrieved = b.Get(x => x.FirstName);

            Assert.That(retrieved, Is.EqualTo(set));
        }

        [Test]
        public void GivenTwoValuesHaveBeenSetAgainstAProperty_WhenRetrievingTheValueForThatProperty_ThenTheLastSetValueIsReturned()
        {
            const string set = "Value";
            var b = new BasicCustomerBuilder();
            b.Set(x => x.FirstName, "random");
            b.Set(x => x.FirstName, set);

            var retrieved = b.Get(x => x.FirstName);

            Assert.That(retrieved, Is.EqualTo(set));
        }

        [Test]
        public void GivenAValueHasBeenSetAgainstTwoProperties_WhenRetrievingTheValueForTheFirstSetProperty_ThenTheSetValueIsReturned()
        {
            const string set = "Value";
            var b = new BasicCustomerBuilder();
            b.Set(x => x.FirstName, set);
            b.Set(x => x.LastName, "random");

            var retrieved = b.Get(x => x.FirstName);

            Assert.That(retrieved, Is.EqualTo(set));
        }

        [Test]
        public void GivenAValueHasBeenSetAgainstTwoProperties_WhenRetrievingTheValueForTheSecondSetProperty_ThenTheSetValueIsReturned()
        {
            const string set = "Value";
            var b = new BasicCustomerBuilder();
            b.Set(x => x.FirstName, "random");
            b.Set(x => x.LastName, set);

            var retrieved = b.Get(x => x.LastName);

            Assert.That(retrieved, Is.EqualTo(set));
        }
    }
}
