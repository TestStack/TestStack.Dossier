using System;

namespace NTestDataBuilder.DataSources.Generators
{
    public class SequentialGenerator : IGenerator
    {
        private int _currentListIndex;
        public int StartIndex { get; set; }
        public int ListSize { get; set; }
        public bool ListShouldBeUnique { get; private set; }

        public SequentialGenerator() : this(0,1)
        {
        }

        public SequentialGenerator(int startIndex, int listSize, bool listShouldBeUnique = false)
        {
            Guard.Against(startIndex < 0, "startIndex must be zero or more");
            Guard.Against(listSize < 1, "listSize must be greater than zero");
            Guard.Against(startIndex >= listSize, "startIndex must be less than listSize");

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