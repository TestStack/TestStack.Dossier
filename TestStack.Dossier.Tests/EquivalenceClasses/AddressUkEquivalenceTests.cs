using System.Collections.Generic;
using TestStack.Dossier.DataSources;
using TestStack.Dossier.DataSources.Dictionaries;
using Xunit.Extensions;

namespace TestStack.Dossier.Tests.EquivalenceClasses
{
    public class AddressUkEquivalenceClasses : FileDictionaryEquivalenceTests
    {
        [Theory]
        [ClassData(typeof(AddressUkTestCases))]
        public override void WhenGettingAnyData_ThenReturnRandomDataWhichIsReasonablyUnique(DataSource<string> source, List<string> testCases)
        {
            base.WhenGettingAnyData_ThenReturnRandomDataWhichIsReasonablyUnique(source, testCases);
        }
    }

    public class AddressUkTestCases : FileDictionaryEquivalenceTestCases
    {
        protected override List<object[]> GetData()
        {
            return new List<object[]>
            {
                new object[]
                {new Words(FromDictionary.AddressUkCounty), GenerateTestCasesForSut(Any.AddressUk.County)},
                new object[]
                {new Words(FromDictionary.AddressUkCity), GenerateTestCasesForSut(Any.AddressUk.City)},
                new object[]
                {new Words(FromDictionary.AddressUkCompany), GenerateTestCasesForSut(Any.AddressUk.Company)},
                new object[]
                {new Words(FromDictionary.AddressUkPhone), GenerateTestCasesForSut(Any.AddressUk.Phone)},
                new object[]
                {new Words(FromDictionary.AddressUkPostCode), GenerateTestCasesForSut(Any.AddressUk.PostCode)},
                new object[]
                {new Words(FromDictionary.AddressUkStreet), GenerateTestCasesForSut(Any.AddressUk.Street)},
                new object[]
                {new Words(FromDictionary.AddressUkWebsite), GenerateTestCasesForSut(Any.AddressUk.Website)},
            };
        }
    }
}
