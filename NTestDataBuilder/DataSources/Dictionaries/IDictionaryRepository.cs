using System.Collections.Generic;

namespace NTestDataBuilder.DataSources.Dictionaries
{
    /// <summary>
    /// Retrieves words from specified dictionaries
    /// </summary>
    internal interface IDictionaryRepository
    {
        /// <summary>
        /// Retrieves words from specified dictionary
        /// </summary>
        /// <param name="dictionary">The name of the dictionary</param>
        /// <returns>A list of words</returns>
        IList<string> GetWordsFrom(string dictionary);
    }

}
