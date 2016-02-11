using System.Collections.Generic;
using TestStack.Dossier.DataSources;
using TestStack.Dossier.DataSources.Dictionaries;
using Xunit.Extensions;

namespace TestStack.Dossier.Tests.EquivalenceClasses
{
    public class CompanyEquivalenceTests : FileDictionaryEquivalenceTests
    {
        [Theory]
        [ClassData(typeof(CompanyTestCases))]
        public override void WhenGettingAnyData_ThenReturnRandomDataWhichIsReasonablyUnique(DataSource<string> source, List<string> testCases)
        {
            base.WhenGettingAnyData_ThenReturnRandomDataWhichIsReasonablyUnique(source, testCases);
        }
    }

    public class CompanyTestCases : FileDictionaryEquivalenceTestCases
    {
        protected override List<object[]> GetData()
        {
            return new List<object[]>
            {
                new object[]
                {new Words(FromDictionary.CompanyName), GenerateTestCasesForSut(Any.CompanyName)},
                new object[]
                {new Words(FromDictionary.CompanyIndustry), GenerateTestCasesForSut(Any.CompanyIndustry)},
                new object[]
                {new Words(FromDictionary.CompanyJobTitle), GenerateTestCasesForSut(Any.CompanyJobTitle)},
                new object[]
                {new Words(FromDictionary.CompanyLocation), GenerateTestCasesForSut(Any.CompanyLocation)}
            };
        }
    }
}
