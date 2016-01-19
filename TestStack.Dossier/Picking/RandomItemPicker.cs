using System.Collections.Generic;
using TestStack.Dossier.DataSources.Generators;

namespace TestStack.Dossier.Picking
{
    /// <summary>
    /// Implements the random item strategy
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="ItemPicker{T}" />
    public class RandomItemPicker<T> : ItemPicker<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RandomItemPicker{T}"/> class.
        /// </summary>
        /// <param name="list">The list.</param>
        public RandomItemPicker(IList<T> list)
            : base(list, new RandomGenerator()) { }
    }
}