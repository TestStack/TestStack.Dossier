using System;
using System.Collections.Generic;

namespace TestStack.Dossier.DataSources
{
    /// <summary>
    /// Implements the random item strategy
    /// </summary>
    public class RandomItemSource<T> : DataSource<T>
    {
        /// <inheritdoc />
        public RandomItemSource(IList<T> list)
        {
            Data = list;
            Generator.StartIndex = 0;
            Generator.ListSize = Data.Count;
        }

        /// <inheritdoc />
        protected override IList<T> InitializeDataSource()
        {
            // This method will never be called as the list is set in the constructor.
            throw new NotImplementedException();
        }
    }
}