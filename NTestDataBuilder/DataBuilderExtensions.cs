using System.Collections.Generic;
using System.Linq;
using FizzWare.NBuilder;

namespace NTestDataBuilder
{
    /// <summary>
    /// Extension methods against the <see cref="DataBuilder{TObject,TBuilder}"/> class.
    /// </summary>
    public static class DataBuilderExtensions
    {
        /// <summary>
        /// Builds a list of entities given an NBuilder list expression of data builders.
        /// </summary>
        /// <typeparam name="TBuilder">The type of the builder being built using NBuilder</typeparam>
        /// <typeparam name="TObject">The type of object being generated</typeparam>
        /// <param name="builderList">The NBuilder list of builders</param>
        /// <returns>The built list of objects</returns>
        public static IList<TObject> BuildList<TObject, TBuilder>(this IOperable<TBuilder> builderList)
            where TBuilder : IDataBuilder<TObject>
            where TObject : class
        {
            return builderList.Build().Select(b => b.Build()).ToList();
        }

        /// <summary>
        /// Builds a list of entities given an NBuilder list expression of data builders.
        /// </summary>
        /// <typeparam name="TBuilder">The type of the builder being built using NBuilder</typeparam>
        /// <typeparam name="TObject">The type of object being generated</typeparam>
        /// <param name="builderList">The NBuilder list of builders</param>
        /// <returns>The built list of objects</returns>
        public static IList<TObject> BuildList<TObject, TBuilder>(this IListBuilder<TBuilder> builderList)
            where TBuilder : IDataBuilder<TObject>
            where TObject : class
        {
            return builderList.All().BuildList<TObject, TBuilder>();
        }
    }
}
