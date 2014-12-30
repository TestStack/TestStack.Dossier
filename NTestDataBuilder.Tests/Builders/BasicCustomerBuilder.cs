using System;
using System.Linq.Expressions;
using NTestDataBuilder.Tests.Entities;

namespace NTestDataBuilder.Tests.Builders
{
    public class BasicCustomerBuilder : TestDataBuilder<Customer, BasicCustomerBuilder>
    {
        protected override Customer BuildObject()
        {
            return new Customer("First Name", "Last Name", 2013);
        }

        public new BasicCustomerBuilder Set<TValue>(Expression<Func<Customer, TValue>> property, TValue value)
        {
            return base.Set(property, value);
        }
    }
}
