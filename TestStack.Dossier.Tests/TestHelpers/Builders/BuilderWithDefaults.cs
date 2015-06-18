using TestStack.Dossier.Tests.TestHelpers.Objects.Entities;

namespace TestStack.Dossier.Tests.TestHelpers.Builders
{
    public class BuilderWithDefaults : TestDataBuilder<Customer, BuilderWithDefaults>
    {
        public const string DefaultFirstName = "Joe";
        public const string DefaultLastName = "Bloggs";

        public BuilderWithDefaults()
        {
            Set(x => x.FirstName, DefaultFirstName);
            Set(x => x.LastName, DefaultLastName);
        }
    }
}
