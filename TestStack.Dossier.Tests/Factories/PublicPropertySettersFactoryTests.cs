using Shouldly;
using TestStack.Dossier.Factories;
using TestStack.Dossier.Tests.TestHelpers.Objects.Examples;
using Xunit;

namespace TestStack.Dossier.Tests.Factories
{
    public class PublicPropertySettersFactoryTests
    {
        [Fact]
        public void GivenPublicPropertiesFactory_WhenBuilding_ThenOnlyConstructorAndPublicPropertiesSet()
        {
            MixedAccessibilityDto dto = Builder<MixedAccessibilityDto>.CreateNew(new PublicPropertySettersFactory());

            dto.SetByCtorNoPropertySetter.ShouldNotBe(null);
            dto.SetByCtorWithPrivateSetter.ShouldNotBe(null);
            dto.SetByCtorWithPublicSetter.ShouldNotBe(null);
            dto.NotSetByCtorWithPublicSetter.ShouldNotBe(null);
            dto.NotSetByCtorWithPrivateSetter.ShouldBe(null);
        }
    }
}
