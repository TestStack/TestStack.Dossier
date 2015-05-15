using TestStack.Dossier.Factories;
using TestStack.Dossier.Tests.TestHelpers.Objects.ViewModels;

namespace TestStack.Dossier.Tests.TestHelpers.Builders
{
    public class AddressViewModelBuilder : TestDataBuilder<AddressViewModel, AddressViewModelBuilder>
    {
        public virtual AddressViewModelBuilder WithStreet(string street)
        {
            return Set(x => x.Street, street);
        }

        protected override AddressViewModel BuildObject()
        {
            return BuildUsing<PublicPropertySettersFactory>();
        }
    }
}
