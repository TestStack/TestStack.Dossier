using System.Collections.Generic;
using NTestDataBuilder.DataSources.Generators;

namespace NTestDataBuilder.DataSources
{
    /// <summary>
    /// The base class for data sources to inherit from.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class DataSource<T> 
    {
        /// <summary>
        /// Allows a custom data generation strategy to be passed to the data source
        /// </summary>
        /// <param name="generator">The generator that determines the strategy for returning each item from the data source collection</param>
        protected DataSource(IGenerator generator)
        {
            Generator = generator;
            List = InitializeList();
            Generator.ListSize = List.Count;
        }

        /// <summary>
        /// The default constructor implements a RandomGenerator strategy
        /// </summary>
        protected DataSource() 
            : this(new RandomGenerator()) { }

        public IList<T> List { get; private set; }
        public IGenerator Generator { get; private set; }

        protected abstract IList<T> InitializeList();

        public virtual T Next()
        {
            return List[Generator.Generate()];
        }
    }
}