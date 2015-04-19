using Shouldly;
using TestStack.Dossier.Tests.Builders;
using Xunit;

namespace TestStack.Dossier.Tests
{
    public class GetOrDefaultTests
    {
        private readonly BasicCustomerBuilder _b;
        const string SetValue = "Value";

        public GetOrDefaultTests()
        {
            _b = new BasicCustomerBuilder();
        }

        [Fact]
        public void GivenAValueHasBeenSetAgainstAProperty_WhenRetrievingTheValueForThatProperty_ThenTheSetValueIsReturned()
        {
            _b.Set(x => x.FirstName, SetValue);

            var retrieved = _b.GetOrDefault(x => x.FirstName);

            retrieved.ShouldBe(SetValue);
        }

        [Fact]
        public void GivenNoValueHasBeenSetForAStringProperty_WhenRetrievingTheValueForThatProperty_ThenReturnNull()
        {
            var retrieved = _b.GetOrDefault(x => x.FirstName);

            retrieved.ShouldBe(null);
        }

        [Fact]
        public void GivenNoValueHasBeenSetForAnIntProperty_WhenRetrievingTheValueForThatProperty_ThenReturn0()
        {
            var retrieved = _b.GetOrDefault(x => x.YearJoined);

            retrieved.ShouldBe(0);
        }
    }
}
