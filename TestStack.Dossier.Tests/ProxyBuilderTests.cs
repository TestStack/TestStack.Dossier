using System;
using System.Collections.Generic;
using NSubstitute;
using Shouldly;
using TestStack.Dossier.Tests.Entities;
using Xunit;

namespace TestStack.Dossier.Tests
{
    class ProxyBuilderTests
    {
        [Fact]
        public void GivenClassToProxyWithNoProperties_WhenBuildingProxy_ReturnAClassWithNoReturnsValuesSet()
        {
            var proxyBuilder = new ProxyBuilder<Customer>(new Dictionary<string, object>());

            var proxy = proxyBuilder.Build();

            proxy.FirstName.ShouldBe(string.Empty);
            proxy.LastName.ShouldBe(string.Empty);
            proxy.YearJoined.ShouldBe(0);
        }

        [Fact]
        public void GivenClassToProxyWithNoProperties_WhenBuildingProxy_ReturnAnNSubstituteProxyOfThatClass()
        {
            var proxyBuilder = new ProxyBuilder<Customer>(new Dictionary<string, object>());

            var proxy = proxyBuilder.Build();

            proxy.DidNotReceive().CustomerForHowManyYears(Arg.Any<DateTime>());
        }

        [Fact]
        public void GivenClassToProxyWithSinglePropertyValue_WhenBuildingProxy_ReturnAClassWithReturnValueSet()
        {
            var proxyBuilder = new ProxyBuilder<Customer>(new Dictionary<string, object> {{"FirstName", "FirstName"}});

            var proxy = proxyBuilder.Build();

            proxy.FirstName.ShouldBe("FirstName");
            proxy.LastName.ShouldBe(string.Empty);
            proxy.YearJoined.ShouldBe(0);
        }

        [Fact]
        public void GivenClassToProxyWithMultiplePropertyValues_WhenBuildingProxy_ReturnAClassWithReturnValueSet()
        {
            var proxyBuilder = new ProxyBuilder<Customer>(new Dictionary<string, object>
                {
                    { "FirstName", "FirstName" },
                    { "LastName", "LastName" },
                    { "YearJoined", 1 },
                }
            );

            var proxy = proxyBuilder.Build();

            proxy.FirstName.ShouldBe("FirstName");
            proxy.LastName.ShouldBe("LastName");
            proxy.YearJoined.ShouldBe(1);
        }

        [Fact]
        public void GivenClassWithSomeVirtualProperties_WhenBuildingProxy_ThenOnlyVirtualMembersAreProxied()
        {
            var proxyBuilder = new ProxyBuilder<Company>(new Dictionary<string, object>()
            {
                {"Name", "Vandelay Industries"},
                {"EmployeeCount", 100}
            });

            var proxy = proxyBuilder.Build();

            proxy.Name.ShouldBe("Vandelay Industries");
            proxy.EmployeeCount.ShouldBe(0);
        }
    }
}
    