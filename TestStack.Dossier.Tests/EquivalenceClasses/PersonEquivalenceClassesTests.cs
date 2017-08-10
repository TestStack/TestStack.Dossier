using System.Collections.Generic;
using System.Linq;
using Shouldly;
using TestStack.Dossier.DataSources;
using TestStack.Dossier.DataSources.Dictionaries;
using TestStack.Dossier.EquivalenceClasses.Person;
using Xunit;

namespace TestStack.Dossier.Tests.EquivalenceClasses
{
    public class PersonEquivalenceClassesTests : FileDictionaryEquivalenceTests
    {
        [Theory]
        [ClassData(typeof(PersonTestCases2))]
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
            generatedValues.Add(any2.UniqueEmailAddress());
            for (var i = 0; i < source.Data.Count - 1; i++)
            {
                generatedValues.Add(Any.UniqueEmailAddress());
            }

            generatedValues.Distinct().Count()
                .ShouldBe(generatedValues.Count);
        }
    }

    public class PersonTestCases2 : FileDictionaryEquivalenceTestCases
    {
        protected override List<object[]> GetData()
        {
            return new List<object[]>
            {
                new object[]
                {new Words(FromDictionary.PersonEmailAddress), GenerateTestCasesForSut(Any.EmailAddress)},
                new object[] {new Words(FromDictionary.PersonLanguage), GenerateTestCasesForSut(Any.Language)},
                new object[]
                {new Words(FromDictionary.PersonNameFirstFemale), GenerateTestCasesForSut(Any.FemaleFirstName)},
                new object[] {new Words(FromDictionary.PersonNameFirst), GenerateTestCasesForSut(Any.FirstName)},
                new object[] {new Words(FromDictionary.PersonNameFull), GenerateTestCasesForSut(Any.FullName)},
                new object[] {new Words(FromDictionary.PersonNameLast), GenerateTestCasesForSut(Any.LastName)},
                new object[]
                {new Words(FromDictionary.PersonNameFirstMale), GenerateTestCasesForSut(Any.MaleFirstName)},
                new object[] {new Words(FromDictionary.PersonNameSuffix), GenerateTestCasesForSut(Any.Suffix)},
                new object[] {new Words(FromDictionary.PersonNameTitle), GenerateTestCasesForSut(Any.Title)},
            };
        }
    }

}
