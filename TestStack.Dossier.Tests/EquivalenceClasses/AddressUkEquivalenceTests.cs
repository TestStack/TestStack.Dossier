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
                {new Words(FromDictionary.AddressUkCounty), GenerateTestCasesForSut(Any.AddressUkCounty)},
                new object[]
                {new Words(FromDictionary.AddressUkCity), GenerateTestCasesForSut(Any.AddressUkCity)},
                new object[]
                {new Words(FromDictionary.AddressUkCompany), GenerateTestCasesForSut(Any.AddressUkCompany)},
                new object[]
                {new Words(FromDictionary.AddressUkPhone), GenerateTestCasesForSut(Any.AddressUkPhone)},
                new object[]
                {new Words(FromDictionary.AddressUkPostCode), GenerateTestCasesForSut(Any.AddressUkPostCode)},
                new object[]
                {new Words(FromDictionary.AddressUkStreet), GenerateTestCasesForSut(Any.AddressUkStreet)},
                new object[]
                {new Words(FromDictionary.AddressUkWebsite), GenerateTestCasesForSut(Any.AddressUkWebsite)},
            };
        }
    }
}
