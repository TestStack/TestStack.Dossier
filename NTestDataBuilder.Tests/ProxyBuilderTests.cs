using System;
using System.Collections.Generic;
using NSubstitute;
using NTestDataBuilder.Tests.Entities;
using NUnit.Framework;

namespace NTestDataBuilder.Tests
{
    class ProxyBuilderTests
    {
        [Test]
        public void GivenClassToProxyWithNoProperties_WhenBuildingProxy_ReturnAClassWithNoReturnsValuesSet()
        {
            var proxyBuilder = new ProxyBuilder<Customer>(new Dictionary<string, object>());

            var proxy = proxyBuilder.Build();

            Assert.That(proxy.FirstName, Is.EqualTo(string.Empty));
            Assert.That(proxy.LastName, Is.EqualTo(string.Empty));
            Assert.That(proxy.YearJoined, Is.EqualTo(0));
        }

        [Test]
        public void GivenClassToProxyWithNoProperties_WhenBuildingProxy_ReturnAnNSubstituteProxyOfThatClass()
        {
            var proxyBuilder = new ProxyBuilder<Customer>(new Dictionary<string, object>());

            var proxy = proxyBuilder.Build();

            proxy.DidNotReceive().CustomerForHowManyYears(Arg.Any<DateTime>());
        }

        [Test]
        public void GivenClassToProxyWithSinglePropertyValue_WhenBuildingProxy_ReturnAClassWithReturnValueSet()
        {
            var proxyBuilder = new ProxyBuilder<Customer>(new Dictionary<string, object> {{"FirstName", "FirstName"}});

            var proxy = proxyBuilder.Build();

            Assert.That(proxy.FirstName, Is.EqualTo("FirstName"));
            Assert.That(proxy.LastName, Is.EqualTo(string.Empty));
            Assert.That(proxy.YearJoined, Is.EqualTo(0));
        }

        [Test]
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

            Assert.That(proxy.FirstName, Is.EqualTo("FirstName"));
            Assert.That(proxy.LastName, Is.EqualTo("LastName"));
            Assert.That(proxy.YearJoined, Is.EqualTo(1));
        }
    }
}
