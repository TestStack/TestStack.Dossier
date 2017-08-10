using System.Collections.Generic;
using System.Linq;
using Shouldly;
using TestStack.Dossier.DataSources;
using TestStack.Dossier.DataSources.Dictionaries;
using Xunit;

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

            PersonEquivalenceExtensions.InitializeUniqueEmailAddressSource();
            generatedValues.Add(any2.Person.UniqueEmailAddress());
            for (var i = 0; i < source.Data.Count - 1; i++)
            {
                generatedValues.Add(Any.Person.UniqueEmailAddress());
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
                {new Words(FromDictionary.PersonEmailAddress), GenerateTestCasesForSut(Any.Person.EmailAddress)},
                new object[] {new Words(FromDictionary.PersonLanguage), GenerateTestCasesForSut(Any.Person.Language)},
                new object[]
                {new Words(FromDictionary.PersonNameFirstFemale), GenerateTestCasesForSut(Any.Person.NameFirstFemale)},
                new object[] {new Words(FromDictionary.PersonNameFirst), GenerateTestCasesForSut(Any.Person.NameFirst)},
                new object[] {new Words(FromDictionary.PersonNameFull), GenerateTestCasesForSut(Any.Person.NameFull)},
                new object[] {new Words(FromDictionary.PersonNameLast), GenerateTestCasesForSut(Any.Person.NameLast)},
                new object[]
                {new Words(FromDictionary.PersonNameFirstMale), GenerateTestCasesForSut(Any.Person.NameFirstMale)},
                new object[] {new Words(FromDictionary.PersonNameSuffix), GenerateTestCasesForSut(Any.Person.NameSuffix)},
                new object[] {new Words(FromDictionary.PersonNameTitle), GenerateTestCasesForSut(Any.Person.NameTitle)},
            };
        }
    }
}
