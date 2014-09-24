using System;
using System.Collections.Generic;
using System.Linq;
using NTestDataBuilder.DataSources;
using NTestDataBuilder.DataSources.Geography;
using NTestDataBuilder.EquivalenceClasses;
using Shouldly;
using Xunit.Extensions;

namespace NTestDataBuilder.Tests.EquivalenceClasses
{
    public class DictionaryEquivalenceClassesTests
    {
         public static AnonymousValueFixture Any { get; private set; }

         public DictionaryEquivalenceClassesTests()
        {
            Any = new AnonymousValueFixture();
        }

        [Theory]
        [PropertyData("TestCases")]
        public void WhenGettingAnyDictionaryData_ThenReturnRandomDictionaryDataWhichIsReasonablyUnique(DataSource<string> source,
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
                yield return new object[] { new GeoContinentSource(), GenerateTestCasesForSut(Any.GeoContinent) };
                yield return new object[] { new GeoCountrySource(), GenerateTestCasesForSut(Any.GeoCountry) };
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
