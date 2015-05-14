using System;
using Shouldly;
using TestStack.Dossier.Factories;
using TestStack.Dossier.Tests.TestHelpers.Objects.Examples;
using Xunit;

namespace TestStack.Dossier.Tests.Factories
{
    public class AllPropertiesFactoryTests
    {
        [Fact]
        public void GivenAllPropertiesFactory_WhenBuilding_ThenAllPropertiesSet()
        {
            MixedAccessibilityDto dto = Builder<MixedAccessibilityDto>.CreateNew(new AllPropertiesFactory());

            // ctor properties
            dto.SetByCtorWithPrivateSetter.ShouldNotBe(null);
            dto.SetByCtorWithPublicSetter.ShouldNotBe(null);

            // public properties
            dto.NotSetByCtorWithPublicSetter.ShouldNotBe(null);

            // private properties
            dto.NotSetByCtorWithPrivateSetter.ShouldNotBe(null);
        }
    }
}
