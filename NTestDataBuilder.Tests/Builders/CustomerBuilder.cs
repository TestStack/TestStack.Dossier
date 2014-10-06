﻿using System.Collections.Generic;
using FizzWare.NBuilder;
using NTestDataBuilder.Tests.Entities;

namespace NTestDataBuilder.Tests.Builders
{
    static class CustomerBuilderExtensions
    {
        public static IList<Customer> BuildList(this IOperable<CustomerBuilder> list)
        {
            return list.BuildList<Customer, CustomerBuilder>();
        }

        public static IList<Customer> BuildList(this IListBuilder<CustomerBuilder> list)
        {
            return list.BuildList<Customer, CustomerBuilder>();
        }
    }

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
