using System;
using TestStack.Dossier.DataSources.Dictionaries;

namespace TestStack.Dossier.DataSources.Person
{
    /// <summary>
    /// Dictionary of female first names
    /// </summary>
    [Obsolete("PersonNameFirstFemaleSource is deprecated, please use Words(FromDictionary.PersonNameFirstFemale) instead.")]
    public class PersonNameFirstFemaleSource : FileDictionarySource
    {
    }
}