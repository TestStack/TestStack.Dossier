using System;

namespace NTestDataBuilder.DataSources.Generators
{
    public class RandomGenerator : IGenerator
    {
        private readonly Random _random;
        private readonly int _minValue;
        private readonly int _maxValue;

        public RandomGenerator(int minValue, int maxValue)
        {
            if (minValue >= maxValue)
            {
                throw new ArgumentException("minValue must be less than maxValue");
            }
            _minValue = minValue;
            _maxValue = maxValue;
            _random = new Random();
        }

        public int Generate()
        {
            return _random.Next(_minValue, _maxValue);
        }
    }
}