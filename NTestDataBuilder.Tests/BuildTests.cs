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
    }
}
