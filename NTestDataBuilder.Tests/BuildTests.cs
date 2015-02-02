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

        [Test]
        public void GivenBuilder_WhenCallingSet_ShouldOverrideValues()
        {
            var builder = new CustomerBuilder()
                .Set(x => x.FirstName, "Pi")
                .Set(x => x.LastName, "Lanningham")
                .Set(x => x.YearJoined, 2014);

            var customer = builder.Build();
            Assert.That(customer.FirstName, Is.EqualTo("Pi"));
            Assert.That(customer.LastName, Is.EqualTo("Lanningham"));
            Assert.That(customer.YearJoined, Is.EqualTo(2014));
        }
    }
}
