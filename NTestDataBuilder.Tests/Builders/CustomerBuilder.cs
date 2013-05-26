using NTestDataBuilder.Tests.Entities;

namespace NTestDataBuilder.Tests.Builders
{
    class CustomerBuilder : DataBuilder<Customer, CustomerBuilder>
    {
        public CustomerBuilder()
        {
            WithFirstName("Rob");
            WithLastName("Moore");
            WhoJoinedIn(2013);
        }

        public CustomerBuilder WithFirstName(string firstName)
        {
            Set(x => x.FirstName, firstName);
            return this;
        }

        public CustomerBuilder WithLastName(string lastName)
        {
            Set(x => x.LastName, lastName);
            return this;
        }

        public CustomerBuilder WhoJoinedIn(int yearJoined)
        {
            Set(x => x.YearJoined, yearJoined);
            return this;
        }

        public override Customer Build()
        {
            return new Customer(
                Get(x => x.FirstName),
                Get(x => x.LastName),
                Get(x => x.YearJoined)
            );
        }
    }
}
