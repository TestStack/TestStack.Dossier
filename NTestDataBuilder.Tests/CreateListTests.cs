using System.Linq;
using FizzWare.NBuilder;
using NTestDataBuilder.Tests.Builders;
using NUnit.Framework;

namespace NTestDataBuilder.Tests
{
    class CreateListTests
    {
        [Test]
        public void GivenCreatingListOfSizeX_WhenListIsBuilt_ThenAListOfTheRightSizeIsGenerated()
        {
            var builderExpression = BasicCustomerBuilder.CreateListOfSize(5);

            var builtList = builderExpression.Build();

            Assert.That(builtList, Has.Count.EqualTo(5));
        }

        [Test]
        public void GivenCreatingListOfSizeX_WhenListIsBuilt_ThenAListOfUniqueBuildersIsGenerated()
        {
            var builderExpression = BasicCustomerBuilder.CreateListOfSize(5);

            var builtList = builderExpression.Build();

            Assert.That(builtList, Is.Unique);
        }

        [Test]
        public void GivenCreatingListOfSizeX_WhenListIsBuilt_ThenAListOfTheRightBuilderTypesIsGenerated()
        {
            var builderExpression = BasicCustomerBuilder.CreateListOfSize(5);

            var builtList = builderExpression.Build();

            Assert.That(builtList, Has.All.With.TypeOf<BasicCustomerBuilder>());
        }

        [Test]
        public void GivenCreatingAList_WhenUsingNBuilderToChangeTheList_ThenTheChangesAreReflected()
        {
            var generator = new SequentialGenerator<int>();
            
            var list = CustomerBuilder.CreateListOfSize(3)
                .All().With(b => b.WithFirstName(generator.Generate().ToString()))
                .Build();

            Assert.That(list.Select(b => b.Get(x => x.FirstName)), Is.EqualTo(new[]{"0", "1", "2"}));
        }
    }
}
