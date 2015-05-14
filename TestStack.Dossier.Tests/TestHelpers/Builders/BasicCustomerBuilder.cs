using System;
using System.Linq.Expressions;
using TestStack.Dossier.Tests.TestHelpers.Objects.Entities;

namespace TestStack.Dossier.Tests.TestHelpers.Builders
{
    public class BasicCustomerBuilder : TestDataBuilder<Customer, BasicCustomerBuilder>
    {
        protected override Customer BuildObject()
        {
            return new Customer("customer1", "First Name", "Last Name", 2013, CustomerClass.Normal);
        }
    }
}
