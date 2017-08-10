using System.Collections.Generic;
using TestStack.Dossier.DataSources;
using TestStack.Dossier.DataSources.Dictionaries;
using Xunit;

namespace TestStack.Dossier.Tests.EquivalenceClasses
{
    public class ShirtSizeEquivalenceTests : FileDictionaryEquivalenceTests
    {
        [Theory]
        [ClassData(typeof(ShirtSizeTestCases))]
        public override void WhenGettingAnyData_ThenReturnRandomDataWhichIsReasonablyUnique(DataSource<string> source, List<string> testCases)
        {
            base.WhenGettingAnyData_ThenReturnRandomDataWhichIsReasonablyUnique(source, testCases);
        }
    }

    public class ShirtSizeTestCases : FileDictionaryEquivalenceTestCases
    {
        protected override List<object[]> GetData()
        {
            return new List<object[]>
            {
                new object[]
                {new Words(FromDictionary.ShirtSize), GenerateTestCasesForSut(Any.ShirtSize)}
            };
        }
    }
}
