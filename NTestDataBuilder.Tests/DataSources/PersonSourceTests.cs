using System.Collections.Generic;
using System.Linq;
using NTestDataBuilder.DataSources;
using Shouldly;
using Xunit.Extensions;

namespace NTestDataBuilder.Tests.DataSources
{
    public class PersonSourceTests
    {
        [Theory]
        [PropertyData("TestCases")]
        public void PersonSourceSpec(DataSource<string> sut, int expectedCount)
        {
            var collection = sut.List.ToList();
            collection.Count.ShouldBe(expectedCount);
            collection.Count.ShouldBe(sut.List.Distinct().ToList().Count);
            collection.ForEach(item => item.ShouldNotBeNullOrEmpty());
        }

        public static IEnumerable<object[]> TestCases
        {
            get
            {
                yield return new object[] { new FirstNameSource(), 479 };
                yield return new object[] { new LastNameSource(), 498 };
                yield return new object[] { new FullNameSource(), 500 };
                yield return new object[] { new CompanySource(), 496 };
                yield return new object[] { new StreetSource(), 498 };
                yield return new object[] { new CitySource(), 483 };
                yield return new object[] { new CountySource(), 214 };
                yield return new object[] { new PostCodeSource(), 433 };
                yield return new object[] { new PhoneSource(), 500 };
                yield return new object[] { new EmailSource(), 500 };
                yield return new object[] { new WebsiteSource(), 498 };

            }
        }
    }
}