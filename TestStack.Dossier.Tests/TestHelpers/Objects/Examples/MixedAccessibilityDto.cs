namespace TestStack.Dossier.Tests.TestHelpers.Objects.Examples
{
    public class MixedAccessibilityDto
    {
        public MixedAccessibilityDto(string setByCtorWithPrivateSetter, string setByCtorWithPublicSetter)
        {
            SetByCtorWithPrivateSetter = setByCtorWithPrivateSetter;
            SetByCtorWithPublicSetter = setByCtorWithPublicSetter;
        }

        public string SetByCtorWithPrivateSetter { get; private set; }
        public string SetByCtorWithPublicSetter { get; set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        public string NotSetByCtorWithPrivateSetter { get; private set; }
        public string NotSetByCtorWithPublicSetter { get; set; }

        public string CalculatedProperty
        {
            get { return SetByCtorWithPrivateSetter + " " + SetByCtorWithPublicSetter; }
        }
    }
}