using System.Collections.Generic;
using NTestDataBuilder.DataSources.Generators;

namespace NTestDataBuilder.DataSources
{
    public interface IDataSource<T> 
    {
        IList<T> Data { get; }
        IGenerator Generator { get; }
        T Next();
    }
}