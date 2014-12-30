using System;

namespace NTestDataBuilder.DataSources.Generators
{
    /// <summary>
    /// A strategy that selects each item from the collection in sequence. At the end of the collection it can optionally start from the beginning or throw an exception. By default it starts from the beginning again.
    /// </summary>
    public class SequentialGenerator : IGenerator
    {
        private int _currentListIndex;
        /// <inheritdoc />
        public int StartIndex { get; set; }
        /// <inheritdoc />
        public int ListSize { get; set; }
        /// <summary>
        /// Whether or not the list should be unique
        /// </summary>
        public bool ListShouldBeUnique { get; private set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SequentialGenerator()
            : this(0, 1) { }

        /// <summary>
        /// Specify the startIndex and listSize
        /// </summary>
        /// <param name="startIndex">The first index that can be selected in a list. Ranges from 0 to one less than the number of items in the list</param>
        /// <param name="listSize">The number of items in the list</param>
        /// <param name="listShouldBeUnique">Whether or not the generated list should be guaranteed to be unique or the range of values can be looped through infinitely</param>
        public SequentialGenerator(int startIndex, int listSize, bool listShouldBeUnique = false)
        {
            if (startIndex < 0) throw new ArgumentException("startIndex must be zero or more");
            if (listSize < 1) throw new ArgumentException("listSize must be greater than zero");
            if (startIndex >= listSize) throw new ArgumentException("startIndex must be less than listSize");

            StartIndex = startIndex;
            ListSize = listSize;
            ListShouldBeUnique = listShouldBeUnique;
            _currentListIndex = startIndex - 1;
        }

        public int Generate()
        {
            _currentListIndex++;
            CheckForEndOfList();
            return _currentListIndex;
        }

        private void CheckForEndOfList()
        {
            if (_currentListIndex < ListSize)
            {
                return;
            }

            if (ListShouldBeUnique)
            {
                throw new InvalidOperationException(
                    "There are not enough elements in the data source to continue adding items");
            }
            else
            {
                _currentListIndex = StartIndex;
            }
        }
    }
}