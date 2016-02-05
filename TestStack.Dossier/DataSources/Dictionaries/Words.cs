using System.Collections.Generic;
using TestStack.Dossier.DataSources.Generators;

namespace TestStack.Dossier.DataSources.Dictionaries
{
    /// <summary>
    /// The wrapper class for data sources that load words from dictionaries stored in files
    /// </summary>
    public class Words : DataSource<string>
    {
        private readonly string _dictionaryName;
        private readonly IDictionaryRepository _repository;

        /// <inheritdoc />
        public Words(string dictionaryName)
            : this(new RandomGenerator(), new CachedFileDictionaryRepository(), dictionaryName)
        {
        }

        /// <inheritdoc />
        internal Words(IGenerator generator, IDictionaryRepository repository, string dictionaryName)
            : base(generator)
        {
            _repository = repository;
            _dictionaryName = dictionaryName;
        }

        internal string DictionaryName => _dictionaryName;

        /// <inheritdoc />
        protected override IList<string> InitializeDataSource()
        {
            return _repository.GetWordsFrom(_dictionaryName);
        }
    }
}