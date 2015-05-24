using System;
using System.Collections.Generic;
using Shouldly;
using TestStack.Dossier.Factories;
using TestStack.Dossier.Tests.TestHelpers.Objects.Examples;
using TestStack.Dossier.Tests.TestHelpers.Objects.ViewModels;
using Xunit;

namespace TestStack.Dossier.Tests
{
    // ReSharper disable once InconsistentNaming
    public class Builder_CreateNewTests
    {
        [Fact]
        public void GivenBuilder_WhenCallingBuildExplicitly_ThenReturnAnObject()
        {
            var builder = Builder<StudentViewModel>.CreateNew();

            var viewModel = builder.Build();

            viewModel.ShouldBeOfType<StudentViewModel>();
        }

        [Fact]
        public void GivenBuilder_WhenCallingBuildImplicitly_ThenReturnAnObject()
        {
            StudentViewModel viewModel = Builder<StudentViewModel>.CreateNew();

            viewModel.ShouldBeOfType<StudentViewModel>();
        }

        [Fact]
        public void GivenBuilderWithModifications_WhenCallingBuildExplicitly_ThenOverrideValues()
        {
            var builder = Builder<StudentViewModel>.CreateNew()
                .Set(x => x.FirstName, "Pi")
                .Set(x => x.LastName, "Lanningham")
                .Set(x => x.EnrollmentDate, new DateTime(2000, 1, 1));

            var vm = builder.Build();

            vm.FirstName.ShouldBe("Pi");
            vm.LastName.ShouldBe("Lanningham");
            vm.EnrollmentDate.ShouldBe(new DateTime(2000, 1, 1));
        }

        [Fact]
        public void GivenBuilderWithModifications_WhenCallingBuildImplicitly_ThenOverrideValues()
        {
            StudentViewModel vm = Builder<StudentViewModel>.CreateNew()
                .Set(x => x.FirstName, "Pi")
                .Set(x => x.LastName, "Lanningham")
                .Set(x => x.EnrollmentDate, new DateTime(2000, 1, 1));

            vm.FirstName.ShouldBe("Pi");
            vm.LastName.ShouldBe("Lanningham");
            vm.EnrollmentDate.ShouldBe(new DateTime(2000, 1, 1));
        }

        [Fact]
        public void GivenBuilder_WhenBuildingObjectWithCtorAndPrivateSetters_ThenSetPrivateSettersByDefault()
        {
            MixedAccessibilityDto dto = Builder<MixedAccessibilityDto>.CreateNew()
                .Set(x => x.SetByCtorWithPublicSetter, "1")
                .Set(x => x.SetByCtorWithPrivateSetter, "2")
                .Set(x => x.NotSetByCtorWithPrivateSetter, "3")
                .Set(x => x.NotSetByCtorWithPublicSetter, "4");

            dto.SetByCtorWithPublicSetter.ShouldBe("1");
            dto.SetByCtorWithPrivateSetter.ShouldBe("2");
            dto.NotSetByCtorWithPrivateSetter.ShouldBe("3");
            dto.NotSetByCtorWithPublicSetter.ShouldBe("4");
        }

        [Fact]
        public void GivenBuilderWithFactoryOverride_WhenBuildingObject_ThenRespectOverriddenFactory()
        {
            MixedAccessibilityDto dto = Builder<MixedAccessibilityDto>.CreateNew(new CallConstructorFactory())
                .Set(x => x.SetByCtorWithPublicSetter, "1")
                .Set(x => x.SetByCtorWithPrivateSetter, "2")
                .Set(x => x.NotSetByCtorWithPrivateSetter, "3")
                .Set(x => x.NotSetByCtorWithPublicSetter, "4");

            dto.SetByCtorWithPublicSetter.ShouldBe("1");
            dto.SetByCtorWithPrivateSetter.ShouldBe("2");
            dto.NotSetByCtorWithPrivateSetter.ShouldNotBe("3");
            dto.NotSetByCtorWithPublicSetter.ShouldNotBe("4");
        }

        [Fact]
        public void GivenBuilder_WhenCallingSetWithLambda_ThenInvokeEachTime()
        {
            var grade = Grade.A;
            var builder = Builder<StudentViewModel>.CreateNew()
                .Set(x => x.FirstName, "Pi")
                .Set(x => x.LastName, "Lanningham")
                .Set(x => x.Grade, () => grade++);

            var customerA = builder.Build();
            var customerB = builder.Build();

            customerA.Grade.ShouldBe(Grade.A);
            customerB.Grade.ShouldBe(Grade.B);
        }
    }
}