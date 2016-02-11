using System;
using TestStack.Dossier.DataSources.Dictionaries;

namespace TestStack.Dossier.DataSources.Geography
{
    /// <summary>
    /// Dictionary of longitude coordinates codes
    /// </summary>
    [Obsolete("GeoLongitudeSource is deprecated, please use Words(FromDictionary.GeoLongitude) instead.")]
    public class GeoLongitudeSource : FileDictionarySource
    {
    }
}
