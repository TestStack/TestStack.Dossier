using System.Collections.Generic;
using System.Linq;
using FizzWare.NBuilder;

namespace NTestDataBuilder
{
    /// <summary>
    /// Extension methods against the <see cref="DataBuilder{TEntity,TBuilder}"/> class.
    /// </summary>
    public static class DataBuilderExtensions
    {
        /// <summary>
        /// Builds a list of entities given an NBuilder list expression of data builders.
        /// </summary>
        /// <typeparam name="TBuilder">The type of the builder being built using NBuilder</typeparam>
        /// <typeparam name="TEntity">The type of object being generated</typeparam>
        /// <param name="builderList">The NBuilder list of builders</param>
        /// <returns>The built list of objects</returns>
        public static IList<TEntity> BuildDataList<TEntity, TBuilder>(this IOperable<TBuilder> builderList)
            where TBuilder : IDataBuilder<TEntity>
            where TEntity : class
        {
            return builderList.Build().Select(b => b.Build()).ToList();
        }

        /// <summary>
        /// Builds a list of entities given an NBuilder list expression of data builders.
        /// </summary>
        /// <typeparam name="TBuilder">The type of the builder being built using NBuilder</typeparam>
        /// <typeparam name="TEntity">The type of object being generated</typeparam>
        /// <param name="builderList">The NBuilder list of builders</param>
        /// <returns>The built list of objects</returns>
        public static IList<TEntity> BuildDataList<TEntity, TBuilder>(this IListBuilder<TBuilder> builderList)
            where TBuilder : IDataBuilder<TEntity>
            where TEntity : class
        {
            return builderList.All().BuildDataList<TEntity, TBuilder>();
        }
    }
}
