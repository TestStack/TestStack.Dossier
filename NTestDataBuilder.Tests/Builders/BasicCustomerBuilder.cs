using NTestDataBuilder.Tests.Entities;

namespace NTestDataBuilder.Tests.Builders
{
    class BasicCustomerBuilder : DataBuilder<Customer, BasicCustomerBuilder>
    {
        protected override Customer BuildObject()
        {
            return new Customer("First Name", "Last Name", 2013);
        }
    }
}
