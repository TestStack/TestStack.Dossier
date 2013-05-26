using System;
using NSubstitute;
using NTestDataBuilder.Tests.Entities;

namespace NTestDataBuilder.Tests.Builders
{
    class ProxyAlteringCustomerBuilder : TestDataBuilder<Customer, ProxyAlteringCustomerBuilder>
    {
        private int _years;

        public ProxyAlteringCustomerBuilder HasBeenMemberForYears(int years)
        {
            _years = years;
            return this;
        }

        protected override void AlterProxy(Customer proxy)
        {
            proxy.CustomerForHowManyYears(Arg.Any<DateTime>()).Returns(_years);
        }

        protected override Customer BuildObject()
        {
            throw new NotImplementedException();
        }
    }
}
