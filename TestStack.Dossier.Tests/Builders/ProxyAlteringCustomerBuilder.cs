using System;
using NSubstitute;
using TestStack.Dossier.Tests.Entities;

namespace TestStack.Dossier.Tests.Builders
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
