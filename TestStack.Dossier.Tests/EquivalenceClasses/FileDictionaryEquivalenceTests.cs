using System.Collections.Generic;
using System.Linq;
using Shouldly;
using TestStack.Dossier.DataSources;

namespace TestStack.Dossier.Tests.EquivalenceClasses
{
    public abstract class FileDictionaryEquivalenceTests
    {
        public virtual void WhenGettingAnyData_ThenReturnRandomDataWhichIsReasonablyUnique(DataSource<string> source,
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
    }
}