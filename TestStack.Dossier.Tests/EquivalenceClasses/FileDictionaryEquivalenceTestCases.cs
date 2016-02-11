using System;
using System.Collections;
using System.Collections.Generic;

namespace TestStack.Dossier.Tests.EquivalenceClasses
{
    public abstract class FileDictionaryEquivalenceTestCases : IEnumerable<object[]>
    {
        protected abstract List<object[]> GetData();

        protected AnonymousValueFixture Any = new AnonymousValueFixture();

        private List<object[]> _data;
        public List<object[]> Data
        {
            get
            {
                if (_data == null)
                {
                    _data = GetData();
                }
                return _data;
            }
        }

        protected List<string> GenerateTestCasesForSut(Func<string> any)
        {
            var results = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                results.Add(any());
            }
            return results;
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}