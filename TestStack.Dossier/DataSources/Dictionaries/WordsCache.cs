using System.Collections.Concurrent;

namespace TestStack.Dossier.DataSources.Dictionaries
{
    /// <summary>
    /// Just caches a file dictionary <see cref="Words"/> data source the first time it is accessed and returns the same instance
    /// each subsequent request. The Words data source is then responsible for lazy loading its dictionary contents
    /// the first time it is accessed. At that point an exception will be thrown if the dictionary does not exist.
    /// </summary>
    internal static class WordsCache
    {
        private static ConcurrentDictionary<string, Words> _cache = new ConcurrentDictionary<string, Words>();

        /// <summary>
        /// Gets the Words in the file with the specified dictionary name. 
        /// This method is used by <see cref="AnonymousValueFixture"/>.
        /// </summary>
        /// <param name="dictionaryName">Name of the dictionary file.</param>
        /// <returns></returns>
        internal static Words Get(string dictionaryName)
        {
            if (!_cache.ContainsKey(dictionaryName))
            {
                _cache[dictionaryName] = new Words(dictionaryName);
            }
            return _cache[dictionaryName];
        }

        /// <summary>
        /// Just exposed for testing purposes.
        /// </summary>
        internal static void Clear()
        {
            _cache = new ConcurrentDictionary<string, Words>();
        }
    }
}
