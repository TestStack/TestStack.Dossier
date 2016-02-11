using System;
using TestStack.Dossier.DataSources.Dictionaries;

namespace TestStack.Dossier.DataSources.Person
{
    /// <summary>
    /// Dictionary of language names
    /// </summary>
    [Obsolete("PersonLanguageSource is deprecated, please use Words(FromDictionary.PersonLanguage) instead.")]
    public class PersonLanguageSource : FileDictionarySource
    {
    }
}