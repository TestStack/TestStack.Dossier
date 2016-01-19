using System.Collections.Generic;
using TestStack.Dossier.DataSources.Generators;

namespace TestStack.Dossier.Picking
{
    /// <summary>
    /// Implements the repeatable sequence strategy
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="ItemPicker{T}" />
    public class RepeatingSequenceItemPicker<T> : ItemPicker<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepeatingSequenceItemPicker{T}"/> class.
        /// </summary>
        /// <param name="list">The list.</param>
        public RepeatingSequenceItemPicker(IList<T> list)
            : base(list, new SequentialGenerator()) { }
    }
}