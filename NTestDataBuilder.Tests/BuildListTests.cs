using System.Collections.Generic;
using System.Linq;
using NTestDataBuilder.DataSources.Generators;
using NTestDataBuilder.Lists;
using NTestDataBuilder.Tests.Builders;
using NTestDataBuilder.Tests.Entities;
using Shouldly;
using Xunit;

namespace NTestDataBuilder.Tests
{
    public class BuildListTests
    {
        [Fact]
        public void GivenListOfBuilders_WhenCallingBuildList_ThenAListOfEntitiesOfTheRightSizeShouldBeReturned()
        {
            var builders = BasicCustomerBuilder.CreateListOfSize(5);

            var entities = builders.BuildList();

            entities.Count.ShouldBe(5);
        }

        [Fact]
        public void GivenListOfBuilders_WhenCallingBuildList_ThenAListOfEntitiesOfTheRightTypeShouldBeReturned()
        {
            var builders = BasicCustomerBuilder.CreateListOfSize(5);

            var entities = builders.BuildList();

            entities.ShouldBeAssignableTo<IList<Customer>>();
        }

        [Fact]
        public void GivenListOfBuilders_WhenCallingBuildList_ThenAListOfUniqueEntitiesShouldBeReturned()
        {
            var builders = BasicCustomerBuilder.CreateListOfSize(5);

            var entities = builders.BuildList();

            entities[0].ShouldNotBe(entities[1]);
            entities[0].ShouldNotBe(entities[2]);
            entities[0].ShouldNotBe(entities[3]);
            entities[0].ShouldNotBe(entities[4]);
            entities[1].ShouldNotBe(entities[2]);
            entities[1].ShouldNotBe(entities[3]);
            entities[1].ShouldNotBe(entities[4]);
            entities[2].ShouldNotBe(entities[3]);
            entities[2].ShouldNotBe(entities[4]);
            entities[3].ShouldNotBe(entities[4]);
        }

        [Fact]
        public void GivenListOfBuildersWithCustomisation_WhenBuildingEntities_ThenTheCustomisationShouldTakeEffect()
        {
            var generator = new SequentialGenerator(0, 100);
            var list = CustomerBuilder.CreateListOfSize(3)
                .All().With(b => b.WithFirstName(generator.Generate().ToString()));

            var data = list.BuildList();

            data.Select(c => c.FirstName).ToArray()
                .ShouldBe(new[]{"0", "1", "2"});
        }

        [Fact]
        public void GivenListOfBuildersWithARangeOfCustomisationMethods_WhenBuildingEntities_ThenThenTheListIsBuiltAndModifiedCorrectly()
        {
            var i = 0;
            var customers = CustomerBuilder.CreateListOfSize(5)
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
