using System;
using System.Collections.Generic;
using TestStack.Dossier.DataSources.Generators;

namespace TestStack.Dossier.DataSources.Dictionaries
{
    /// <summary>
    /// The base class for data sources that load their data from dictionaries stored in files
    /// </summary>
    [Obsolete("FileDictionarySource is deprecated, please use Words(FromDictionary) instead.")]
    public abstract class FileDictionarySource : DataSource<string>
    {
        private readonly IDictionaryRepository _repository;

        /// <inheritdoc />
        protected FileDictionarySource()
            : this(new RandomGenerator(), new CachedFileDictionaryRepository())
        { }

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