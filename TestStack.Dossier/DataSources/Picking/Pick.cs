using System.Collections.Generic;

namespace TestStack.Dossier.DataSources.Picking
{
    /// <summary>
    /// Pick a sequence of items from a collection of items according to different selection strategies.
    /// </summary>
    public class Pick
    {
        /// <summary>
        /// Selects a random item from the list each time it is called.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <returns>The RandomItemSource class.</returns>
        public static RandomItemSource<T> RandomItemFrom<T>(IList<T> list)
        {
            return new RandomItemSource<T>(list);
        }

        /// <summary>
        /// Selects each item sequentially from the list and starts again from the beginning when the list is exhausted.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public static RepeatingSequenceSource<T> RepeatingSequenceFrom<T>(IList<T> list)
        {
            return new RepeatingSequenceSource<T>(list);
        }
    }
}