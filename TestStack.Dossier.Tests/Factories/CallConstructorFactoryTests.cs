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

            // ctor properties
            dto.SetByCtorWithPrivateSetter.ShouldNotBe(null);
            dto.SetByCtorWithPublicSetter.ShouldNotBe(null);

            // public properties
            dto.NotSetByCtorWithPublicSetter.ShouldBe(null);

            // private properties
            dto.NotSetByCtorWithPrivateSetter.ShouldBe(null);
        }
    }
}
