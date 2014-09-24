using System;
using System.Collections.Generic;
using System.Linq;
using NTestDataBuilder.DataSources;
using NTestDataBuilder.DataSources.Person;
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
                yield return new object[] { new PersonEmailAddressSource(), GenerateTestCasesForSut(Any.PersonEmailAddress) };
                yield return new object[] { new PersonLanguageSource(), GenerateTestCasesForSut(Any.PersonLanguage) };
                yield return new object[] { new PersonNameFirstFemaleSource(), GenerateTestCasesForSut(Any.PersonNameFirstFemale) };
                yield return new object[] { new PersonNameFirstSource(), GenerateTestCasesForSut(Any.PersonNameFirst) };
                yield return new object[] { new PersonNameFullSource(), GenerateTestCasesForSut(Any.PersonNameFull) };
                yield return new object[] { new PersonNameLastSource(), GenerateTestCasesForSut(Any.PersonNameLast) };
                yield return new object[] { new PersonNameFirstMaleSource(), GenerateTestCasesForSut(Any.PersonNameFirstMale) };
                yield return new object[] { new PersonNameSuffixSource(), GenerateTestCasesForSut(Any.PersonNameSuffix) };
                yield return new object[] { new PersonNameTitleSource(), GenerateTestCasesForSut(Any.PersonNameTitle) };
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
