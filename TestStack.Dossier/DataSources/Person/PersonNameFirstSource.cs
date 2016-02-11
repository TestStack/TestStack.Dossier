using System;
using TestStack.Dossier.DataSources.Dictionaries;

namespace TestStack.Dossier.DataSources.Person
{
    /// <summary>
    /// Dictionary of male and female first names
    /// </summary>
    [Obsolete("PersonNameFirstSource is deprecated, please use Words(FromDictionary.PersonNameFirst) instead.")]
    public class PersonNameFirstSource : FileDictionarySource
    {
    }
}