using System.Collections.Generic;
using System.Linq;
using FizzWare.NBuilder;
using NTestDataBuilder.Tests.Builders;
using Shouldly;
using Xunit;

namespace NTestDataBuilder.Tests
{
    public class CreateListTests
    {
        [Fact]
        public void GivenCreatingListOfSizeX_WhenListIsBuilt_ThenAListOfTheRightSizeIsGenerated()
        {
            var builderExpression = BasicCustomerBuilder.CreateListOfSize(5);

            var builtList = builderExpression.Build();

            builtList.Count.ShouldBe(5);
        }

        [Fact]
        public void GivenCreatingListOfSizeX_WhenListIsBuilt_ThenAListOfTheRightBuilderTypesIsGenerated()
        {
            var builderExpression = BasicCustomerBuilder.CreateListOfSize(5);

            var builtList = builderExpression.Build();

            builtList.ShouldBeAssignableTo<IList<BasicCustomerBuilder>>();
        }

        [Fact]
        public void GivenCreatingAList_WhenUsingNBuilderToChangeTheList_ThenTheChangesAreReflected()
        {
            var generator = new SequentialGenerator<int>();
            
            var list = CustomerBuilder.CreateListOfSize(3)
                .All().With(b => b.WithFirstName(generator.Generate().ToString()))
                .Build();

            list.Select(b => b.Get(x => x.FirstName)).ToArray()
                .ShouldBe(new[] {"0", "1", "2"});
        }
    }
}
