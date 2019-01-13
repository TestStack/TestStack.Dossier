using System.Collections.Generic;
using TestStack.Dossier.DataSources;
using TestStack.Dossier.DataSources.Dictionaries;
using Xunit;

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
                    GenerateTestCasesForSut(Any.Internet.DomainCountryCodeTopLevelDomain)
                },
                new object[]
                {new Words(FromDictionary.InternetDomainName), GenerateTestCasesForSut(Any.Internet.DomainName)},
                new object[]
                {
                    new Words(FromDictionary.InternetDomainTopLevel),
                    GenerateTestCasesForSut(Any.Internet.DomainTopLevel)
                },
                new object[]
                {new Words(FromDictionary.InternetUrl), GenerateTestCasesForSut(Any.Internet.Url)}
            };
        }
    }
}
