using NSubstitute;
using NTestDataBuilder.DataSources.Dictionaries;
using NTestDataBuilder.DataSources.Generators;
using Xunit;

namespace NTestDataBuilder.Tests.DataSources.Dictionaries
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
