using NTestDataBuilder.Tests.Builders;
using NUnit.Framework;

namespace NTestDataBuilder.Tests
{
    public class GetAnonymousTests
    {
        private BasicCustomerBuilder _b;

        [SetUp]
        public void Setup()
        {
            _b = new BasicCustomerBuilder();
        }

        [Test]
        public void GivenNoValueHasBeenSetForAStringProperty_WhenRetrievingTheValueForThatProperty_ThenReturnPropertyNameFollowedByGuid()
        {
            Assert.That(_b.Get(x => x.FirstName), Is.StringMatching("^FirstName[a-f0-9]{8}(?:-[a-f0-9]{4}){3}-[a-f0-9]{12}$"));
        }

        [Test]
        public void GivenNoValueHasBeenSetForAnIntProperty_WhenRetrievingTheValueForThatProperty_ThenReturnDefaultValue()
        {
            Assert.That(_b.Get(x => x.YearJoined), Is.EqualTo(default(int)));
        }
    }
}
