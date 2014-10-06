using System;
using NTestDataBuilder.Tests.Builders;
using Shouldly;
using Xunit;

namespace NTestDataBuilder.Tests
{
    public class GetSetTests
    {
        private BasicCustomerBuilder _b;
        const string SetValue = "Value";

        public GetSetTests()
        {
            _b = new BasicCustomerBuilder();
        }

        [Fact]
        public void GivenAValueHasBeenSetAgainstAProperty_WhenRetrievingTheValueForThatProperty_ThenTheSetValueIsReturned()
        {
            _b.Set(x => x.FirstName, SetValue);

            var retrieved = _b.Get(x => x.FirstName);

            retrieved.ShouldBe(SetValue);
        }

        [Fact]
        public void GivenTwoValuesHaveBeenSetAgainstAProperty_WhenRetrievingTheValueForThatProperty_ThenTheLastSetValueIsReturned()
        {
            _b.Set(x => x.FirstName, "random");
            _b.Set(x => x.FirstName, SetValue);

            var retrieved = _b.Get(x => x.FirstName);

            retrieved.ShouldBe(SetValue);
        }

        [Fact]
        public void GivenAValueHasBeenSetAgainstTwoProperties_WhenRetrievingTheValueForTheFirstSetProperty_ThenTheSetValueIsReturned()
        {
            _b.Set(x => x.FirstName, SetValue);
            _b.Set(x => x.LastName, "random");

            var retrieved = _b.Get(x => x.FirstName);

            retrieved.ShouldBe(SetValue);
        }

        [Fact]
        public void GivenAValueHasBeenSetAgainstTwoProperties_WhenRetrievingTheValueForTheSecondSetProperty_ThenTheSetValueIsReturned()
        {
            _b.Set(x => x.FirstName, "random");
            _b.Set(x => x.LastName, SetValue);

            var retrieved = _b.Get(x => x.LastName);
            retrieved.ShouldBe(SetValue);
        }

        [Fact]
        public void WhenRetrievingValueForANonProperty_ThenThrowAnException()
        {
            var ex = Assert.Throws<ArgumentException>(() => _b.Get(x => x.CustomerForHowManyYears(DateTime.Now)));

            ex.Message.ShouldStartWith("Given property expression (x => x.CustomerForHowManyYears(DateTime.Now)) didn't specify a property on Customer");
            ex.ParamName.ShouldBe("property");
        }

        [Fact]
        public void WhenSettingAValue_ThenReturntheBuilder()
        {
            _b.Set(x => x.FirstName, "")
                .ShouldBe(_b);
        }
    }
}
