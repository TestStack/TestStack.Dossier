using System;
using TestStack.Dossier.DataSources.Dictionaries;

namespace TestStack.Dossier.DataSources.Geography
{
    /// <summary>
    /// Dictionary of country codes
    /// </summary>
    [Obsolete("GeoCountryCodeSource is deprecated, please use Words(FromDictionary.GeoCountryCode) instead.")]
    public class GeoCountryCodeSource : FileDictionarySource
    {
    }
}