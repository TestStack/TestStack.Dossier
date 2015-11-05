using TestStack.Dossier.Tests.TestHelpers.Objects.Entities;

namespace TestStack.Dossier.Tests.TestHelpers.Builders
{
    public class BasicCustomerBuilder : TestDataBuilder<Customer, BasicCustomerBuilder>
    {
        protected override Customer BuildObject()
        {
            return new Customer("customer1", "First Name", "Last Name", 2013, new Address("AddressIdentifier", 5, "Street Name", "Suburb", "City", "PostCode"),  CustomerClass.Normal);
        }
    }
}
