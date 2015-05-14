using System;
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
        public void GivenBuilderWithModifications_WhenCallingBuildExplicitly_ShouldOverrideValues()
        {
            var builder = Builder<StudentViewModel>.CreateNew()
                .Set(x => x.FirstName, "Pi")
                .Set(x => x.LastName, "Lanningham")
                .Set(x => x.EnrollmentDate, new DateTime(2000, 1, 1));

            var customer = builder.Build();

            customer.FirstName.ShouldBe("Pi");
            customer.LastName.ShouldBe("Lanningham");
            customer.EnrollmentDate.ShouldBe(new DateTime(2000, 1, 1));
        }

        [Fact]
        public void GivenBuilderWithModifications_WhenCallingBuildImplicitly_ShouldOverrideValues()
        {
            StudentViewModel customer = Builder<StudentViewModel>.CreateNew()
                .Set(x => x.FirstName, "Pi")
                .Set(x => x.LastName, "Lanningham")
                .Set(x => x.EnrollmentDate, new DateTime(2000, 1, 1));

            customer.FirstName.ShouldBe("Pi");
            customer.LastName.ShouldBe("Lanningham");
            customer.EnrollmentDate.ShouldBe(new DateTime(2000, 1, 1));
        }

        [Fact]
        public void GivenBuilder_WhenBuildingObjectWithCtorAndPrivateSetters_ShouldSetPrivateSettersByDefault()
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
        public void GivenBuilderWithFactoryOverride_WhenBuildingObject_ShouldRespectOverriddenFactory()
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
    }
}