using System.Collections.Generic;
using TestStack.Dossier.DataSources;
using TestStack.Dossier.DataSources.Dictionaries;
using Xunit.Extensions;

namespace TestStack.Dossier.Tests.EquivalenceClasses
{
    public class IdentifierEquivalenceTests : FileDictionaryEquivalenceTests
    {
        public AnonymousValueFixture Any { get; } = new AnonymousValueFixture();

        [Theory]
        [ClassData(typeof(IdentifierTestCases))]
        public override void WhenGettingAnyData_ThenReturnRandomDataWhichIsReasonablyUnique(DataSource<string> source, List<string> testCases)
        {
            base.WhenGettingAnyData_ThenReturnRandomDataWhichIsReasonablyUnique(source, testCases);
        }
    }

    public class IdentifierTestCases : FileDictionaryEquivalenceTestCases
    {
        protected override List<object[]> GetData()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new Words(FromDictionary.IdentifierBitcoinAddress),
                    GenerateTestCasesForSut(Any.IdentifierBitcoinAddress)
                },
                new object[]
                {new Words(FromDictionary.IdentifierIban), GenerateTestCasesForSut(Any.IdentifierIban)},
                new object[]
                {
                    new Words(FromDictionary.IdentifierIpAddressV4), GenerateTestCasesForSut(Any.IdentifierIpAddressV4)
                },
                new object[]
                {
                    new Words(FromDictionary.IdentifierIpAddressV6), GenerateTestCasesForSut(Any.IdentifierIpAddressV6)
                },
                new object[]
                {new Words(FromDictionary.IdentifierIsbn), GenerateTestCasesForSut(Any.IdentifierIsbn)},
                new object[]
                {
                    new Words(FromDictionary.IdentifierMacAddress),
                    GenerateTestCasesForSut(Any.IdentifierMacAddress)
                }
            };
        }
    }
}
