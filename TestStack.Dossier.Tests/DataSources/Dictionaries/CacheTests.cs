using System;
using System.Collections.Generic;
using Shouldly;
using TestStack.Dossier.DataSources.Dictionaries;
using Xunit;

namespace TestStack.Dossier.Tests.DataSources.Dictionaries
{
    public class CacheTests : IDisposable
    {
        public CacheTests()
        {
            Cache.Clear();
        }

        [Fact]
        public void WhenRequestingAnItemNotInTheCache_ThenReturnsNull()
        {
            Cache.Get("SomethingThatDoesNotExist").ShouldBe(null);
        }

        [Fact]
        public void WhenAddingAnItemToTheCache_ThenTheItemIsPersistedInTheCache()
        {
            var collection = new List<string>{"item1", "item2"};
            Cache.Set("myCollection", collection);
            Cache.Get("myCollection").ShouldBeSameAs(collection);
        }

        [Fact]
        public void WhenAddingAnItemToTheCacheWithTheSameKeyAsAnExistingItem_ThenTheOriginalItemIsReplacedWithTheNewItem()
        {
            var collection = new List<string> { "item1", "item2" };
            var collection2 = new List<string> { "item3" };
            Cache.Set("myCollection", collection);

            Cache.Set("myCollection", collection2);

            Cache.Get("myCollection").ShouldBeSameAs(collection2);
        }

        [Fact]
        public void WhenCheckingCacheContainesAnItemThatIsInCache_ThenShouldReturnTrue()
        {
            var collection = new List<string> {"item1", "item2"};
            Cache.Set("myCollection", collection);
            Cache.Contains("myCollection").ShouldBe(true);
        }

        [Fact]
        public void WhenCheckingCacheContainesAnItemThatIsNotInCache_ThenShouldReturnFalse()
        {
            Cache.Contains("SomethingThatDoesNotExist").ShouldBe(false);
        }


        public void Dispose()
        {
            Cache.Clear();
        }
    }
}
