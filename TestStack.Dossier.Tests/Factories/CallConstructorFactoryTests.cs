using Shouldly;
using TestStack.Dossier.Factories;
using TestStack.Dossier.Tests.TestHelpers.Objects.Examples;
using Xunit;

namespace TestStack.Dossier.Tests.Factories
{
    public class CallConstructorFactoryTests
    {
        [Fact]
        public void GivenCallConstructorFactory_WhenBuilding_ThenOnlyConstructorPropertiesSet()
        {
            MixedAccessibilityDto dto = Builder<MixedAccessibilityDto>.CreateNew(new CallConstructorFactory());

            dto.SetByCtorNoPropertySetter.ShouldNotBe(null);
            dto.SetByCtorWithPrivateSetter.ShouldNotBe(null);
            dto.SetByCtorWithPublicSetter.ShouldNotBe(null);
            dto.NotSetByCtorWithPrivateSetter.ShouldBe(null);
            dto.NotSetByCtorWithPublicSetter.ShouldBe(null);
        }

        [Fact]
        public void GivenCallConstructorFactoryAgainstBuilderWithModifications_WhenBuilding_ThenCustomisationsAreUsed()
        {
            MixedAccessibilityDto dto = Builder<MixedAccessibilityDto>
                .CreateNew(new CallConstructorFactory())
                .Set(x => x.SetByCtorNoPropertySetter, "0")
                .Set(x => x.SetByCtorWithPrivateSetter, "1")
                .Set(x => x.SetByCtorWithPublicSetter, "2")
                .Set(x => x.NotSetByCtorWithPrivateSetter, "3")
                .Set(x => x.NotSetByCtorWithPublicSetter, "4");

            dto.SetByCtorNoPropertySetter.ShouldBe("0");
            dto.SetByCtorWithPrivateSetter.ShouldBe("1");
            dto.SetByCtorWithPublicSetter.ShouldBe("2");
            dto.NotSetByCtorWithPrivateSetter.ShouldBe(null);
            dto.NotSetByCtorWithPublicSetter.ShouldBe(null);
        }
    }
}
