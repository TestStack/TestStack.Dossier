using System.Collections.Generic;
using TestStack.Dossier.DataSources;
using TestStack.Dossier.DataSources.Dictionaries;
using Xunit.Extensions;

namespace TestStack.Dossier.Tests.EquivalenceClasses
{
    public class AddressAusEquivalenceTests : FileDictionaryEquivalenceTests
    {
        public AnonymousValueFixture Any { get; } = new AnonymousValueFixture();

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
                {new Words(FromDictionary.AddressAusCity), GenerateTestCasesForSut(Any.AddressAusCity)},
                new object[]
                {new Words(FromDictionary.AddressAusCompany), GenerateTestCasesForSut(Any.AddressAusCompany)},
                new object[]
                {new Words(FromDictionary.AddressAusPhone), GenerateTestCasesForSut(Any.AddressAusPhone)},
                new object[]
                {new Words(FromDictionary.AddressAusPostCode), GenerateTestCasesForSut(Any.AddressAusPostCode)},
                new object[]
                {new Words(FromDictionary.AddressAusState), GenerateTestCasesForSut(Any.AddressAusState)},
                new object[]
                {
                    new Words(FromDictionary.AddressAusStateAbbreviation),
                    GenerateTestCasesForSut(Any.AddressAusStateAbbreviation)
                },
                new object[]
                {new Words(FromDictionary.AddressAusStreet), GenerateTestCasesForSut(Any.AddressAusStreet)},
                new object[]
                {new Words(FromDictionary.AddressAusWebsite), GenerateTestCasesForSut(Any.AddressAusWebsite)},
            };
        }
    }
}
