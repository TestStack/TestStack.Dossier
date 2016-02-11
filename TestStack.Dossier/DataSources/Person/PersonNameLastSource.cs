using System;
using TestStack.Dossier.DataSources.Dictionaries;

namespace TestStack.Dossier.DataSources.Person
{
    /// <summary>
    /// Dictionary of last names
    /// </summary>
    [Obsolete("PersonNameLastSource is deprecated, please use Words(FromDictionary.PersonNameLast) instead.")]
    public class PersonNameLastSource : FileDictionarySource
    {
    }
}