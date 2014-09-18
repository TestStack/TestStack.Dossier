using System.Collections.Generic;
using System.Linq;
using NTestDataBuilder.DataSources;
using NTestDataBuilder.EquivalenceClasses;
using Shouldly;
using Xunit;

namespace NTestDataBuilder.Tests.EquivalenceClasses
{
    public class CompanyEquivalenceClassTests
    {
        public AnonymousValueFixture Any { get; private set; }

        public CompanyEquivalenceClassTests()
        {
            Any = new AnonymousValueFixture();
        }

        [Fact]
        public void WhenGettingAnyCompany_ThenReturnRandomCompanyWhichIsReasonablyUnique()
        {
            var companySource = new CompanySource();

            var results = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                results.Add(Any.Company());
            }

            foreach (var result in results)
            {
                result.ShouldBeOfType<string>();
                result.ShouldNotBeNullOrEmpty();
                companySource.List.ShouldContain(result);
            }
            var unique = results.Distinct().Count();
            unique.ShouldBeGreaterThan(5);
        }
    }
}
