using System;
using System.Collections.Generic;
using System.Linq;
using NTestDataBuilder.DataSources;
using NTestDataBuilder.DataSources.Geography;
using NTestDataBuilder.DataSources.Person;
using NTestDataBuilder.EquivalenceClasses;
using NTestDataBuilder.EquivalenceClasses.Geo;
using NTestDataBuilder.EquivalenceClasses.Person;
using Shouldly;
using Xunit.Extensions;

namespace NTestDataBuilder.Tests.EquivalenceClasses
{
    public class PersonEquivalenceClassesTests
    {
         public static AnonymousValueFixture Any { get; private set; }

         public PersonEquivalenceClassesTests()
        {
            Any = new AnonymousValueFixture();
        }

        [Theory]
        [PropertyData("TestCases")]
        public void WhenGettingAnyPersonData_ThenReturnRandomPersonDataWhichIsReasonablyUnique(DataSource<string> source,
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
                yield return new object[] { new PersonEmailAddressSource(), GenerateTestCasesForSut(Any.EmailAddress) };
                yield return new object[] { new PersonLanguageSource(), GenerateTestCasesForSut(Any.Language) };
                yield return new object[] { new PersonNameFirstFemaleSource(), GenerateTestCasesForSut(Any.FemaleFirstName) };
                yield return new object[] { new PersonNameFirstSource(), GenerateTestCasesForSut(Any.FirstName) };
                yield return new object[] { new PersonNameFullSource(), GenerateTestCasesForSut(Any.FullName) };
                yield return new object[] { new PersonNameLastSource(), GenerateTestCasesForSut(Any.LastName) };
                yield return new object[] { new PersonNameFirstMaleSource(), GenerateTestCasesForSut(Any.MaleFirstName) };
                yield return new object[] { new PersonNameSuffixSource(), GenerateTestCasesForSut(Any.Suffix) };
                yield return new object[] { new PersonNameTitleSource(), GenerateTestCasesForSut(Any.Title) };

                yield return new object[] { new GeoContinentSource(), GenerateTestCasesForSut(Any.Continent) };
                yield return new object[] { new GeoCountrySource(), GenerateTestCasesForSut(Any.Country) };
                yield return new object[] { new GeoCountryCodeSource(), GenerateTestCasesForSut(Any.CountryCode) };
                yield return new object[] { new GeoLatitudeSource(), GenerateTestCasesForSut(Any.Latitude) };
                yield return new object[] { new GeoLongitudeSource(), GenerateTestCasesForSut(Any.Longitude) };
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
