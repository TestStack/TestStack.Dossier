using System;
using TestStack.Dossier.DataSources.Dictionaries;

namespace TestStack.Dossier.DataSources.Geography
{
    /// <summary>
    /// Dictionary of continent names
    /// </summary>
    [Obsolete("GeoContinentSource is deprecated, please use Words(FromDictionary.GeoContinent) instead.")]
    public class GeoContinentSource : FileDictionarySource
    {
    }
}