﻿using TestStack.Dossier.Factories;
using TestStack.Dossier.Tests.Stubs.Entities;

namespace TestStack.Dossier.Tests.Builders
{
    class AutoConstructorCustomerBuilder : TestDataBuilder<Customer, AutoConstructorCustomerBuilder>
    {
        public AutoConstructorCustomerBuilder WithFirstName(string firstName)
        {
            return Set(x => x.FirstName, firstName);
        }

        public AutoConstructorCustomerBuilder WithLastName(string lastName)
        {
            return Set(x => x.LastName, lastName);
        }

        public AutoConstructorCustomerBuilder WhoJoinedIn(int year)
        {
            return Set(x => x.YearJoined, year);
        }

        protected override Customer BuildObject()
        {
            return BuildUsing<ConstructorFactory>();
        }
    }
}
