using System.Collections.Generic;
using TestStack.Dossier.DataSources;
using TestStack.Dossier.DataSources.Dictionaries;
using Xunit.Extensions;

namespace TestStack.Dossier.Tests.EquivalenceClasses
{
    public class LoremIpsumEquivalenceTests : FileDictionaryEquivalenceTests
    {
        public AnonymousValueFixture Any { get; } = new AnonymousValueFixture();

        [Theory]
        [ClassData(typeof(LoremIpsumTestCases))]
        public override void WhenGettingAnyData_ThenReturnRandomDataWhichIsReasonablyUnique(DataSource<string> source, List<string> testCases)
        {
            base.WhenGettingAnyData_ThenReturnRandomDataWhichIsReasonablyUnique(source, testCases);
        }
    }

    public class LoremIpsumTestCases : FileDictionaryEquivalenceTestCases
    {
        protected override List<object[]> GetData()
        {
            return new List<object[]>
            {
                new object[]
                {new Words(FromDictionary.LoremIpsum), GenerateTestCasesForSut(Any.LoremIpsum)}
            };
        }
    }
}
