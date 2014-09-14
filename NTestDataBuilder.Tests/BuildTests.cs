using NTestDataBuilder.Tests.Builders;
using NTestDataBuilder.Tests.Entities;
using Shouldly;
using Xunit;

namespace NTestDataBuilder.Tests
{
    public class BuildTests
    {
        [Fact]
        public void GivenBasicBuilder_WhenCallingBuild_ThenReturnAnObject()
        {
            var builder = new BasicCustomerBuilder();

            var customer = builder.Build();

            customer.ShouldBeOfType<Customer>();
        }

        [Fact]
        public void GivenBuilderWithMethodCalls_WhenCallingBuild_ThenReturnAnObjectWithTheConfiguredParameters()
        {
            var builder = new CustomerBuilder()
                .WithFirstName("Matt")
                .WithLastName("Kocaj")
                .WhoJoinedIn(2010);

            var customer = builder.Build();

            customer.FirstName.ShouldBe("Matt");
            customer.LastName.ShouldBe("Kocaj");
            customer.YearJoined.ShouldBe(2010);
        }
    }
}
