using System;
using NSubstitute;
using NTestDataBuilder.Tests.Entities;

namespace NTestDataBuilder.Tests.Builders
{
    class ProxyAlteringCustomerBuilder : DataBuilder<Customer, ProxyAlteringCustomerBuilder>
    {
        public const int MemberFor = 4;

        protected override void AlterProxy(Customer proxy)
        {
            proxy.CustomerForHowManyYears(Arg.Any<DateTime>()).Returns(MemberFor);
        }

        protected override Customer BuildObject()
        {
            throw new NotImplementedException();
        }
    }
}
