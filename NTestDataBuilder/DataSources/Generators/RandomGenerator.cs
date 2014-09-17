using System;

namespace NTestDataBuilder.DataSources.Generators
{
    public class RandomGenerator : IGenerator
    {
        private readonly Random _random;
        public int StartIndex { get; private set; }
        public int ListSize { get; private set; }

        public RandomGenerator(int startIndex, int listSize)
        {
            Guard.Against(startIndex >= listSize, "startIndex must be less than listSize");

            StartIndex = startIndex;
            ListSize = listSize;
            _random = new Random();
        }

        public int Generate()
        {
            return _random.Next(StartIndex, ListSize-1);
        }
    }
}