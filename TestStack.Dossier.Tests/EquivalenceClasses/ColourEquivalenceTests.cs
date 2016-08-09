using System.Collections.Generic;
using TestStack.Dossier.DataSources;
using TestStack.Dossier.DataSources.Dictionaries;
using Xunit.Extensions;

namespace TestStack.Dossier.Tests.EquivalenceClasses
{
    public class ColourEquivalenceTests : FileDictionaryEquivalenceTests
    {
        [Theory]
        [ClassData(typeof(ColourTestCases))]
        public override void WhenGettingAnyData_ThenReturnRandomDataWhichIsReasonablyUnique(DataSource<string> source, List<string> testCases)
        {
            base.WhenGettingAnyData_ThenReturnRandomDataWhichIsReasonablyUnique(source, testCases);
        }
    }

    public class ColourTestCases : FileDictionaryEquivalenceTestCases
    {
        protected override List<object[]> GetData()
        {
            return new List<object[]>
            {
                new object[]
                {new Words(FromDictionary.ColourHex), GenerateTestCasesForSut(Any.Colour.Hex)},
                new object[]
                {new Words(FromDictionary.ColourName), GenerateTestCasesForSut(Any.Colour.Name)}
            };
        }
    }
}
