using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;
using TestStack.Dossier.DataSources;
using TestStack.Dossier.DataSources.Dictionaries;
using Xunit.Extensions;

namespace TestStack.Dossier.Tests.EquivalenceClasses
{
    public class GeoEquivalenceClassesTests
    {
         public static AnonymousValueFixture Any { get; private set; } = new AnonymousValueFixture();

        [Theory]
        [PropertyData("TestCases")]
        public void WhenGettingAnyGeoData_ThenReturnRandomGeoDataWhichIsReasonablyUnique(DataSource<string> source,
            List<string> testCases)
        {
            foreach (var testCase in testCases)
            {
                testCase.ShouldBeOfType<string>();
                testCase.ShouldNotBeNullOrEmpty();
                source.Data.ShouldContain(testCase);
            }
            if (source.Data.Count > 15)
            {
                var unique = testCases.Distinct().Count();
                unique.ShouldBeGreaterThan(5);
            }
        }

        public static IEnumerable<object[]> TestCases
        {
            get
            {
                yield return new object[] { new Words(FromDictionary.GeoContinent), GenerateTestCasesForSut(Any.GeoContinent) };
                yield return new object[] { new Words(FromDictionary.GeoCountry), GenerateTestCasesForSut(Any.GeoCountry) };
                yield return new object[] { new Words(FromDictionary.GeoCountryCode), GenerateTestCasesForSut(Any.GeoCountryCode) };
                yield return new object[] { new Words(FromDictionary.GeoLatitude), GenerateTestCasesForSut(Any.GeoLatitude) };
                yield return new object[] { new Words(FromDictionary.GeoLongitude), GenerateTestCasesForSut(Any.GeoLongitude) };
            }
        }

        private static List<string> GenerateTestCasesForSut(Func<string> any)
        {
            var results = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                results.Add(any());
            }
            return results;
        } 
    }
}
