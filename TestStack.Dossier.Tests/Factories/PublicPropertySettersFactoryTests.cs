using Shouldly;
using TestStack.Dossier.Factories;
using TestStack.Dossier.Tests.Stubs.Examples;
using Xunit;

namespace TestStack.Dossier.Tests.Factories
{
    public class PublicPropertySettersFactoryTests
    {
        [Fact]
        public void GivenPublicPropertiesFactory_WhenBuilding_ThenOnlyConstructorAndPublicPropertiesSet()
        {
            MixedAccessibilityDto instructor = Builder<MixedAccessibilityDto>.CreateNew(new PublicPropertySettersFactory());

            // ctor properties
            instructor.SetByCtorWithPrivateSetter.ShouldNotBe(null);
            instructor.SetByCtorWithPublicSetter.ShouldNotBe(null);
            
            // public properties
            instructor.NotSetByCtorWithPublicSetter.ShouldNotBe(null);

            // private properties
            instructor.NotSetByCtorWithPrivateSetter.ShouldBe(null);
        }
    }
}
