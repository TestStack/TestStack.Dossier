using System.Collections.Generic;
using TestStack.Dossier.DataSources;
using TestStack.Dossier.DataSources.Dictionaries;
using Xunit.Extensions;

namespace TestStack.Dossier.Tests.EquivalenceClasses
{
    public class GeoEquivalenceTests : FileDictionaryEquivalenceTests
    {
        [Theory]
        [ClassData(typeof(GeoTestCases))]
        public override void WhenGettingAnyData_ThenReturnRandomDataWhichIsReasonablyUnique(DataSource<string> source, List<string> testCases)
        {
            base.WhenGettingAnyData_ThenReturnRandomDataWhichIsReasonablyUnique(source, testCases);
        }
    }

    public class GeoTestCases : FileDictionaryEquivalenceTestCases
    {
        protected  override List<object[]> GetData()
        {
            return new List<object[]>
            {
                new object[] {new Words(FromDictionary.GeoContinent), GenerateTestCasesForSut(Any.GeoContinent)},
                new object[] {new Words(FromDictionary.GeoCountry), GenerateTestCasesForSut(Any.GeoCountry)},
                new object[] {new Words(FromDictionary.GeoCountryCode), GenerateTestCasesForSut(Any.GeoCountryCode)},
                new object[] {new Words(FromDictionary.GeoLatitude), GenerateTestCasesForSut(Any.GeoLatitude)},
                new object[] {new Words(FromDictionary.GeoLongitude), GenerateTestCasesForSut(Any.GeoLongitude)},
            };
        }
    }
}
