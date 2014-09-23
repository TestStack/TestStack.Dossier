using System;
using System.Collections.Generic;
using System.Linq;
using NTestDataBuilder.DataSources;
using NTestDataBuilder.EquivalenceClasses;
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
            var unique = testCases.Distinct().Count();
            unique.ShouldBeGreaterThan(5);
        }

        public static IEnumerable<object[]> TestCases
        {
            get
            {
                yield return new object[] { new FirstNameSource(), GenerateTestCasesForSut(Any.FirstName) };
                yield return new object[] { new LastNameSource(), GenerateTestCasesForSut(Any.LastName) };
                yield return new object[] { new FullNameSource(), GenerateTestCasesForSut(Any.FullName) };
                yield return new object[] { new CompanySource(), GenerateTestCasesForSut(Any.Company) };
                yield return new object[] { new StreetSource(), GenerateTestCasesForSut(Any.Street) };
                yield return new object[] { new CitySource(), GenerateTestCasesForSut(Any.City) };
                yield return new object[] { new CountySource(), GenerateTestCasesForSut(Any.County) };
                yield return new object[] { new PostCodeSource(), GenerateTestCasesForSut(Any.PostCode) };
                yield return new object[] { new PhoneSource(), GenerateTestCasesForSut(Any.Phone) };
                yield return new object[] { new EmailSource(), GenerateTestCasesForSut(Any.Email) };
                yield return new object[] { new WebsiteSource(), GenerateTestCasesForSut(Any.Website) };
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
