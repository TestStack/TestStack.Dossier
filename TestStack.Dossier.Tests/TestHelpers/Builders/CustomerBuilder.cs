using TestStack.Dossier.Tests.TestHelpers.Objects.Entities;

namespace TestStack.Dossier.Tests.TestHelpers.Builders
{
    public class CustomerBuilder : TestDataBuilder<Customer, CustomerBuilder>
    {
        public virtual CustomerBuilder WithFirstName(string firstName)
        {
            return Set(x => x.FirstName, firstName);
        }

        public virtual CustomerBuilder WithLastName(string lastName)
        {
            return Set(x => x.LastName, lastName);
        }

        public virtual CustomerBuilder WhoJoinedIn(int yearJoined)
        {
            return Set(x => x.YearJoined, yearJoined);
        }

        public virtual CustomerBuilder WithPostalAdressIdentifier(string identifier)
        {
            return Set(x => x.PostalAddress.Identifier, identifier);
        }

        protected override Customer BuildObject()
        {
            return new Customer(
                Get(x => x.Identifier),
                Get(x => x.FirstName),
                Get(x => x.LastName),
                Get(x => x.YearJoined),
                new Address(
                    Get(x => x.PostalAddress.Identifier),
                    Get(x => x.PostalAddress.StreetNo),
                    Get(x => x.PostalAddress.StreetName),
                    Get(x => x.PostalAddress.Suburb),
                    Get(x => x.PostalAddress.City),
                    Get(x => x.PostalAddress.PostCode)
                    ), 
                Get(x => x.CustomerClass)
            );
        }
    }
}
