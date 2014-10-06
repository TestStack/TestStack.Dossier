using System;

namespace NTestDataBuilder.DataSources.Generators
{
    /// <summary>
    /// A strategy that randomly selects an index from the collection
    /// </summary>
    public class RandomGenerator : IGenerator
    {
        private readonly Random _random;
        public int StartIndex { get; set; }
        public int ListSize { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public RandomGenerator() 
            : this(0,1) { }

        /// <summary>
        /// Specify the startIndex and listSize
        /// </summary>
        /// <param name="startIndex">The first index that can be selected in a list. Ranges from 0 to one less than the number of items in the list</param>
        /// <param name="listSize">The number of items in the list</param>
        public RandomGenerator(int startIndex, int listSize)
        {
            if(startIndex < 0) throw new ArgumentException("startIndex must be zero or more");
            if(listSize < 1) throw new ArgumentException("listSize must be greater than zero");
            if(startIndex >= listSize) throw new ArgumentException("startIndex must be less than listSize");

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