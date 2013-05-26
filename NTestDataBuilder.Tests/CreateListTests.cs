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
        public void GivenCreatingListOfSizeX_WhenListIsBuilt_ThenAListOfTheBuildersIsGenerated()
        {
            var builderExpression = BasicCustomerBuilder.CreateListOfSize(5);

            var builtList = builderExpression.Build();

            Assert.That(builtList, Has.All.With.TypeOf<BasicCustomerBuilder>());
        }
    }
}
