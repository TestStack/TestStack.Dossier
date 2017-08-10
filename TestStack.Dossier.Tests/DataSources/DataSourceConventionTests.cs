using System.Collections.Generic;
using System.Linq;
using Shouldly;
using TestStack.Dossier.DataSources;
using TestStack.Dossier.DataSources.Dictionaries;
using Xunit;

namespace TestStack.Dossier.Tests.DataSources
{
    public class DataSourceConventionTests
    {
        [Theory]
        [MemberData("TestCases")]
        public void DataSourceConventions(DataSource<string> sut, int expectedCount)
        {
            var collection = sut.Data.ToList();
            collection.Count.ShouldBe(expectedCount);
            collection.Count.ShouldBe(sut.Data.Distinct().ToList().Count);
            collection.ForEach(item => item.ShouldNotBeNullOrEmpty());
        }

        public static IEnumerable<object[]> TestCases
        {
            get
            {
                yield return new object[] { new Words(FromDictionary.GeoContinent), 7 };
                yield return new object[] { new Words(FromDictionary.GeoCountry), 249 };
                yield return new object[] { new Words(FromDictionary.GeoCountryCode), 64 };
                yield return new object[] { new Words(FromDictionary.GeoLatitude), 1000 };
                yield return new object[] { new Words(FromDictionary.GeoLongitude), 1000 };

                yield return new object[] { new Words(FromDictionary.PersonEmailAddress), 1000 };
                yield return new object[] { new Words(FromDictionary.PersonLanguage), 97 };
                yield return new object[] { new Words(FromDictionary.PersonNameFirstFemale), 100 };
                yield return new object[] { new Words(FromDictionary.PersonNameFirst), 479 };
                yield return new object[] { new Words(FromDictionary.PersonNameFull), 1000 };
                yield return new object[] { new Words(FromDictionary.PersonNameLast), 747 };
                yield return new object[] { new Words(FromDictionary.PersonNameFirstMale), 100 };
                yield return new object[] { new Words(FromDictionary.PersonNameSuffix), 5 };
                yield return new object[] { new Words(FromDictionary.PersonNameTitle), 9 };
            }
        }
    }
}