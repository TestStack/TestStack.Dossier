using System.Collections.Generic;
using TestStack.Dossier.DataSources.Generators;

namespace TestStack.Dossier.DataSources
{
    /// <summary>
    /// The base class for data sources to inherit from.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class DataSource<T> : IDataSource<T>
    {
        /// <summary>
        /// Allows a custom data generation strategy to be passed to the data source
        /// </summary>
        /// <param name="generator">The generator that determines the strategy for returning each item from the data source collection</param>
        protected DataSource(IGenerator generator)
        {
            Generator = generator;
        }

        /// <summary>
        /// The default constructor implements a RandomGenerator strategy
        /// </summary>
        protected DataSource()
            : this(new RandomGenerator()) { }

        private IList<T> _list;

        /// <summary>
        /// The data source data
        /// </summary>
        public IList<T> Data
        {
            get
            {
                if (_list == null)
                {
                    _list = InitializeDataSource();
                    Generator.ListSize = Data.Count;
                }
                return _list;
            }
            internal set { _list = value; }
        }

        /// <summary>
        /// The Generator that determines which record from the data source collection is returned with the Next operation.
        /// </summary>
        public IGenerator Generator { get; private set; }

        /// <summary>
        /// Each data source implements this method to load data into the data source the first time the data is accessed
        /// </summary>
        /// <returns></returns>
        protected abstract IList<T> InitializeDataSource();

        /// <summary>
        /// Returns the next item from the data source as determined by the Generator
        /// </summary>
        /// <returns></returns>
        public virtual T Next()
        {
            return Data[Generator.Generate()];
        }
    }
}