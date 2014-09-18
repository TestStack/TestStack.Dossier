using System.Collections.Generic;
using NTestDataBuilder.DataSources.Generators;

namespace NTestDataBuilder.DataSources
{
    //public interface IDataSource<T> 
    //{
    //    T Next();
    //}
    public abstract class DataSource<T> //: IDataSource<T>
    {
        public IList<T> List { get; private set; }
        public IGenerator Generator { get; private set; }

        public DataSource(IGenerator generator)
        {
            Generator = generator;
            List = InitializeList();
            Generator.ListSize = List.Count;
        }

        public DataSource() 
            : this(new RandomGenerator()) { }

        protected abstract IList<T> InitializeList();

        public virtual T Next()
        {
            return List[Generator.Generate()];
        }
    }
}