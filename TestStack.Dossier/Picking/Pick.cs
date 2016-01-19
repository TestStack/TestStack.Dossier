using System.Collections.Generic;

namespace TestStack.Dossier.Picking
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
        /// <returns>The RandomItemPicker class.</returns>
        public static RandomItemPicker<T> RandomItemFrom<T>(IList<T> list)
        {
            return new RandomItemPicker<T>(list);
        }

        /// <summary>
        /// Selects each item sequentially from the list and starts again from the beginning when the list is exhausted.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public static RepeatingSequenceItemPicker<T> RepeatingSequenceFrom<T>(IList<T> list)
        {
            return new RepeatingSequenceItemPicker<T>(list);
        }
    }
}