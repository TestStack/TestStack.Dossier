using System;
using TestStack.Dossier.DataSources.Dictionaries;

namespace TestStack.Dossier.DataSources.Geography
{
    /// <summary>
    /// Dictionary of latitude coordinates
    /// </summary>
    [Obsolete("GeoLatitudeSource is deprecated, please use Words(FromDictionary.GeoLatitude) instead.")]
    public class GeoLatitudeSource : FileDictionarySource
    {
    }
}