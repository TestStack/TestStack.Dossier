using System.Collections.Generic;
using TestStack.Dossier.DataSources.Generators;

namespace TestStack.Dossier.Picking
{
    /// <summary>
    /// The base class with all of the item picking functionality
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ItemPicker<T>
    {
        private readonly IList<T> _list;
        private readonly IGenerator _generator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemPicker{T}"/> class.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="generator">The generator.</param>
        protected ItemPicker(IList<T> list, IGenerator generator)
        {
            _list = list;
            _generator = generator;
            _generator.StartIndex = 0;
            _generator.ListSize = _list.Count;
        }

        /// <summary>
        /// Called to return the next item in the sequence.
        /// </summary>
        /// <returns></returns>
        public T Next()
        {
            var index = _generator.Generate();
            return _list[index];
        }
    }
}