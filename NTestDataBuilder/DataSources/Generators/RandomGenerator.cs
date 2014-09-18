using System;

namespace NTestDataBuilder.DataSources.Generators
{
    public class RandomGenerator : IGenerator
    {
        private readonly Random _random;
        public int StartIndex { get; set; }
        public int ListSize { get; set; }

        public RandomGenerator() : this(0,1)
        {
        }

        public RandomGenerator(int startIndex, int listSize)
        {
            Guard.Against(startIndex < 0, "startIndex must be zero or more");
            Guard.Against(listSize < 1, "listSize must be greater than zero");
            Guard.Against(startIndex >= listSize, "startIndex must be less than listSize");

            StartIndex = startIndex;
            ListSize = listSize;
            _random = new Random();
        }

        public int Generate()
        {
            return _random.Next(StartIndex, ListSize);
        }
    }
}