using System.Collections.Generic;

namespace NTestDataBuilder.DataSources.Dictionaries
{
    internal static class Cache
    {
        private static IDictionary<string, IList<string>> _cache = new Dictionary<string, IList<string>>();

        internal static IList<string> Get(string dictionary)
        {
            return _cache.ContainsKey(dictionary) ? _cache[dictionary] : null;
        }

        internal static void Set(string key, IList<string> items)
        {
            _cache[key] = items;
        }

        public static bool Contains(string key)
        {
            return _cache.ContainsKey(key);
        }

        public static void Clear()
        {
            _cache = new Dictionary<string, IList<string>>();
        }
    }
}
