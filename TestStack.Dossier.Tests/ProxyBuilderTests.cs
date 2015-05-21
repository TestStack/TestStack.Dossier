using System;
using System.Collections.Generic;
using NSubstitute;
using Shouldly;
using TestStack.Dossier.Tests.TestHelpers.Objects.Entities;
using Xunit;

namespace TestStack.Dossier.Tests
{
    class ProxyBuilderTests
    {
        [Fact]
        public void GivenClassToProxyWithNoProperties_WhenBuildingProxy_ReturnAClassWithNoReturnsValuesSet()
        {
            var proxyBuilder = new ProxyBuilder<Customer>(new Dictionary<string, Func<object>>());

            var proxy = proxyBuilder.Build();

            proxy.FirstName.ShouldBe(string.Empty);
            proxy.LastName.ShouldBe(string.Empty);
            proxy.YearJoined.ShouldBe(0);
        }

        [Fact]
        public void GivenClassToProxyWithNoProperties_WhenBuildingProxy_ReturnAnNSubstituteProxyOfThatClass()
        {
            var proxyBuilder = new ProxyBuilder<Customer>(new Dictionary<string, Func<object>>());

            var proxy = proxyBuilder.Build();

            proxy.DidNotReceive().CustomerForHowManyYears(Arg.Any<DateTime>());
        }

        [Fact]
        public void GivenClassToProxyWithSinglePropertyValue_WhenBuildingProxy_ReturnAClassWithReturnValueSetFromFunction()
        {
            int nonce = new Random().Next(0, 100);
            var proxyBuilder = new ProxyBuilder<Customer>(new Dictionary<string, Func<object>> {{"FirstName", () => "FirstName" + nonce}});

            var proxy = proxyBuilder.Build();

            proxy.FirstName.ShouldBe("FirstName" + nonce);
            proxy.LastName.ShouldBe(string.Empty);
            proxy.YearJoined.ShouldBe(0);
        }

        [Fact]
        public void GivenClassToProxyWithMultiplePropertyValues_WhenBuildingProxy_ReturnAClassWithReturnValueSet()
        {
            var proxyBuilder = new ProxyBuilder<Customer>(new Dictionary<string, Func<object>>
                {
                    { "FirstName", () => "FirstName" },
                    { "LastName", () => "LastName" },
                    { "YearJoined", () => 1 },
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
            var proxyBuilder = new ProxyBuilder<Company>(new Dictionary<string, Func<object>>()
            {
                {"Name", () => "Vandelay Industries"},
                {"EmployeeCount", () => 100}
            });

            var proxy = proxyBuilder.Build();

            proxy.Name.ShouldBe("Vandelay Industries");
            proxy.EmployeeCount.ShouldBe(0);
        }
    }
}
    