using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace NTestDataBuilder.DataSources.Dictionaries
{
    /// <summary>
    /// Retrieves words from dictionaries stored in files
    /// </summary>
    public class FileDictionaryRepository : IDictionaryRepository
    {
        public IList<string> GetWordsFrom(string dictionary)
        {
            // let users override values with file in bin directory
            var name = string.Format("{0}.txt", dictionary);
            if (File.Exists(name))
            {
                return File.ReadAllLines(name);
            }

            // otherwise get data from embedded resource files
            var resourceName = string.Format("NTestDataBuilder.DataSources.Dictionaries.Resources.{0}", name);
            return GetWordsFromEmbeddedResource(GetType().Assembly, resourceName);
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