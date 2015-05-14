using System;
using Shouldly;
using TestStack.Dossier.Factories;
using TestStack.Dossier.Tests.TestHelpers.Objects.Examples;
using Xunit;

namespace TestStack.Dossier.Tests.Factories
{
    public class CallConstructorFactoryTests
    {
        [Fact]
        public void GivenConstructorFactory_WhenBuilding_ThenOnlyConstructorPropertiesSet()
        {
            MixedAccessibilityDto dto = Builder<MixedAccessibilityDto>.CreateNew(new CallConstructorFactory());

            dto.SetByCtorNoPropertySetter.ShouldNotBe(null);
            dto.SetByCtorWithPrivateSetter.ShouldNotBe(null);
            dto.SetByCtorWithPublicSetter.ShouldNotBe(null);
            dto.NotSetByCtorWithPrivateSetter.ShouldBe(null);
            dto.NotSetByCtorWithPublicSetter.ShouldBe(null);
        }
    }
}
