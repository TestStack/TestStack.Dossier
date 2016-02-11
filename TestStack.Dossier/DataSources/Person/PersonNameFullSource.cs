using System;
using TestStack.Dossier.DataSources.Dictionaries;

namespace TestStack.Dossier.DataSources.Person
{
    /// <summary>
    /// Dictionary of male and female full names - first and last name
    /// </summary>
    [Obsolete("PersonNameFullSource is deprecated, please use Words(FromDictionary.PersonNameFull) instead.")]
    public class PersonNameFullSource : FileDictionarySource
    {
    }
}