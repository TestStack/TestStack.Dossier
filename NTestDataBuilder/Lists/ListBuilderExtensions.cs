using System;
using System.Collections.Generic;

namespace NTestDataBuilder.Lists
{
    /// <summary>
    /// Extension methods to allow chaining list builder calls onto builder instances.
    /// These extension methods make use of the proxy builder that is returned when you call .CreateListOfSize(x).
    /// </summary>
    public static class ListBuilderExtensions
    {
        /// <summary>
        /// Will target the first x objects (as specified) for subsequent builder calls (or .With call).
        /// You can combine this with .TheNext(y) to target the next y after the first x.
        /// </summary>
        /// <typeparam name="TObject">The type of object being generated</typeparam>
        /// <typeparam name="TBuilder">The type of builder that is building the objects</typeparam>
        /// <param name="builder">The builder proxy to chain</param>
        /// <param name="howMany">The first {howMany} objects should be targeted?</param>
        /// <returns>The builder proxy so that calls can continue to be chained</returns>
        public static TBuilder TheFirst<TObject, TBuilder>(this TestDataBuilder<TObject, TBuilder> builder, int howMany)
            where TObject : class
            where TBuilder : TestDataBuilder<TObject, TBuilder>, new()
        {
            return builder.ListBuilder.TheFirst(howMany);
        }

        /// <summary>
        /// Will target the next x objects (as specified) for subsequent builder calls (or .With call).
        /// </summary>
        /// <typeparam name="TObject">The type of object being generated</typeparam>
        /// <typeparam name="TBuilder">The type of builder that is building the objects</typeparam>
        /// <param name="builder">The builder proxy to chain</param>
        /// <param name="howMany">The next {howMany} objects should be targeted?</param>
        /// <returns>The builder proxy so that calls can continue to be chained</returns>
        public static TBuilder TheNext<TObject, TBuilder>(this TestDataBuilder<TObject, TBuilder> builder, int howMany)
            where TObject : class
            where TBuilder : TestDataBuilder<TObject, TBuilder>, new()
        {
            return builder.ListBuilder.TheNext(howMany);
        }

        /// <summary>
        /// Will target the last x objects (as specified) for subsequent builder calls (or .With call).
        /// You can combine this with .ThePrevious(y) to target the previous y after the last x.
        /// </summary>
        /// <typeparam name="TObject">The type of object being generated</typeparam>
        /// <typeparam name="TBuilder">The type of builder that is building the objects</typeparam>
        /// <param name="builder">The builder proxy to chain</param>
        /// <param name="howMany">The last {howMany} objects should be targeted?</param>
        /// <returns>The builder proxy so that calls can continue to be chained</returns>
        public static TBuilder TheLast<TObject, TBuilder>(this TestDataBuilder<TObject, TBuilder> builder, int howMany)
            where TObject : class
            where TBuilder : TestDataBuilder<TObject, TBuilder>, new()
        {
            return builder.ListBuilder.TheLast(howMany);
        }

        /// <summary>
        /// Will target the previous x objects (as specified) for subsequent builder calls (or .With call).
        /// </summary>
        /// <typeparam name="TObject">The type of object being generated</typeparam>
        /// <typeparam name="TBuilder">The type of builder that is building the objects</typeparam>
        /// <param name="builder">The builder proxy to chain</param>
        /// <param name="howMany">The previous {howMany} objects should be targeted?</param>
        /// <returns>The builder proxy so that calls can continue to be chained</returns>
        public static TBuilder ThePrevious<TObject, TBuilder>(this TestDataBuilder<TObject, TBuilder> builder, int howMany)
            where TObject : class
            where TBuilder : TestDataBuilder<TObject, TBuilder>, new()
        {
            return builder.ListBuilder.ThePrevious(howMany);
        }

        /// <summary>
        /// Will target all objects for subsequent builder calls (or .With call).
        /// </summary>
        /// <typeparam name="TObject">The type of object being generated</typeparam>
        /// <typeparam name="TBuilder">The type of builder that is building the objects</typeparam>
        /// <param name="builder">The builder proxy to chain</param>
        /// <returns>The builder proxy so that calls can continue to be chained</returns>
        public static TBuilder All<TObject, TBuilder>(this TestDataBuilder<TObject, TBuilder> builder)
            where TObject : class
            where TBuilder : TestDataBuilder<TObject, TBuilder>, new()
        {
            return builder.ListBuilder.All();
        }

        /// <summary>
        /// Will apply the given lambda expression to all builders that are currently targeted (e.g. via .TheFirst, .TheNext, etc. calls).
        /// </summary>
        /// <typeparam name="TObject">The type of object being generated</typeparam>
        /// <typeparam name="TBuilder">The type of builder that is building the objects</typeparam>
        /// <param name="builder">The builder proxy to chain</param>
        /// <param name="modifier">The lambda expression to apply to the targeted builders</param>
        /// <returns>The builder proxy so that calls can continue to be chained</returns>
        public static ListBuilder<TObject, TBuilder> With<TObject, TBuilder>(this TestDataBuilder<TObject, TBuilder> builder, Func<TBuilder, TBuilder> modifier)
            where TObject : class
            where TBuilder : TestDataBuilder<TObject, TBuilder>, new()
        {
            return builder.ListBuilder.With(modifier);
        }

        /// <summary>
        /// Builds the list of objects by processing all of the builder calls and then calling .Build on all the builders.
        /// </summary>
        /// <typeparam name="TObject">The type of object being generated</typeparam>
        /// <typeparam name="TBuilder">The type of builder that is building the objects</typeparam>
        /// <param name="builder">The builder proxy to build</param>
        /// <returns>The list of generated objects</returns>
        public static IList<TObject> BuildList<TObject, TBuilder>(this TestDataBuilder<TObject, TBuilder> builder)
            where TObject : class
            where TBuilder : TestDataBuilder<TObject, TBuilder>, new()
        {
            return builder.ListBuilder.BuildList();
        }
    }
}