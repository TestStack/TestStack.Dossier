using System.Collections.Generic;
using System.Linq;
using NTestDataBuilder.DataSources.FileData;
using NTestDataBuilder.DataSources.Generators;

namespace NTestDataBuilder.DataSources
{
    /// <summary>
    /// Free sample data for testing obtained from http://www.briandunning.com/sample-data/
    /// </summary>
    public class EmailSource : DataSource<string>
    {
        /// <inheritdoc />
        public EmailSource() 
            : base() { }

        /// <inheritdoc />
        public EmailSource(IGenerator generator) 
            : base(generator) { }

        /// <inheritdoc />
        protected override IList<string> InitializeList()
        {
            return FileDataRepository.People
                .Select(person => person.Email)
                .Distinct()
                .ToList();
        }
    }
}
