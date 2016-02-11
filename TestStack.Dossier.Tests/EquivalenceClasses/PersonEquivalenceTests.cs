using System.Collections.Generic;
using System.Linq;
using Shouldly;
using TestStack.Dossier.DataSources;
using TestStack.Dossier.DataSources.Dictionaries;
using Xunit;
using Xunit.Extensions;

namespace TestStack.Dossier.Tests.EquivalenceClasses
{
    public class PersonEquivalenceTests : FileDictionaryEquivalenceTests
    {
        [Theory]
        [ClassData(typeof(PersonTestCases))]
        public override void WhenGettingAnyData_ThenReturnRandomDataWhichIsReasonablyUnique(DataSource<string> source, List<string> testCases)
        {
            base.WhenGettingAnyData_ThenReturnRandomDataWhichIsReasonablyUnique(source, testCases);
        }

        [Fact]
        public void WhenGettingUniqueEmail_ThenReturnUniqueEmailsAcrossFixtureInstances()
        {
            var source = new Words(FromDictionary.PersonEmailAddress);
            var generatedValues = new List<string>();
            var any2 = new AnonymousValueFixture();

            any2.ResetUniqueEmailAddressSource();
            generatedValues.Add(any2.PersonUniqueEmailAddress());
            for (var i = 0; i < source.Data.Count - 1; i++)
            {
                generatedValues.Add(Any.PersonUniqueEmailAddress());
            }

            generatedValues.Distinct().Count()
                .ShouldBe(generatedValues.Count);
        }
    }

    public class PersonTestCases : FileDictionaryEquivalenceTestCases
    {
        protected override List<object[]> GetData()
        {
            return new List<object[]>
            {
                new object[]
                {new Words(FromDictionary.PersonEmailAddress), GenerateTestCasesForSut(Any.PersonEmailAddress)},
                new object[] {new Words(FromDictionary.PersonLanguage), GenerateTestCasesForSut(Any.PersonLanguage)},
                new object[]
                {new Words(FromDictionary.PersonNameFirstFemale), GenerateTestCasesForSut(Any.PersonNameFirstFemale)},
                new object[] {new Words(FromDictionary.PersonNameFirst), GenerateTestCasesForSut(Any.PersonNameFirst)},
                new object[] {new Words(FromDictionary.PersonNameFull), GenerateTestCasesForSut(Any.PersonNameFull)},
                new object[] {new Words(FromDictionary.PersonNameLast), GenerateTestCasesForSut(Any.PersonNameLast)},
                new object[]
                {new Words(FromDictionary.PersonNameFirstMale), GenerateTestCasesForSut(Any.PersonNameFirstMale)},
                new object[] {new Words(FromDictionary.PersonNameSuffix), GenerateTestCasesForSut(Any.PersonNameSuffix)},
                new object[] {new Words(FromDictionary.PersonNameTitle), GenerateTestCasesForSut(Any.PersonNameTitle)},
            };
        }
    }
}
