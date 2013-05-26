using System.Linq;
using FizzWare.NBuilder;
using NTestDataBuilder.Tests.Builders;
using NTestDataBuilder.Tests.Entities;
using NUnit.Framework;

namespace NTestDataBuilder.Tests
{
    class BuildListTests
    {
        [Test]
        public void GivenListOfBuilders_WhenCallingBuildList_ThenAListOfEntitiesOfTheRightSizeShouldBeReturned()
        {
            var builders = BasicCustomerBuilder.CreateListOfSize(5);

            var entities = builders.BuildList<Customer, BasicCustomerBuilder>();

            Assert.That(entities, Has.Count.EqualTo(5));
        }

        [Test]
        public void GivenListOfBuilders_WhenCallingBuildList_ThenAListOfEntitiesOfTheRightTypeShouldBeReturned()
        {
            var builders = BasicCustomerBuilder.CreateListOfSize(5);

            var entities = builders.BuildList<Customer, BasicCustomerBuilder>();

            Assert.That(entities, Has.All.With.TypeOf<Customer>());
        }

        [Test]
        public void GivenListOfBuilders_WhenCallingBuildList_ThenAListOfUniqueEntitiesShouldBeReturned()
        {
            var builders = BasicCustomerBuilder.CreateListOfSize(5);

            var entities = builders.BuildList<Customer, BasicCustomerBuilder>();

            Assert.That(entities, Is.Unique);
        }

        [Test]
        public void GivenListOfBuildersWithNoCustomisation_WhenCallingExtensionMethodToBuildList_ThenListOfTheRightSizeShouldBeReturned()
        {
            var builders = CustomerBuilder.CreateListOfSize(5);

            var entities = builders.BuildList();

            Assert.That(entities, Has.Count.EqualTo(5));
        }

        [Test]
        public void GivenListOfBuildersWithNoCustomisation_WhenCallingExtensionMethodToBuildList_ThenListOfTheRightTypeShouldBeReturned()
        {
            var builders = CustomerBuilder.CreateListOfSize(5);

            var entities = builders.BuildList();

            Assert.That(entities, Has.All.TypeOf<Customer>());
        }

        [Test]
        public void GivenListOfBuildersWithNoCustomisation_WhenCallingExtensionMethodToBuildList_ThenAListOfUniqueEntitiesShouldBeReturned()
        {
            var builders = CustomerBuilder.CreateListOfSize(5);

            var entities = builders.BuildList();

            Assert.That(entities, Is.Unique);
        }

        [Test]
        public void GivenListOfBuildersWithCustomisation_WhenCallingExtensionMethodToBuildList_ThenTheCustomisationShouldTakeEffect()
        {
            var generator = new SequentialGenerator<int>();
            var list = CustomerBuilder.CreateListOfSize(3)
                .All().With(b => b.WithFirstName(generator.Generate().ToString()));

            var data = list.BuildList();

            Assert.That(data.Select(c => c.FirstName), Is.EqualTo(new[]{"0", "1", "2"}));
        }
    }
}
