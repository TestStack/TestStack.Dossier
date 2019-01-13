using System.Collections.Generic;
using TestStack.Dossier.DataSources;
using TestStack.Dossier.DataSources.Dictionaries;
using Xunit;

namespace TestStack.Dossier.Tests.EquivalenceClasses
{
    public class AddressAusEquivalenceTests : FileDictionaryEquivalenceTests
    {
        [Theory]
        [ClassData(typeof(AddressAusTestCases))]
        public override void WhenGettingAnyData_ThenReturnRandomDataWhichIsReasonablyUnique(DataSource<string> source, List<string> testCases)
        {
            base.WhenGettingAnyData_ThenReturnRandomDataWhichIsReasonablyUnique(source, testCases);
        }
    }

    public class AddressAusTestCases : FileDictionaryEquivalenceTestCases
    {
        protected override List<object[]> GetData()
        {
            return new List<object[]>
            {
                new object[]
                {new Words(FromDictionary.AddressAusCity), GenerateTestCasesForSut(Any.AddressAus.City)},
                new object[]
                {new Words(FromDictionary.AddressAusCompany), GenerateTestCasesForSut(Any.AddressAus.Company)},
                new object[]
                {new Words(FromDictionary.AddressAusPhone), GenerateTestCasesForSut(Any.AddressAus.Phone)},
                new object[]
                {new Words(FromDictionary.AddressAusPostCode), GenerateTestCasesForSut(Any.AddressAus.PostCode)},
                new object[]
                {new Words(FromDictionary.AddressAusState), GenerateTestCasesForSut(Any.AddressAus.State)},
                new object[]
                {
                    new Words(FromDictionary.AddressAusStateAbbreviation),
                    GenerateTestCasesForSut(Any.AddressAus.StateAbbreviation)
                },
                new object[]
                {new Words(FromDictionary.AddressAusStreet), GenerateTestCasesForSut(Any.AddressAus.Street)},
                new object[]
                {new Words(FromDictionary.AddressAusWebsite), GenerateTestCasesForSut(Any.AddressAus.Website)},
            };
        }
    }
}
