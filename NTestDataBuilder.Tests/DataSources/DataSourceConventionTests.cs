using System.Collections.Generic;
using System.Linq;
using NTestDataBuilder.DataSources;
using NTestDataBuilder.DataSources.Geography;
using NTestDataBuilder.DataSources.Person;
using Shouldly;
using Xunit.Extensions;

namespace NTestDataBuilder.Tests.DataSources
{
    public class DataSourceConventionTests
    {
        [Theory]
        [PropertyData("TestCases")]
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
                yield return new object[] { new GeoContinentSource(), 7 };
                yield return new object[] { new GeoCountrySource(), 249 };
                yield return new object[] { new GeoCountryCodeSource(), 64 };
                yield return new object[] { new GeoLatitudeSource(), 1000 };
                yield return new object[] { new GeoLongitudeSource(), 1000 };

                yield return new object[] { new PersonEmailAddressSource(), 1000 };
                yield return new object[] { new PersonLanguageSource(), 97 };
                yield return new object[] { new PersonNameFirstFemaleSource(), 100 };
                yield return new object[] { new PersonNameFirstSource(), 479 };
                yield return new object[] { new PersonNameFullSource(), 1000 };
                yield return new object[] { new PersonNameLastSource(), 747 };
                yield return new object[] { new PersonNameFirstMaleSource(), 100 };
                yield return new object[] { new PersonNameSuffixSource(), 5 };
                yield return new object[] { new PersonNameTitleSource(), 9 };
            }
        }
    }
}