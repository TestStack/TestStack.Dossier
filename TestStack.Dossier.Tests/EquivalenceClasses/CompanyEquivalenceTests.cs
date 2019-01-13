using System.Collections.Generic;
using TestStack.Dossier.DataSources;
using TestStack.Dossier.DataSources.Dictionaries;
using Xunit;

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
                {new Words(FromDictionary.CompanyName), GenerateTestCasesForSut(Any.Company.Name)},
                new object[]
                {new Words(FromDictionary.CompanyIndustry), GenerateTestCasesForSut(Any.Company.Industry)},
                new object[]
                {new Words(FromDictionary.CompanyJobTitle), GenerateTestCasesForSut(Any.Company.JobTitle)},
                new object[]
                {new Words(FromDictionary.CompanyLocation), GenerateTestCasesForSut(Any.Company.Location)}
            };
        }
    }
}
