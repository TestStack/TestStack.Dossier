using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TestStack.Dossier.DataSources.Dictionaries
{
    /// <summary>
    /// Retrieves words from dictionaries stored in files. First looks for external file that user might have created. If this does not exist then data is retrieved from embedded resource files.
    /// </summary>
    internal class CachedFileDictionaryRepository : IDictionaryRepository
    {
        public IList<string> GetWordsFrom(string dictionary)
        {
            if (Cache.Contains(dictionary))
            {
                return Cache.Get(dictionary);
            }

            var words = new List<string>();

            var name = string.Format("{0}.txt", dictionary);
            if (File.Exists(name))
            {
                words = File.ReadAllLines(name).ToList();
            }
            else
            {
                var resourceName = string.Format("TestStack.Dossier.DataSources.Dictionaries.Resources.{0}", name);
                words = GetWordsFromEmbeddedResource(GetType().Assembly, resourceName).ToList();
            }

            Cache.Set(dictionary, words);
            return words;
        }

        internal IList<string> GetWordsFromEmbeddedResource(Assembly assembly, string resourceName)
        {
            var items = new List<string>();
            var stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
            {
                throw new FileNotFoundException();
            }
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    items.Add(line);
                }
            }
            return items;
        }
    }
}