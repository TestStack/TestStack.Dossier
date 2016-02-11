using System;
using TestStack.Dossier.DataSources.Dictionaries;

namespace TestStack.Dossier.DataSources.Person
{
    /// <summary>
    /// Dictionary of name titles
    /// </summary>
    [Obsolete("PersonNameTitleSource is deprecated, please use Words(FromDictionary.PersonNameTitle) instead.")]
    public class PersonNameTitleSource : FileDictionarySource
    {
    }
}
