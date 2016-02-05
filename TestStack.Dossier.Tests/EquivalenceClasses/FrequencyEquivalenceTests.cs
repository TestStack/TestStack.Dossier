using System.Collections.Generic;
using TestStack.Dossier.DataSources;
using TestStack.Dossier.DataSources.Dictionaries;
using Xunit.Extensions;

namespace TestStack.Dossier.Tests.EquivalenceClasses
{
    namespace TestStack.Dossier.Tests.EquivalenceClasses
    {
        public class FrequencyEquivalenceTests : FileDictionaryEquivalenceTests
        {
            public AnonymousValueFixture Any { get; } = new AnonymousValueFixture();

            [Theory]
            [ClassData(typeof(FrequencyTestCases))]
            public override void WhenGettingAnyData_ThenReturnRandomDataWhichIsReasonablyUnique(DataSource<string> source, List<string> testCases)
            {
                base.WhenGettingAnyData_ThenReturnRandomDataWhichIsReasonablyUnique(source, testCases);
            }
        }

        public class FrequencyTestCases : FileDictionaryEquivalenceTestCases
        {
            protected override List<object[]> GetData()
            {
                return new List<object[]>
                {
                    new object[]
                    {new Words(FromDictionary.Frequency), GenerateTestCasesForSut(Any.Frequency)}
                };
            }
        }
    }
}
