using System.Linq;
using Shouldly;
using TestStack.Dossier.Lists;
using TestStack.Dossier.Picking;
using TestStack.Dossier.Tests.TestHelpers.Objects.Entities;
using Xunit;

namespace TestStack.Dossier.Tests.Picking
{
    public class PickingTests
    {
        [Fact]
        public void RandomItemFrom_should_add_items_from_list_randomly()
        {
            var addresses = Builder<Address>.CreateListOfSize(15).BuildList();
            var customers = Builder<Customer>
                .CreateListOfSize(15)
                .All()
                .Set(x => x.PostalAddress, Pick.RandomItemFrom(addresses).Next)
                .BuildList();

            var uniqueAddresses = customers.Select(x => x.PostalAddress).Distinct().Count();
            uniqueAddresses.ShouldBeGreaterThan(3);
            uniqueAddresses.ShouldBeLessThan(15);
        }

        [Fact]
        public void RepeatingSequenceFrom_should_add_items_from_list_sequentially_and_repeat_when_list_completes()
        {
            var addresses = Builder<Address>.CreateListOfSize(3).BuildList();
            var customers = Builder<Customer>
                .CreateListOfSize(9)
                .All()
                .Set(x => x.PostalAddress, Pick.RepeatingSequenceFrom(addresses).Next)
                .BuildList();

            for (int i = 0; i < 2; i++)
            {
                var address = customers[i].PostalAddress;
                address.ShouldBeSameAs(customers[i + 3].PostalAddress);
                address.ShouldBeSameAs(customers[i + 6].PostalAddress);

                address.ShouldNotBeSameAs(customers[i + 1].PostalAddress);
                address.ShouldNotBeSameAs(customers[i + 2].PostalAddress);
            }
        }
    }
}
