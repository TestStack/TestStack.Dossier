using System.Collections.Generic;
using TestStack.Dossier.DataSources;
using TestStack.Dossier.DataSources.Dictionaries;
using Xunit;

namespace TestStack.Dossier.Tests.EquivalenceClasses
{
    public class AddressUsEquivalenceTests : FileDictionaryEquivalenceTests
    {
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
                {new Words(FromDictionary.AddressUsCity), GenerateTestCasesForSut(Any.AddressUs.City)},
                new object[]
                {new Words(FromDictionary.AddressUsCompany), GenerateTestCasesForSut(Any.AddressUs.Company)},
                new object[]
                {new Words(FromDictionary.AddressUsPhone), GenerateTestCasesForSut(Any.AddressUs.Phone)},
                new object[]
                {new Words(FromDictionary.AddressUsSocialSecurityNumber), GenerateTestCasesForSut(Any.AddressUs.SocialSecurityNumber)},
                new object[]
                {new Words(FromDictionary.AddressUsState), GenerateTestCasesForSut(Any.AddressUs.State)},
                new object[]
                {
                    new Words(FromDictionary.AddressUsStateAbbreviation),
                    GenerateTestCasesForSut(Any.AddressUs.StateAbbreviation)
                },
                new object[]
                {new Words(FromDictionary.AddressUsStreet), GenerateTestCasesForSut(Any.AddressUs.Street)},
                new object[]
                {new Words(FromDictionary.AddressUsWebsite), GenerateTestCasesForSut(Any.AddressUs.Website)},
                new object[]
                {new Words(FromDictionary.AddressUsZipCode), GenerateTestCasesForSut(Any.AddressUs.ZipCode)}
            };
        }
    }
}
