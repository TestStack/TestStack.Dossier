using NTestDataBuilder.Tests.Entities;

namespace NTestDataBuilder.Tests.Builders
{
    class BasicCustomerBuilder : DataBuilder<Customer, BasicCustomerBuilder>
    {
        public override Customer Build()
        {
            return new Customer("First Name", "Last Name");
        }
    }
}
