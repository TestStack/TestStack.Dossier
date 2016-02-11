using System;
using TestStack.Dossier.DataSources.Dictionaries;

namespace TestStack.Dossier.DataSources.Geography
{
    /// <summary>
    /// Dictionary of country names
    /// </summary>
    [Obsolete("GeoCountrySource is deprecated, please use Words(FromDictionary.GeoCountry) instead.")]
    public class GeoCountrySource : FileDictionarySource
    {
    }
}