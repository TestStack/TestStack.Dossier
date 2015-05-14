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

        [Fact]
        public void GivenAllPropertiesFactoryAgainstBuilderWithModifications_WhenBuilding_ThenCustomisationsAreUsed()
        {
            MixedAccessibilityDto dto = Builder<MixedAccessibilityDto>
                .CreateNew(new AllPropertiesFactory())
                .Set(x => x.SetByCtorNoPropertySetter, "0")
                .Set(x => x.SetByCtorWithPrivateSetter, "1")
                .Set(x => x.SetByCtorWithPublicSetter, "2")
                .Set(x => x.NotSetByCtorWithPrivateSetter, "3")
                .Set(x => x.NotSetByCtorWithPublicSetter, "4");

            dto.SetByCtorNoPropertySetter.ShouldBe("0");
            dto.SetByCtorWithPrivateSetter.ShouldBe("1");
            dto.SetByCtorWithPublicSetter.ShouldBe("2");
            dto.NotSetByCtorWithPrivateSetter.ShouldBe("3");
            dto.NotSetByCtorWithPublicSetter.ShouldBe("4");
        }
    }
}
