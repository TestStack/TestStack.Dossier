using NTestDataBuilder.Tests.Builders;
using NTestDataBuilder.Tests.TestHelpers;
using NUnit.Framework;

namespace NTestDataBuilder.Tests
{
    public class GetAnonymousTests
    {
        private BasicCustomerBuilder _b;

        [SetUp]
        public void Setup()
        {
            AnonymousValueFixture.ClearGlobalState();
            _b = new BasicCustomerBuilder();
        }

        [Test]
        public void GivenNoValueHasBeenSetForAPropertyAndAGlobalAndLocalSupplierHasBeenRegisteredThatWontAcceptThatProperty_WhenRetrievingTheValueForThatProperty_ThenDontUseLocalOrGlobalValue()
        {
            const string globalVal = "global";
            const string localVal = "local";
            AnonymousValueFixture.GlobalValueSuppliers.Add(new StaticAnonymousValueSupplier(globalVal));
            _b.Any.LocalValueSuppliers.Add(new StaticAnonymousValueSupplier(localVal));

            Assert.That(_b.Get(x => x.YearJoined), Is.Not.EqualTo(localVal));
            Assert.That(_b.Get(x => x.YearJoined), Is.Not.EqualTo(globalVal));
        }

        [Test]
        public void GivenNoValueHasBeenSetForAPropertyAndAGlobalAndLocalSupplierHasBeenRegisteredThatWillAcceptThatProperty_WhenRetrievingTheValueForThatProperty_ThenReturnLocalSupplierValue()
        {
            const string globalVal = "global";
            const string localVal = "local";
            AnonymousValueFixture.GlobalValueSuppliers.Add(new StaticAnonymousValueSupplier(globalVal));
            _b.Any.LocalValueSuppliers.Add(new StaticAnonymousValueSupplier(localVal));

            Assert.That(_b.Get(x => x.FirstName), Is.EqualTo(localVal));
        }

        [Test]
        public void GivenNoValueHasBeenSetForAPropertyAndAGlobalSupplierHasBeenRegisteredThatWillAcceptThatProperty_WhenRetrievingTheValueForThatProperty_ThenReturnGlobalSupplierValue()
        {
            const string globalVal = "global";
            AnonymousValueFixture.GlobalValueSuppliers.Add(new StaticAnonymousValueSupplier(globalVal));

            Assert.That(_b.Get(x => x.FirstName), Is.EqualTo(globalVal));
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
