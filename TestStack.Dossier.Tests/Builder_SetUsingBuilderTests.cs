using Shouldly;
using TestStack.Dossier.Lists;
using TestStack.Dossier.Tests.TestHelpers.Builders;
using TestStack.Dossier.Tests.TestHelpers.Objects.ViewModels;
using Xunit;

namespace TestStack.Dossier.Tests
{
    // ReSharper disable once InconsistentNaming
    public class Builder_SetUsingBuilderTests
    {
        [Fact]
        public void GivenBuilderWithObjectPropertyNotSet_WhenBuildingTheObject_ThenThePropertyWillBeNull()
        {
            var vm = Builder<StudentViewModel>.CreateNew().Build();

            vm.Address.ShouldBe(null);
        }

        [Fact]
        public void GivenBuilderWithObjectPropertyNotSet_WhenBuildingAListOfObjects_ThenThePropertyWillBeNull()
        {
            var vm = Builder<StudentViewModel>.CreateListOfSize(1).BuildList()[0];

            vm.Address.ShouldBe(null);
        }

        [Fact]
        public void GivenBuilderWithObjectPropertySetViaBuilder_WhenBuildingTheObject_ThenThePropertyWillBeSet()
        {
            var vm = Builder<StudentViewModel>.CreateNew()
                .SetUsingBuilder(x => x.Address)
                .Build();

            vm.Address.ShouldNotBe(null);
        }

        [Fact]
        public void GivenBuilderWithObjectPropertySetViaBuilder_WhenBuildingAListOfObjects_ThenThePropertyWillBeSet()
        {
            var vm = Builder<StudentViewModel>.CreateListOfSize(1)
                .TheFirst(1)
                    .SetUsingBuilder(x => x.Address)
                .BuildList()[0];

            vm.Address.ShouldNotBe(null);
        }

        [Fact]
        public void GivenBuilderWithObjectPropertySetViaBuilderAndCustomisation_WhenBuildingTheObject_ThenThePropertyWillBeSetIncludingTheCustomisation()
        {
            var vm = Builder<StudentViewModel>.CreateNew()
                .SetUsingBuilder(x => x.Address, b => b.Set(x => x.Street, "A street"))
                .Build();

            vm.Address.ShouldNotBe(null);
            vm.Address.Street.ShouldBe("A street");
        }

        [Fact]
        public void GivenBuilderWithObjectPropertySetViaBuilderAndCustomisation_WhenBuildingAListOfObjects_ThenThePropertyWillBeSetIncludingTheCustomisation()
        {
            var vm = Builder<StudentViewModel>.CreateListOfSize(1)
                .All()
                    .SetUsingBuilder(x => x.Address, b => b.Set(x => x.Street, "A street"))
                .BuildList()[0];

            vm.Address.ShouldNotBe(null);
            vm.Address.Street.ShouldBe("A street");
        }

        [Fact]
        public void GivenBuilderWithObjectPropertySetViaCustomBuilder_WhenBuildingTheObject_ThenThePropertyWillBeSet()
        {
            var vm = Builder<StudentViewModel>.CreateNew()
                .SetUsingBuilder<AddressViewModel, AddressViewModelBuilder>(x => x.Address)
                .Build();

            vm.Address.ShouldNotBe(null);
        }

        [Fact]
        public void GivenBuilderWithObjectPropertySetViaCustomBuilder_WhenBuildingAListOfObjects_ThenThePropertyWillBeSet()
        {
            var vm = Builder<StudentViewModel>.CreateListOfSize(1)
                .All()
                    .SetUsingBuilder<AddressViewModel, AddressViewModelBuilder>(x => x.Address)
                .BuildList()[0];

            vm.Address.ShouldNotBe(null);
        }

        [Fact]
        public void GivenBuilderWithObjectPropertySetViaCustomBuilderAndCustomisation_WhenBuildingTheObject_ThenThePropertyWillBeSetIncludingTheCustomisation()
        {
            var vm = Builder<StudentViewModel>.CreateNew()
                .SetUsingBuilder<AddressViewModel, AddressViewModelBuilder>(x => x.Address, b => b.WithStreet("A street"))
                .Build();

            vm.Address.ShouldNotBe(null);
            vm.Address.Street.ShouldBe("A street");
        }

        [Fact]
        public void GivenBuilderWithObjectPropertySetViaCustomBuilderAndCustomisation_WhenBuildingAListOfObjects_ThenThePropertyWillBeSetIncludingTheCustomisation()
        {
            var vm = Builder<StudentViewModel>.CreateListOfSize(1)
                .All()
                    .SetUsingBuilder<AddressViewModel, AddressViewModelBuilder>(x => x.Address, b => b.WithStreet("A street"))
                .BuildList()[0];

            vm.Address.ShouldNotBe(null);
            vm.Address.Street.ShouldBe("A street");
        }
    }
}
