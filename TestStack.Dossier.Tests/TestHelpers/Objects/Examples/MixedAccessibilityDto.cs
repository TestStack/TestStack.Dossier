namespace TestStack.Dossier.Tests.TestHelpers.Objects.Examples
{
    public class MixedAccessibilityDto
    {
        private readonly string _setByCtorNoPropertySetter;

        public MixedAccessibilityDto(string setByCtorWithPrivateSetter, string setByCtorWithPublicSetter, string setByCtorNoPropertySetter)
        {
            SetByCtorWithPrivateSetter = setByCtorWithPrivateSetter;
            SetByCtorWithPublicSetter = setByCtorWithPublicSetter;
            _setByCtorNoPropertySetter = setByCtorNoPropertySetter;
        }

        public string SetByCtorWithPrivateSetter { get; private set; }
        public string SetByCtorWithPublicSetter { get; set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        public string NotSetByCtorWithPrivateSetter { get; private set; }
        public string NotSetByCtorWithPublicSetter { get; set; }

        public string SetByCtorNoPropertySetter
        {
            get { return _setByCtorNoPropertySetter; }
        }
    }
}