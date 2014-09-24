using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit;

namespace NTestDataBuilder.Tests.DataSources.Dictionaries.Resources
{
    public class FileDataConventions
    {
        [Fact]
        public void ApplyConventions()
        {
            var assembly = typeof(IAnonymousValueSupplier).Assembly;
            var resources = assembly
                .GetManifestResourceNames()
                .Where(x => x.EndsWith(".txt"))
                .ToList();

            foreach (var resource in resources)
            {
                var collection = GetDataFromResource(assembly, resource);
                Should_not_contain_duplicates(collection, resource);
                Should_not_contain_null_or_empty_values(collection, resource);
            }
        }

        public void Should_not_contain_duplicates(List<string> collection, string fileName)
        {
            var duplicates = collection
                .GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key)
                .ToList();
            if (duplicates.Any())
            {
                var sb = new StringBuilder();
                sb.AppendLine(string.Format("Duplicates in '{0}' file", fileName));
                duplicates.ForEach(duplicate => sb.AppendLine(duplicate));
                throw new Exception(sb.ToString());
            }
        }

        public void Should_not_contain_null_or_empty_values(List<string> collection, string fileName)
        {
            var blanks = collection.Where(string.IsNullOrEmpty).ToList();
            if (blanks.Any())
            {
                throw new Exception(string.Format("File '{0}' contains blank entries", fileName));
            }
        }

        private List<string> GetDataFromResource(Assembly assembly, string resourceName)
        {
            var items = new List<string>();
            var stream = assembly.GetManifestResourceStream(resourceName);
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
