using System;
using NSubstitute;
using NTestDataBuilder.Tests.Builders;
using NUnit.Framework;

namespace NTestDataBuilder.Tests
{
    class AsProxyTests
    {
        [Test]
        public void GivenBuilderIsSetAsProxy_WhenBuilding_AnNSubstituteProxyIsReturned()
        {
            var builder = new CustomerBuilder().AsProxy();

            var proxy = builder.Build();

            proxy.CustomerForHowManyYears(Arg.Any<DateTime>()).Returns(100);
            Assert.That(proxy.CustomerForHowManyYears(DateTime.Now), Is.EqualTo(100));
        }

        [Test]
        public void GivenBuilderThatAltersProxyIsSetAsProxy_WhenBuilding_TheProxyIsAltered()
        {
            var builder = new ProxyAlteringCustomerBuilder()
                .AsProxy()
                .HasBeenMemberForYears(10);

            var proxy = builder.Build();

            Assert.That(proxy.CustomerForHowManyYears(DateTime.Now), Is.EqualTo(10));
        }
    }
}
