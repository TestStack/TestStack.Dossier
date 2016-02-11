using System.Collections.Generic;
using TestStack.Dossier.DataSources;
using TestStack.Dossier.DataSources.Dictionaries;
using Xunit.Extensions;

namespace TestStack.Dossier.Tests.EquivalenceClasses
{
    public class AddressUsEquivalenceTests : FileDictionaryEquivalenceTests
    {
        public AnonymousValueFixture Any { get; } = new AnonymousValueFixture();

        [Theory]
        [ClassData(typeof(AddressUsTestCases))]
        public override void WhenGettingAnyData_ThenReturnRandomDataWhichIsReasonablyUnique(DataSource<string> source, List<string> testCases)
        {
            base.WhenGettingAnyData_ThenReturnRandomDataWhichIsReasonablyUnique(source, testCases);
        }
    }

    public class AddressUsTestCases : FileDictionaryEquivalenceTestCases
    {
        protected override List<object[]> GetData()
        {
            return new List<object[]>
            {
                new object[]
                {new Words(FromDictionary.AddressUsCity), GenerateTestCasesForSut(Any.AddressUsCity)},
                new object[]
                {new Words(FromDictionary.AddressUsCompany), GenerateTestCasesForSut(Any.AddressUsCompany)},
                new object[]
                {new Words(FromDictionary.AddressUsPhone), GenerateTestCasesForSut(Any.AddressUsPhone)},
                new object[]
                {new Words(FromDictionary.AddressUsSocialSecurityNumber), GenerateTestCasesForSut(Any.AddressUsSocialSecurityNumber)},
                new object[]
                {new Words(FromDictionary.AddressUsState), GenerateTestCasesForSut(Any.AddressUsState)},
                new object[]
                {
                    new Words(FromDictionary.AddressUsStateAbbreviation),
                    GenerateTestCasesForSut(Any.AddressUsStateAbbreviation)
                },
                new object[]
                {new Words(FromDictionary.AddressUsStreet), GenerateTestCasesForSut(Any.AddressUsStreet)},
                new object[]
                {new Words(FromDictionary.AddressUsWebsite), GenerateTestCasesForSut(Any.AddressUsWebsite)},
                new object[]
                {new Words(FromDictionary.AddressUsZipCode), GenerateTestCasesForSut(Any.AddressUsZipCode)}
            };
        }
    }
}
