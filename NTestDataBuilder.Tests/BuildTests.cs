using NTestDataBuilder.Tests.Builders;
using NTestDataBuilder.Tests.Entities;
using NUnit.Framework;

namespace NTestDataBuilder.Tests
{
    class BuildTests
    {
        [Test]
        public void GivenBasicBuilder_WhenCallingBuild_ThenReturnAnObject()
        {
            var builder = new BasicCustomerBuilder();

            var customer = builder.Build();

            Assert.That(customer, Is.TypeOf<Customer>());
        }

        [Test]
        public void GivenBuilderWithMethodCalls_WhenCallingBuild_ThenReturnAnObjectWithTheConfiguredParameters()
        {
            var builder = new CustomerBuilder()
                .WithFirstName("Matt")
                .WithLastName("Kocaj")
                .WhoJoinedIn(2010);

            var customer = builder.Build();

            Assert.That(customer.FirstName, Is.EqualTo("Matt"));
            Assert.That(customer.LastName, Is.EqualTo("Kocaj"));
            Assert.That(customer.YearJoined, Is.EqualTo(2010));
        }
    }
}
