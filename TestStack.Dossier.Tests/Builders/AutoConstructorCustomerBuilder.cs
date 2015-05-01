using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.Dossier.Tests.Entities;

namespace TestStack.Dossier.Tests.Builders
{
    class AutoConstructorCustomerBuilder : TestDataBuilder<Customer, AutoConstructorCustomerBuilder>
    {
        protected override Customer BuildObject()
        {
            return BuildByConstructor();
        }

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
    }
}
