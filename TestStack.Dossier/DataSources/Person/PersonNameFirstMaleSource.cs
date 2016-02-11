using System;
using TestStack.Dossier.DataSources.Dictionaries;

namespace TestStack.Dossier.DataSources.Person
{
    /// <summary>
    /// Dictionary of male first names
    /// </summary>
    [Obsolete("PersonNameFirstMaleSource is deprecated, please use Words(FromDictionary.PersonNameFirstMale) instead.")]
    public class PersonNameFirstMaleSource : FileDictionarySource
    {
    }
}