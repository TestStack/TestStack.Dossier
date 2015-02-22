using NTestDataBuilder.DataSources.Dictionaries;
using NTestDataBuilder.DataSources.Generators;

namespace NTestDataBuilder.DataSources.Person
{
    /// <summary>
    /// Dictionary of email addresses names
    /// </summary>
    public class PersonEmailAddressSource : FileDictionarySource
    {
        /// <summary>
        /// Create a person email address source with random generation.
        /// </summary>
        public PersonEmailAddressSource() {}

        /// <summary>
        /// Create a person email address source with custom generation.
        /// </summary>
        /// <param name="generator">The generator to use</param>
        public PersonEmailAddressSource(IGenerator generator)
            : base(generator, new CachedFileDictionaryRepository())
        {}
    }
}