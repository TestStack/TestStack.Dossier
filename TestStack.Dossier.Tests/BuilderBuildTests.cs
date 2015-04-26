using Shouldly;
using TestStack.Dossier.Tests.Builders;
using TestStack.Dossier.Tests.Entities;
using Xunit;

namespace TestStack.Dossier.Tests
{
    public class BuilderBuildTests
    {
        [Fact]
        public void GivenBasicBuilder_WhenCallingBuildExplicitly_ThenReturnAnObject()
        {
            var builder = Builder<Customer>.CreateNew();

            var customer = builder.Build();

            customer.ShouldBeOfType<Customer>();
        }

        [Fact]
        public void GivenBuilder_WhenCallingSetExplicitly_ShouldOverrideValues()
        {
            var builder = Builder<Customer>.CreateNew()
                .Set(x => x.FirstName, "Pi")
                .Set(x => x.LastName, "Lanningham")
                .Set(x => x.YearJoined, 2014);

            var customer = builder.Build();

            customer.FirstName.ShouldBe("Pi");
            customer.LastName.ShouldBe("Lanningham");
            customer.YearJoined.ShouldBe(2014);
        }

        [Fact]
        public void GivenBasicBuilder_WhenCallingBuildImplicitly_ThenReturnAnObject()
        {
            Customer customer = Builder<Customer>.CreateNew();

            customer.ShouldBeOfType<Customer>();
        }

        [Fact]
        public void GivenBuilder_WhenCallingSetImplicitly_ShouldOverrideValues()
        {
            Customer customer = Builder<Customer>.CreateNew()
                .Set(x => x.FirstName, "Pi")
                .Set(x => x.LastName, "Lanningham")
                .Set(x => x.YearJoined, 2014);

            customer.FirstName.ShouldBe("Pi");
            customer.LastName.ShouldBe("Lanningham");
            customer.YearJoined.ShouldBe(2014);
        }
    }
}