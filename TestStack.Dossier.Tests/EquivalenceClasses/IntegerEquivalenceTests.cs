using System.Collections.Generic;
using TestStack.Dossier.DataSources;
using TestStack.Dossier.DataSources.Dictionaries;
using Xunit.Extensions;

namespace TestStack.Dossier.Tests.EquivalenceClasses
{
    public class InternetEquivalenceTests : FileDictionaryEquivalenceTests
    {
        [Theory]
        [ClassData(typeof(InternetTestCases))]
        public override void WhenGettingAnyData_ThenReturnRandomDataWhichIsReasonablyUnique(DataSource<string> source, List<string> testCases)
        {
            base.WhenGettingAnyData_ThenReturnRandomDataWhichIsReasonablyUnique(source, testCases);
        }
    }

    public class InternetTestCases : FileDictionaryEquivalenceTestCases
    {
        protected override List<object[]> GetData()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new Words(FromDictionary.InternetDomainCountryCodeTopLevelDomain),
                    GenerateTestCasesForSut(Any.InternetDomainCountryCodeTopLevelDomain)
                },
                new object[]
                {new Words(FromDictionary.InternetDomainName), GenerateTestCasesForSut(Any.InternetDomainName)},
                new object[]
                {
                    new Words(FromDictionary.InternetDomainTopLevel),
                    GenerateTestCasesForSut(Any.InternetDomainTopLevel)
                },
                new object[]
                {new Words(FromDictionary.InternetUrl), GenerateTestCasesForSut(Any.InternetUrl)}
            };
        }
    }
}
