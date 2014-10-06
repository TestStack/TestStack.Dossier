using System.Collections.Generic;
using NTestDataBuilder.Lists;
using NTestDataBuilder.Tests.Builders;
using NTestDataBuilder.Tests.Entities;
using Xunit;
using Shouldly;

namespace NTestDataBuilder.Tests
{
    public class ListBuilderTests
    {
        [Fact]
        public void WhenBuildingAListOfObjects_ThenThenTheListIsBuiltAndModifiedCorrectly()
        {
            var i = 0;
            var customers = CustomerBuilder.ListOfSize(5)
                .TheFirst(1).WithFirstName("First")
                .TheNext(1).WithLastName("Next Last")
                .TheLast(1).WithLastName("Last Last")
                .ThePrevious(2).With(b => b.WithLastName("last" + (++i).ToString()))
                .All().WhoJoinedIn(1999)
                .BuildList();

            customers.ShouldBeAssignableTo<IList<Customer>>();
            customers.Count.ShouldBe(5);
            customers[0].FirstName.ShouldBe("First");
            customers[1].LastName.ShouldBe("Next Last");
            customers[2].LastName.ShouldBe("last1");
            customers[3].LastName.ShouldBe("last2");
            customers[4].LastName.ShouldBe("Last Last");
            customers.ShouldAllBe(c => c.YearJoined == 1999);
        }
    }
}
