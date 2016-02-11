using Shouldly;
using Xunit;

namespace TestStack.Dossier.Tests.PublicApiApproval
{
    public class PublicApiApproverTests
    {
        [Fact]
        public void GivenDossierAssembly_WhenPublicApiChecked_ShouldHaveNoChanges()
        {
            ShouldlyConfiguration.DiffTools.KnownDoNotLaunchStrategies.TeamCity.ShouldNotLaunch();
            var dossierAssembly = typeof (AnonymousValueFixture).Assembly;
            var publicApi = PublicApiGenerator.PublicApiGenerator.GetPublicApi(dossierAssembly);
            publicApi.ShouldMatchApproved();
        }
    }
}
