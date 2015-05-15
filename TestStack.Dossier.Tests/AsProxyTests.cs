using System;
using NSubstitute;
using Shouldly;
using TestStack.Dossier.Tests.TestHelpers.Builders;
using Xunit;

namespace TestStack.Dossier.Tests
{
    public class AsProxyTests
    {
        [Fact]
        public void GivenBuilderIsSetAsProxy_WhenBuilding_AnNSubstituteProxyIsReturned()
        {
            var builder = new CustomerBuilder().AsProxy();

            var proxy = builder.Build();

            proxy.CustomerForHowManyYears(Arg.Any<DateTime>()).Returns(100);
            proxy.CustomerForHowManyYears(DateTime.Now).ShouldBe(100);
        }

        [Fact]
        public void GivenBuilderThatAltersProxyIsSetAsProxy_WhenBuilding_TheProxyIsAltered()
        {
            var builder = new ProxyAlteringCustomerBuilder()
                .AsProxy()
                .HasBeenMemberForYears(10);

            var proxy = builder.Build();

            proxy.CustomerForHowManyYears(DateTime.Now).ShouldBe(10);
        }
    }
}
