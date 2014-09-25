using System.Collections.Generic;
using NTestDataBuilder.DataSources.Generators;

namespace NTestDataBuilder.DataSources.Dictionaries
{
    /// <summary>
    /// The base class for data sources that load their data from dictionaries stored in files
    /// </summary>
    public abstract class FileDictionarySource : DataSource<string>
    {
        private readonly IDictionaryRepository _repository;

        /// <inheritdoc />
        protected FileDictionarySource()
            : this(new RandomGenerator(), new CachedFileDictionaryRepository()) { }

        /// <inheritdoc />
        internal FileDictionarySource(IGenerator generator, IDictionaryRepository repository)
            : base(generator)
        {
            _repository = repository;
        }

        /// <inheritdoc />
        protected override IList<string> InitializeDataSource()
        {
            var dictionary = GetType().Name.Replace("Source", string.Empty);
            return _repository.GetWordsFrom(dictionary);
        }
    }
}