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
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="builderList"></param>
        /// <returns></returns>
        public static IList<TEntity> BuildDataList<TEntity, TBuilder>(this IOperable<TBuilder> builderList)
            where TBuilder : IDataBuilder<TEntity>
            where TEntity : class
        {
            return builderList.Build().Select(b => b.Build()).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TBuilder"></typeparam>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="builderList"></param>
        /// <returns></returns>
        public static IList<TEntity> BuildDataList<TEntity, TBuilder>(this IListBuilder<TBuilder> builderList)
            where TBuilder : IDataBuilder<TEntity>
            where TEntity : class
        {
            return builderList.All().BuildDataList<TEntity, TBuilder>();
        }
    }
}
