using System.Collections.Generic;
using TestStack.Dossier.DataSources;
using TestStack.Dossier.DataSources.Dictionaries;
using Xunit.Extensions;

namespace TestStack.Dossier.Tests.EquivalenceClasses
{
    public class IdentifierEquivalenceTests : FileDictionaryEquivalenceTests
    {
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
                    GenerateTestCasesForSut(Any.Identifier.BitcoinAddress)
                },
                new object[]
                {new Words(FromDictionary.IdentifierIban), GenerateTestCasesForSut(Any.Identifier.Iban)},
                new object[]
                {
                    new Words(FromDictionary.IdentifierIpAddressV4), GenerateTestCasesForSut(Any.Identifier.IpAddressV4)
                },
                new object[]
                {
                    new Words(FromDictionary.IdentifierIpAddressV6), GenerateTestCasesForSut(Any.Identifier.IpAddressV6)
                },
                new object[]
                {new Words(FromDictionary.IdentifierIsbn), GenerateTestCasesForSut(Any.Identifier.Isbn)},
                new object[]
                {
                    new Words(FromDictionary.IdentifierMacAddress),
                    GenerateTestCasesForSut(Any.Identifier.MacAddress)
                }
            };
        }
    }
}
