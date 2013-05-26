using System.Collections.Generic;
using FizzWare.NBuilder;
using NTestDataBuilder.Tests.Entities;

namespace NTestDataBuilder.Tests.Builders
{
    static class CustomerBuilderExtensions
    {
        public static IList<Customer> BuildDataList(this IOperable<CustomerBuilder> list)
        {
            return list.BuildDataList<Customer, CustomerBuilder>();
        }

        public static IList<Customer> BuildDataList(this IListBuilder<CustomerBuilder> list)
        {
            return list.BuildDataList<Customer, CustomerBuilder>();
        }
    }

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

        protected override Customer BuildObject()
        {
            return new Customer(
                Get(x => x.FirstName),
                Get(x => x.LastName),
                Get(x => x.YearJoined)
            );
        }
    }
}
