using NSubstitute;
using TestStack.Dossier.DataSources.Dictionaries;
using TestStack.Dossier.DataSources.Generators;
using Xunit;

namespace TestStack.Dossier.Tests.DataSources.Dictionaries
{
    public class FileDictionarySourceTests
    {
        [Fact]
        public void WhenInitializingList_ThenPassClassNameToRepositoryAsDictionaryName()
        {
            var repository = Substitute.For<IDictionaryRepository>();
            var sut = new DummySource(repository);

            var result = sut.Data;

            repository.Received().GetWordsFrom("Dummy");
        }
    }

    public class DummySource : FileDictionarySource
    {
        internal DummySource(IDictionaryRepository repository) 
            : base(Substitute.For<IGenerator>(), repository) { }
    }
}
