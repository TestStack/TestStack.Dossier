using System;
using System.Collections.Generic;
using TestStack.Dossier.DataSources.Generators;

namespace TestStack.Dossier.DataSources.Picking
{
    /// <summary>
    /// Implements the repeatable sequence strategy
    /// </summary>
    public class RepeatingSequenceSource<T> : DataSource<T>
    {
        /// <inheritdoc />
        public RepeatingSequenceSource(IList<T> list)
            : base(new SequentialGenerator())
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