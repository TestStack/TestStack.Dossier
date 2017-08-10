using System.Collections.Generic;
using TestStack.Dossier.DataSources;
using TestStack.Dossier.DataSources.Dictionaries;
using TestStack.Dossier.EquivalenceClasses.Geo;
using Xunit;

namespace TestStack.Dossier.Tests.EquivalenceClasses
{
    public class GeoEquivalenceClassesTests : FileDictionaryEquivalenceTests
    {
        [Theory]
        [ClassData(typeof(GeographyTestCases))]
        public override void WhenGettingAnyData_ThenReturnRandomDataWhichIsReasonablyUnique(DataSource<string> source, List<string> testCases)
        {
            base.WhenGettingAnyData_ThenReturnRandomDataWhichIsReasonablyUnique(source, testCases);
        }
    }

    public class GeographyTestCases : FileDictionaryEquivalenceTestCases
    {
        protected override List<object[]> GetData()
        {
            return new List<object[]>
            {
                new object[] {new Words(FromDictionary.GeoContinent), GenerateTestCasesForSut(Any.Continent)},
                new object[] {new Words(FromDictionary.GeoCountry), GenerateTestCasesForSut(Any.Country)},
                new object[] {new Words(FromDictionary.GeoCountryCode), GenerateTestCasesForSut(Any.CountryCode)},
                new object[] {new Words(FromDictionary.GeoLatitude), GenerateTestCasesForSut(Any.Latitude)},
                new object[] {new Words(FromDictionary.GeoLongitude), GenerateTestCasesForSut(Any.Longitude)},
            };
        }
    }
}
