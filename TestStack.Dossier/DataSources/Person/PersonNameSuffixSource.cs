using System;
using TestStack.Dossier.DataSources.Dictionaries;

namespace TestStack.Dossier.DataSources.Person
{
    /// <summary>
    /// Dictionary of name suffixes
    /// </summary>
    [Obsolete("PersonNameSuffixSource is deprecated, please use Words(FromDictionary.PersonNameSuffix) instead.")]
    public class PersonNameSuffixSource : FileDictionarySource
    {
    }
}