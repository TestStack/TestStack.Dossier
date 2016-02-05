using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;
using TestStack.Dossier.DataSources;
using TestStack.Dossier.DataSources.Dictionaries;
using Xunit;
using Xunit.Extensions;

namespace TestStack.Dossier.Tests.EquivalenceClasses
{
    public class PersonEquivalenceClassesTests
    {
         public static AnonymousValueFixture Any { get; } = new AnonymousValueFixture();

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

        [Fact]
        public void WhenGettingUniqueEmail_ThenReturnUniqueEmailsAcrossFixtureInstances()
        {
            var source = new Words(FromDictionary.PersonEmailAddress);
            var generatedValues = new List<string>();
            var any2 = new AnonymousValueFixture();

            generatedValues.Add(any2.UniqueEmailAddress());
            for (var i = 0; i < source.Data.Count - 1; i++)
            {
                generatedValues.Add(Any.UniqueEmailAddress());
            }

            generatedValues.Distinct().Count()
                .ShouldBe(generatedValues.Count);
        }

        public static IEnumerable<object[]> TestCases
        {
            get
            {
                yield return new object[] { new Words(FromDictionary.PersonEmailAddress), GenerateTestCasesForSut(Any.PersonEmailAddress) };
                yield return new object[] { new Words(FromDictionary.PersonLanguage), GenerateTestCasesForSut(Any.PersonLanguage) };
                yield return new object[] { new Words(FromDictionary.PersonNameFirstFemale), GenerateTestCasesForSut(Any.PersonNameFirstFemale) };
                yield return new object[] { new Words(FromDictionary.PersonNameFirst), GenerateTestCasesForSut(Any.PersonNameFirst) };
                yield return new object[] { new Words(FromDictionary.PersonNameFull), GenerateTestCasesForSut(Any.PersonNameFull) };
                yield return new object[] { new Words(FromDictionary.PersonNameLast), GenerateTestCasesForSut(Any.PersonNameLast) };
                yield return new object[] { new Words(FromDictionary.PersonNameFirstMale), GenerateTestCasesForSut(Any.PersonNameFirstMale) };
                yield return new object[] { new Words(FromDictionary.PersonNameSuffix), GenerateTestCasesForSut(Any.PersonNameSuffix) };
                yield return new object[] { new Words(FromDictionary.PersonNameTitle), GenerateTestCasesForSut(Any.PersonNameTitle) };
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
