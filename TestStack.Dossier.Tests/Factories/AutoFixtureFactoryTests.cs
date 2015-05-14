using System;
using Shouldly;
using TestStack.Dossier.Factories;
using TestStack.Dossier.Tests.Stubs.Examples;
using Xunit;

namespace TestStack.Dossier.Tests.Factories
{
    public class AutoFixtureFactoryTests
    {
        [Fact]
        public void GivenAutoFixtureFactory_WhenBuilding_ThenOnlyConstructorAndPublicPropertiesSet()
        {
            MixedAccessibilityDto dto = Builder<MixedAccessibilityDto>.CreateNew(new AutoFixtureFactory());

            dto.SetByCtorWithPrivateSetter.ShouldNotBe(null);
            dto.SetByCtorWithPublicSetter.ShouldNotBe(null);
            dto.NotSetByCtorWithPrivateSetter.ShouldBe(null);
            dto.NotSetByCtorWithPublicSetter.ShouldNotBe(null);
        }

        [Fact]
        public void GivenAutoFixtureFactoryAgainstBuilderWithModifications_WhenBuilding_ThenNoCustomisationsAreUsed()
        {
            MixedAccessibilityDto dto = Builder<MixedAccessibilityDto>
                .CreateNew(new AutoFixtureFactory())
                .Set(x => x.SetByCtorWithPrivateSetter, "1")
                .Set(x => x.SetByCtorWithPublicSetter, "2")
                .Set(x => x.NotSetByCtorWithPrivateSetter, "3")
                .Set(x => x.NotSetByCtorWithPublicSetter, "4");

            dto.SetByCtorWithPrivateSetter.ShouldNotBe("1");
            dto.SetByCtorWithPublicSetter.ShouldNotBe("2");
            dto.NotSetByCtorWithPrivateSetter.ShouldNotBe("3");
            dto.NotSetByCtorWithPublicSetter.ShouldNotBe("4");
        }
    }
}
