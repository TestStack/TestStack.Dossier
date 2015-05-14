using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;
using TestStack.Dossier.DataSources.Generators;
using TestStack.Dossier.Lists;
using TestStack.Dossier.Tests.Builders;
using TestStack.Dossier.Tests.Stubs.ViewModels;
using Xunit;

namespace TestStack.Dossier.Tests
{
    public class BuilderBuildListTests
    {
        private DateTime _enrollmentDate = new DateTime(2004, 9, 9);

        [Fact]
        public void GivenANormalBuilderInstance_WhenCallingIsListBuilderProxy_ThenReturnFalse()
        {
            var builder = Builder<StudentViewModel>.CreateNew();

            builder.IsListBuilderProxy().ShouldBe(false);
        }

        [Fact]
        public void GivenAListBuilderProxyInstance_WhenCallingIsListBuilderProxy_ThenReturnTrue()
        {
            var builder = Builder<StudentViewModel>.CreateListOfSize(1).TheFirst(1);

            builder.IsListBuilderProxy().ShouldBe(true);
        }

        [Fact]
        public void GivenListOfBuilders_WhenCallingBuildListExplicitly_ThenAListOfEntitiesOfTheRightSizeShouldBeReturned()
        {
            var builders = Builder<StudentViewModel>.CreateListOfSize(5);

            var entities = builders.BuildList();

            entities.Count.ShouldBe(5);
        }

        [Fact]
        public void GivenListOfBuilders_WhenCallingBuildListImplicitly_ThenAListOfEntitiesOfTheRightSizeShouldBeReturned()
        {
            List<StudentViewModel> entities = Builder<StudentViewModel>.CreateListOfSize(5);

            entities.Count.ShouldBe(5);
        }

        [Fact]
        public void GivenListOfBuilders_WhenCallingBuildListExplicitly_ThenAListOfEntitiesOfTheRightTypeShouldBeReturned()
        {
            var builders = Builder<StudentViewModel>.CreateListOfSize(5);

            var entities = builders.BuildList();

            entities.ShouldBeAssignableTo<IList<StudentViewModel>>();
        }

        [Fact]
        public void GivenListOfBuilders_WhenCallingBuildListImplicitly_ThenAListOfEntitiesOfTheRightTypeShouldBeReturned()
        {
            List<StudentViewModel> entities = Builder<StudentViewModel>.CreateListOfSize(5);

            entities.ShouldBeAssignableTo<IList<StudentViewModel>>();
        }

        [Fact]
        public void GivenListOfBuilders_WhenCallingBuildListExplicitly_ThenAListOfUniqueEntitiesShouldBeReturned()
        {
            var builders = Builder<StudentViewModel>.CreateListOfSize(5);

            var entities = builders.BuildList();

            entities.ShouldBeUnique();
        }

        [Fact]
        public void GivenListOfBuilders_WhenCallingBuildListImplicitly_ThenAListOfUniqueEntitiesShouldBeReturned()
        {
            List<StudentViewModel> entities = Builder<StudentViewModel>.CreateListOfSize(5);

            entities.ShouldBeUnique();
        }

        [Fact]
        public void GivenListOfBuildersWithCustomisation_WhenBuildingEntitiesExplicitly_ThenTheCustomisationShouldTakeEffect()
        {
            var generator = new SequentialGenerator(0, 100);
            var list = StudentViewModelBuilder.CreateListOfSize(3)
                .All().With(b => b.WithFirstName(generator.Generate().ToString()));

            var data = list.BuildList();

            data.Select(c => c.FirstName).ToArray()
                .ShouldBe(new[] { "0", "1", "2" });
        }

        [Fact]
        public void GivenListOfBuildersWithCustomisation_WhenBuildingEntitiesImplicitly_ThenTheCustomisationShouldTakeEffect()
        {
            var generator = new SequentialGenerator(0, 100);

            List<StudentViewModel> data = StudentViewModelBuilder.CreateListOfSize(3)
                .All().With(b => b.WithFirstName(generator.Generate().ToString()));

            data.Select(c => c.FirstName).ToArray()
                .ShouldBe(new[] { "0", "1", "2" });
        }

        [Fact]
        public void GivenListOfBuildersWithARangeOfCustomisationMethods_WhenBuildingEntitiesExplicitly_ThenThenTheListIsBuiltAndModifiedCorrectly()
        {
            var i = 0;
            var studentViewModels = StudentViewModelBuilder.CreateListOfSize(5)
                .TheFirst(1).WithFirstName("First")
                .TheNext(1).WithLastName("Next Last")
                .TheLast(1).WithLastName("Last Last")
                .ThePrevious(2).With(b => b.WithLastName("last" + (++i).ToString()))
                .All().WhoEntrolledIn(_enrollmentDate)
                .BuildList();

            studentViewModels.ShouldBeAssignableTo<IList<StudentViewModel>>();
            studentViewModels.Count.ShouldBe(5);
            studentViewModels[0].FirstName.ShouldBe("First");
            studentViewModels[1].LastName.ShouldBe("Next Last");
            studentViewModels[2].LastName.ShouldBe("last1");
            studentViewModels[3].LastName.ShouldBe("last2");
            studentViewModels[4].LastName.ShouldBe("Last Last");
            studentViewModels.ShouldAllBe(c => c.EnrollmentDate == _enrollmentDate);
        }

        [Fact]
        public void GivenListOfBuildersWithARangeOfCustomisationMethods_WhenBuildingEntitiesImplicitly_ThenThenTheListIsBuiltAndModifiedCorrectly()
        {
            var i = 0;
            List<StudentViewModel> studentViewModels = StudentViewModelBuilder.CreateListOfSize(5)
                .TheFirst(1).WithFirstName("First")
                .TheNext(1).WithLastName("Next Last")
                .TheLast(1).WithLastName("Last Last")
                .ThePrevious(2).With(b => b.WithLastName("last" + (++i).ToString()))
                .All().WhoEntrolledIn(_enrollmentDate);

            studentViewModels.ShouldBeAssignableTo<IList<StudentViewModel>>();
            studentViewModels.Count.ShouldBe(5);
            studentViewModels[0].FirstName.ShouldBe("First");
            studentViewModels[1].LastName.ShouldBe("Next Last");
            studentViewModels[2].LastName.ShouldBe("last1");
            studentViewModels[3].LastName.ShouldBe("last2");
            studentViewModels[4].LastName.ShouldBe("Last Last");
            studentViewModels.ShouldAllBe(c => c.EnrollmentDate == _enrollmentDate);
        }

        [Fact]
        public void WhenBuildingEntitiesExplicitly_ThenTheAnonymousValueFixtureIsSharedAcrossBuilders()
        {
            var studentViewModels = StudentViewModelBuilder.CreateListOfSize(5).BuildList();

            studentViewModels.Select(x => x.Grade).ShouldBeUnique();
        }

        [Fact]
        public void WhenBuildingEntitiesImplicitly_ThenTheAnonymousValueFixtureIsSharedAcrossBuilders()
        {
            List<StudentViewModel> studentViewModels = StudentViewModelBuilder.CreateListOfSize(5);

            studentViewModels.Select(x => x.Grade).ShouldBeUnique();
        }
    }
}