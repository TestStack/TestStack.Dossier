using System.Collections.Generic;
using System.Linq;
using FizzWare.NBuilder;
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

            var entities = builders.BuildList<Customer, BasicCustomerBuilder>();

            entities.Count.ShouldBe(5);
        }

        [Fact]
        public void GivenListOfBuilders_WhenCallingBuildList_ThenAListOfEntitiesOfTheRightTypeShouldBeReturned()
        {
            var builders = BasicCustomerBuilder.CreateListOfSize(5);

            var entities = builders.BuildList<Customer, BasicCustomerBuilder>();

            entities.ShouldBeAssignableTo<IList<Customer>>();
        }

        [Fact]
        public void GivenListOfBuilders_WhenCallingBuildList_ThenAListOfUniqueEntitiesShouldBeReturned()
        {
            var builders = BasicCustomerBuilder.CreateListOfSize(5);

            var entities = builders.BuildList<Customer, BasicCustomerBuilder>();

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
        public void GivenListOfBuildersWithNoCustomisation_WhenCallingExtensionMethodToBuildList_ThenListOfTheRightSizeShouldBeReturned()
        {
            var builders = CustomerBuilder.CreateListOfSize(5);

            var entities = builders.BuildList();

            entities.Count.ShouldBe(5);
        }

        [Fact]
        public void GivenListOfBuildersWithNoCustomisation_WhenCallingExtensionMethodToBuildList_ThenListOfTheRightTypeShouldBeReturned()
        {
            var builders = CustomerBuilder.CreateListOfSize(5);

            var entities = builders.BuildList();

            entities.ShouldBeAssignableTo<IList<Customer>>();
        }

        [Fact]
        public void GivenListOfBuildersWithNoCustomisation_WhenCallingExtensionMethodToBuildList_ThenAListOfUniqueEntitiesShouldBeReturned()
        {
            var builders = CustomerBuilder.CreateListOfSize(5);

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
        public void GivenListOfBuildersWithCustomisation_WhenCallingExtensionMethodToBuildList_ThenTheCustomisationShouldTakeEffect()
        {
            var generator = new SequentialGenerator<int>();
            var list = CustomerBuilder.CreateListOfSize(3)
                .All().With(b => b.WithFirstName(generator.Generate().ToString()));

            var data = list.BuildList();

            data.Select(c => c.FirstName).ToArray()
                .ShouldBe(new[]{"0", "1", "2"});
        }
    }
}
