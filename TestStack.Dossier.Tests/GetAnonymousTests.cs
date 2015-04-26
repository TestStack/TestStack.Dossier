using System;
using Shouldly;
using TestStack.Dossier.DataSources.Person;
using TestStack.Dossier.Lists;
using TestStack.Dossier.Tests.Builders;
using TestStack.Dossier.Tests.TestHelpers;
using Xunit;

namespace TestStack.Dossier.Tests
{
    public class GetAnonymousTests
    {
        private readonly BasicCustomerBuilder _b;

        public GetAnonymousTests()
        {
            AnonymousValueFixture.GlobalValueSuppliers.Clear();
            _b = new BasicCustomerBuilder();
        }

        [Fact]
        public void GivenNoValueHasBeenSetForAPropertyAndAGlobalAndLocalSupplierHasBeenRegisteredThatWontAcceptThatProperty_WhenRetrievingTheValueForThatProperty_ThenDontUseLocalOrGlobalValue()
        {
            const string globalVal = "global";
            const string localVal = "local";
            AnonymousValueFixture.GlobalValueSuppliers.Add(new StaticAnonymousValueSupplier(globalVal));
            _b.Any.LocalValueSuppliers.Add(new StaticAnonymousValueSupplier(localVal));

            ((object)_b.Get(x => x.YearJoined)).ShouldNotBe(localVal);
            ((object)_b.Get(x => x.YearJoined)).ShouldNotBe(globalVal);
        }

        [Fact]
        public void GivenNoValueHasBeenSetForAPropertyAndAGlobalAndLocalSupplierHasBeenRegisteredThatWillAcceptThatProperty_WhenRetrievingTheValueForThatProperty_ThenReturnLocalSupplierValue()
        {
            const string globalVal = "global";
            const string localVal = "local";
            AnonymousValueFixture.GlobalValueSuppliers.Add(new StaticAnonymousValueSupplier(globalVal));
            _b.Any.LocalValueSuppliers.Add(new StaticAnonymousValueSupplier(localVal));

            _b.Get(x => x.FirstName).ShouldBe(localVal);
        }

        [Fact]
        public void GivenNoValueHasBeenSetForAPropertyAndAGlobalSupplierHasBeenRegisteredThatWillAcceptThatProperty_WhenRetrievingTheValueForThatProperty_ThenReturnGlobalSupplierValue()
        {
            const string globalVal = "global";
            AnonymousValueFixture.GlobalValueSuppliers.Add(new StaticAnonymousValueSupplier(globalVal));

            _b.Get(x => x.FirstName).ShouldBe(globalVal);
        }

        [Fact]
        public void GivenNoValueHasBeenSetForAPropertyNamedFirstName_WhenRetrievingTheValueForTheProperty_ThenReturnAFirstName()
        {
            var firstName = _b.Get(x => x.FirstName);

            new PersonNameFirstSource().Data
                .ShouldContain(firstName);
        }

        [Fact]
        public void GivenNoValueHasBeenSetForAPropertyNamedLastName_WhenRetrievingTheValueForTheProperty_ThenReturnALastName()
        {
            var lastName = _b.Get(x => x.LastName);

            new PersonNameLastSource().Data
                .ShouldContain(lastName);
        }

        [Fact]
        public void GivenNoValueHasBeenSetForAStringProperty_WhenRetrievingTheValueForThatProperty_ThenReturnPropertyNameFollowedByGuid()
        {
            _b.Get(x => x.Identifier).ShouldMatch("^Identifier[a-f0-9]{8}(?:-[a-f0-9]{4}){3}-[a-f0-9]{12}$");
        }

        [Fact]
        public void GivenNoValueHasBeenSetForAnIntProperty_WhenRetrievingTheValueForThatProperty_ThenReturnAnonymousInteger()
        {
            var val1 = _b.Get(x => x.YearJoined);
            var val2 = _b.Get(x => x.YearJoined);

            val1.ShouldNotBe(val2);
        }

        [Fact]
        public void GivenGlobalValueSupplierSet_WhenGeneratingList_UseTheSupplierForTheRelevantPropertyExceptWhereItsOverridden()
        {
            AnonymousValueFixture.GlobalValueSuppliers.Add(new YearValueSupplier());
            var customers = CustomerBuilder.CreateListOfSize(5)
                .TheLast(1).WhoJoinedIn(1990)
                .BuildList();

            customers[0].YearJoined.ShouldBe(2000);
            customers[1].YearJoined.ShouldBe(2001);
            customers[2].YearJoined.ShouldBe(2002);
            customers[3].YearJoined.ShouldBe(2003);
            customers[4].YearJoined.ShouldBe(1990);
        }
    }

    internal class YearValueSupplier : IAnonymousValueSupplier
    {
        private int _year;

        public YearValueSupplier()
        {
            _year = 2000;
        }

        public bool CanSupplyValue<TObject, TValue>(string propertyName)
        {
            return typeof(TValue) == typeof(int)
                   && propertyName.ToLower().StartsWith("year");
        }

        public bool CanSupplyValue(Type type, string propertyName)
        {
            return type == typeof(int)
                   && propertyName.ToLower().StartsWith("year");
        }

        public TValue GenerateAnonymousValue<TObject, TValue>(AnonymousValueFixture any, string propertyName)
        {
            return (TValue)(object)_year++;
        }

        public object GenerateAnonymousValue(AnonymousValueFixture any, Type type, string propertyName)
        {
            return _year++;
        }
    }
}
