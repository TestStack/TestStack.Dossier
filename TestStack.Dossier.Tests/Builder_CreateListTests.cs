using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;
using TestStack.Dossier.DataSources.Generators;
using TestStack.Dossier.Factories;
using TestStack.Dossier.Lists;
using TestStack.Dossier.Tests.TestHelpers.Objects.Examples;
using TestStack.Dossier.Tests.TestHelpers.Objects.ViewModels;
using Xunit;

namespace TestStack.Dossier.Tests
{
    // ReSharper disable once InconsistentNaming
    public class Builder_CreateListTests
    {
        private readonly DateTime _enrollmentDate = new DateTime(2004, 9, 9);

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
        public void GivenListOfBuilders_WhenCallingBuildListExplicitly_ThenAListOfObjectsOfTheRightSizeShouldBeReturned()
        {
            var builders = Builder<StudentViewModel>.CreateListOfSize(5);

            var objects = builders.BuildList();

            objects.Count.ShouldBe(5);
        }

        [Fact]
        public void GivenListOfBuilders_WhenCallingBuildListImplicitly_ThenAListOfObjectsOfTheRightSizeShouldBeReturned()
        {
            List<StudentViewModel> objects = Builder<StudentViewModel>.CreateListOfSize(5);

            objects.Count.ShouldBe(5);
        }

        [Fact]
        public void GivenListOfBuilders_WhenCallingBuildListExplicitly_ThenAListOfObjectsOfTheRightTypeShouldBeReturned()
        {
            var builders = Builder<StudentViewModel>.CreateListOfSize(5);

            var objects = builders.BuildList();

            objects.ShouldBeAssignableTo<IList<StudentViewModel>>();
        }

        [Fact]
        public void GivenListOfBuilders_WhenCallingBuildListImplicitly_ThenAListOfObjectsOfTheRightTypeShouldBeReturned()
        {
            List<StudentViewModel> objects = Builder<StudentViewModel>.CreateListOfSize(5);

            objects.ShouldBeAssignableTo<IList<StudentViewModel>>();
        }

        [Fact]
        public void GivenListOfBuilders_WhenCallingBuildListExplicitly_ThenAListOfUniqueObjectsShouldBeReturned()
        {
            var builders = Builder<StudentViewModel>.CreateListOfSize(5);

            var objects = builders.BuildList();

            objects.ShouldBeUnique();
        }

        [Fact]
        public void GivenListOfBuilders_WhenCallingBuildListImplicitly_ThenAListOfUniqueObjectsShouldBeReturned()
        {
            List<StudentViewModel> objects = Builder<StudentViewModel>.CreateListOfSize(5);

            objects.ShouldBeUnique();
        }

        [Fact]
        public void GivenListOfBuildersWithCustomisation_WhenBuildingObjectsExplicitly_ThenTheCustomisationShouldTakeEffect()
        {
            var generator = new SequentialGenerator(0, 100);
            var list = Builder<StudentViewModel>.CreateListOfSize(3)
                .All().With(b => b.Set(x => x.FirstName, generator.Generate().ToString()));

            var data = list.BuildList();

            data.Select(c => c.FirstName).ToArray()
                .ShouldBe(new[] { "0", "1", "2" });
        }

        [Fact]
        public void GivenListOfBuildersWithCustomisation_WhenBuildingObjectsImplicitly_ThenTheCustomisationShouldTakeEffect()
        {
            var generator = new SequentialGenerator(0, 100);

            List<StudentViewModel> data = Builder<StudentViewModel>.CreateListOfSize(3)
                .All().With(b => b.Set(x => x.FirstName, generator.Generate().ToString()));

            data.Select(c => c.FirstName).ToArray()
                .ShouldBe(new[] { "0", "1", "2" });
        }

        [Fact]
        public void GivenListOfBuildersWithComplexCustomisations_WhenBuildingObjectsExplicitly_ThenThenTheListIsBuiltAndModifiedCorrectly()
        {
            var i = 0;
            var studentViewModels = Builder<StudentViewModel>.CreateListOfSize(5)
                .TheFirst(1).Set(x => x.FirstName, "First")
                .TheNext(1).Set(x => x.LastName, "Next Last")
                .TheLast(1).Set(x => x.LastName, "Last Last")
                .ThePrevious(2).With(b => b.Set(x => x.LastName, "last" + (++i).ToString()))
                .All().Set(x => x.EnrollmentDate, _enrollmentDate)
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
        public void GivenListOfBuildersWithComplexCustomisations_WhenBuildingObjectsImplicitly_ThenThenTheListIsBuiltAndModifiedCorrectly()
        {
            var i = 0;
            List<StudentViewModel> studentViewModels = Builder<StudentViewModel>.CreateListOfSize(5)
                .TheFirst(1).Set(x => x.FirstName, "First")
                .TheNext(1).Set(x => x.LastName, "Next Last")
                .TheLast(1).Set(x => x.LastName, "Last Last")
                .ThePrevious(2).With(b => b.Set(x => x.LastName, "last" + (++i).ToString()))
                .All().Set(x => x.EnrollmentDate, _enrollmentDate);

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
        public void WhenBuildingObjectsExplicitly_ThenTheAnonymousValueFixtureIsSharedAcrossBuilders()
        {
            var studentViewModels = Builder<StudentViewModel>.CreateListOfSize(5).BuildList();

            studentViewModels.Select(x => x.Grade).ShouldBeUnique();
        }

        [Fact]
        public void WhenBuildingObjectsImplicitly_ThenTheAnonymousValueFixtureIsSharedAcrossBuilders()
        {
            List<StudentViewModel> studentViewModels = Builder<StudentViewModel>.CreateListOfSize(5);

            studentViewModels.Select(x => x.Grade).ShouldBeUnique();
        }

        public void WhenBuildingObjectsWithCtorAndPrivateSetters_ShouldSetPrivateSettersByDefault()
        {
            var dto = Builder<MixedAccessibilityDto>.CreateListOfSize(1)
                .TheFirst(1)
                    .Set(x => x.SetByCtorWithPublicSetter, "1")
                    .Set(x => x.SetByCtorWithPrivateSetter, "2")
                    .Set(x => x.NotSetByCtorWithPrivateSetter, "3")
                    .Set(x => x.NotSetByCtorWithPublicSetter, "4")
                .BuildList()
                [0];

            dto.SetByCtorWithPublicSetter.ShouldBe("1");
            dto.SetByCtorWithPrivateSetter.ShouldBe("2");
            dto.NotSetByCtorWithPrivateSetter.ShouldBe("3");
            dto.NotSetByCtorWithPublicSetter.ShouldBe("4");
        }

        [Fact]
        public void GivenBuilderListWithFactoryOverride_WhenBuildingObjects_ShouldRespectOverriddenFactory()
        {
            var dto = Builder<MixedAccessibilityDto>.CreateListOfSize(1, new CallConstructorFactory())
                .TheFirst(1)
                    .Set(x => x.SetByCtorWithPublicSetter, "1")
                    .Set(x => x.SetByCtorWithPrivateSetter, "2")
                    .Set(x => x.NotSetByCtorWithPrivateSetter, "3")
                    .Set(x => x.NotSetByCtorWithPublicSetter, "4")
                .BuildList()
                [0];

            dto.SetByCtorWithPublicSetter.ShouldBe("1");
            dto.SetByCtorWithPrivateSetter.ShouldBe("2");
            dto.NotSetByCtorWithPrivateSetter.ShouldNotBe("3");
            dto.NotSetByCtorWithPublicSetter.ShouldNotBe("4");
        }
    }
}