using System;
using TestStack.Dossier.DataSources.Dictionaries;
using TestStack.Dossier.DataSources.Generators;

namespace TestStack.Dossier.DataSources.Person
{
    /// <summary>
    /// Dictionary of email addresses names
    /// </summary>
    [Obsolete("PersonEmailAddressSource is deprecated, please use Words(FromDictionary.PersonEmailAddress) instead.")]
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