using System;
using System.IO;
using Shouldly;
using TestStack.Dossier.DataSources.Dictionaries;
using Xunit;

namespace TestStack.Dossier.Tests.DataSources.Dictionaries
{
    public class WordsCacheTests : IDisposable
    {
        private const string DictionaryThatDoesNotExist = "DictionaryThatDoesNotExist";

        public WordsCacheTests()
        {
            WordsCache.Clear();
        }

        [Fact]
        public void WhenRequestingAnItemInTheCache_ThenReturnsSameItem()
        {
            var words1 = WordsCache.Get(FromDictionary.InternetUrl);
            var words2 = WordsCache.Get(FromDictionary.InternetUrl);
            words1.ShouldBeSameAs(words2);
        }

        [Fact]
        public void WhenRequestingAnItemNotInTheCache_ThenReturnsWordsSourceForItemDictionary()
        {
            var words = WordsCache.Get(DictionaryThatDoesNotExist);
            words.DictionaryName.ShouldBe(DictionaryThatDoesNotExist);
        }

        [Fact]
        public void WhenUsingCachedWordsForNonExistentDictionary_ThenWordsSourceThrowsFileNotFoundException()
        {
            var words = WordsCache.Get(DictionaryThatDoesNotExist);
            Should.Throw<FileNotFoundException>(() => words.Next());
        }

        public void Dispose()
        {
            WordsCache.Clear();
        }
    }
}
