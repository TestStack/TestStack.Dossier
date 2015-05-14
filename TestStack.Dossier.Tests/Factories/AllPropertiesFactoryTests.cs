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

            dto.SetByCtorNoPropertySetter.ShouldNotBe(null);
            dto.SetByCtorWithPrivateSetter.ShouldNotBe(null);
            dto.SetByCtorWithPublicSetter.ShouldNotBe(null);
            dto.NotSetByCtorWithPrivateSetter.ShouldNotBe(null);
            dto.NotSetByCtorWithPublicSetter.ShouldNotBe(null);
        }
    }
}
