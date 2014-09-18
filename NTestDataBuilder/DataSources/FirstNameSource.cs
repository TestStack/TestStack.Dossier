using System.Collections.Generic;
using System.Linq;
using NTestDataBuilder.DataSources.FileData;

namespace NTestDataBuilder.DataSources
{
    public class FirstNameSource : DataSource<string>
    {
        protected override IList<string> InitializeList()
        {
            return PersonData.People
                .Select(person => person.FirstName)
                .ToList();
        }
    }
    public class LastNameSource : DataSource<string>
    {
        protected override IList<string> InitializeList()
        {
            return PersonData.People
                .Select(person => person.LastName)
                .ToList();
        }
    }
    public class FullNameSource : DataSource<string>
    {
        protected override IList<string> InitializeList()
        {
            return PersonData.People
                .Select(person => person.FirstName + " " + person.LastName)
                .ToList();
        }
    }

}
