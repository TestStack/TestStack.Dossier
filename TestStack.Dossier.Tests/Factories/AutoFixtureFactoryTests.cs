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

            // ctor properties
            dto.SetByCtorWithPrivateSetter.ShouldNotBe(null);
            dto.SetByCtorWithPublicSetter.ShouldNotBe(null);

            // public properties
            dto.NotSetByCtorWithPublicSetter.ShouldNotBe(null);

            // private properties
            dto.NotSetByCtorWithPrivateSetter.ShouldBe(null);
        }
    }
}
