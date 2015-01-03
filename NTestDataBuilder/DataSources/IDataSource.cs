using System.Collections.Generic;
using NTestDataBuilder.DataSources.Generators;

namespace NTestDataBuilder.DataSources
{
    /// <summary>
    /// Provides data.
    /// </summary>
    /// <typeparam name="T">The type of data that is provided</typeparam>
    public interface IDataSource<T> 
    {
        /// <summary>
        /// The underlying source of data.
        /// </summary>
        IList<T> Data { get; }
        
        /// <summary>
        /// The generator that is being used to return the data.
        /// </summary>
        IGenerator Generator { get; }

        /// <summary>
        /// Retrieve the next data value.
        /// </summary>
        /// <returns>The data value</returns>
        T Next();
    }
}