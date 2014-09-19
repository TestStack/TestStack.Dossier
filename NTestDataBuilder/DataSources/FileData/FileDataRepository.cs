using System.Collections.Generic;
using System.Linq;

namespace NTestDataBuilder.DataSources.FileData
{
    internal class FileDataRepository
    {
        internal static IList<Person> People { get; private set; }

        static FileDataRepository()
        {
            var dt = FileDataSourceHelpers.ConvertCsvToDataTable("NTestDataBuilder.DataSources.FileData.uk-500.csv");
            var people = dt.AsEnumerable<Person>().ToList();
            People = people;
            //People = FileDataSourceHelpers.ConvertCsvToDataTable("NTestDataBuilder.DataSources.FileData.uk-500.csv")
            //    .AsEnumerable<Person>()
            //    .ToList();
        }
    }
}
