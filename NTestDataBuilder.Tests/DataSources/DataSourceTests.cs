using System;
using System.Collections.Generic;
using NTestDataBuilder.DataSources;
using NTestDataBuilder.DataSources.Generators;
using Shouldly;
using Xunit;

namespace NTestDataBuilder.Tests.DataSources
{
    public class DataSourceTests
    {
        [Fact]
        public void WhenCreatingADataSource_ThenListShouldContainAllTheValues()
        {
            var sut = new DummyDataSource();

            var result = sut.Data;

            result.Count.ShouldBe(3);
            result.ShouldBe(new List<string> { "Value 1", "Value 2", "Value 3" });
        }

        [Fact]
        public void WhenGeneratingValuesFromDefaultDataSource_ThenShouldGenerateItemFromList()
        {
            var sut = new DummyDataSource();
            var result = sut.Next();
            sut.Data.ShouldContain(result);
        }

        [Fact]
        public void WhenGeneratingValuesFromDefaultDataSource_ThenShouldGenerateRandomItemsFromList()
        {
            var sut = new DummyDataSource();

            var results = new List<string>();
            for (int i = 0; i < 20; i++)
            {
                results.Add(sut.Next());
            }

            foreach (var item in sut.Data)
            {
                results.ShouldContain(item);
            }
        }

        [Fact]
        public void WhenGeneratingValuesFromSequentialDataSource_ThenShouldGenerateSequentialItems()
        {
            var sut = new DummyDataSource(new SequentialGenerator());

            sut.Next().ShouldBe(sut.Data[0]);
            sut.Next().ShouldBe(sut.Data[1]);
            sut.Next().ShouldBe(sut.Data[2]);
            sut.Next().ShouldBe(sut.Data[0]);
        }

        [Fact]
        public void WhenGeneratingValuesFromUniqueSequentialDataSource_ThenShouldThrowWhenCollectionExceeded()
        {
            var sut = new DummyDataSource(new SequentialGenerator(0,1,true));

            sut.Next().ShouldBe(sut.Data[0]);
            sut.Next().ShouldBe(sut.Data[1]);
            sut.Next().ShouldBe(sut.Data[2]);
            Should.Throw<InvalidOperationException>(() => sut.Next());
        }
    }

    public class DummyDataSource : DataSource<string>
    {
        public DummyDataSource(IGenerator generator)
            : base(generator) { }

        public DummyDataSource() 
            : this(new RandomGenerator()) { }

        protected override IList<string> InitializeDataSource()
        {
            return new List<string>{"Value 1", "Value 2", "Value 3"};
        }
    }
}
