using System;
using System.Collections.Generic;
using System.Linq;
using Castle.DynamicProxy;

namespace TestStack.Dossier.Lists
{
    /// <summary>
    /// Class that builds lists of objects by proxying a list of object builders.
    /// </summary>
    /// <typeparam name="TObject">The type of object being built</typeparam>
    /// <typeparam name="TBuilder">The type of builder that is building the object</typeparam>
    public class ListBuilder<TObject, TBuilder>
        where TBuilder : TestDataBuilder<TObject, TBuilder>, new()
        where TObject : class
    {
        private int _start = 0;
        private int _count = 0;
        private readonly List<TBuilder> _list;

        internal ListBuilder(int size)
        {
            BuilderProxy = (TBuilder) ListBuilderGenerator.Generator
                .CreateClassProxy(typeof (TBuilder), new ProxyGenerationOptions(new EnsureAllMethodsVirtual()), new ListBuilderInterceptor<TObject, TBuilder>(this));
            BuilderProxy.ListBuilder = this;
            _list = new List<TBuilder>();
            var fixture = new AnonymousValueFixture();
            for (var i = 0; i < size; i++)
                _list.Add(new TBuilder {Any = fixture});
        }

        internal TBuilder BuilderProxy { get; private set; }

        /// <summary>
        /// Will target the first x objects (as specified) for subsequent builder calls (or .With call).
        /// You can combine this with .TheNext(y) to target the next y after the first x.
        /// </summary>
        /// <param name="howMany">The first {howMany} objects should be targeted?</param>
        /// <returns>The builder proxy so that calls can continue to be chained</returns>
        public TBuilder TheFirst(int howMany)
        {
            _start = 0;
            _count = howMany;
            return BuilderProxy;
        }

        /// <summary>
        /// Will target the next x objects (as specified) for subsequent builder calls (or .With call).
        /// </summary>
        /// <param name="howMany">The next {howMany} objects should be targeted?</param>
        /// <returns>The builder proxy so that calls can continue to be chained</returns>
        public TBuilder TheNext(int howMany)
        {
            _start += _count;
            _count = howMany;
            return BuilderProxy;
        }

        /// <summary>
        /// Will target the last x objects (as specified) for subsequent builder calls (or .With call).
        /// You can combine this with .ThePrevious(y) to target the previous y after the last x.
        /// </summary>
        /// <param name="howMany">The last {howMany} objects should be targeted?</param>
        /// <returns>The builder proxy so that calls can continue to be chained</returns>
        public TBuilder TheLast(int howMany)
        {
            _start = _list.Count - howMany;
            _count = howMany;
            return BuilderProxy;
        }

        /// <summary>
        /// Will target the previous x objects (as specified) for subsequent builder calls (or .With call).
        /// </summary>
        /// <param name="howMany">The previous {howMany} objects should be targeted?</param>
        /// <returns>The builder proxy so that calls can continue to be chained</returns>
        public TBuilder ThePrevious(int howMany)
        {
            _start -= howMany;
            _count = howMany;
            return BuilderProxy;
        }

        /// <summary>
        /// Will target all objects for subsequent builder calls (or .With call).
        /// </summary>
        /// <returns>The builder proxy so that calls can continue to be chained</returns>
        public TBuilder All()
        {
            _start = 0;
            _count = _list.Count;
            return BuilderProxy;
        }

        /// <summary>
        /// Will apply the given lambda expression to all builders that are currently targeted (e.g. via .TheFirst, .TheNext, etc. calls).
        /// </summary>
        /// <param name="modifier">The lambda expression to apply to the targeted builders</param>
        /// <returns>The builder proxy so that calls can continue to be chained</returns>
        public ListBuilder<TObject, TBuilder> With(Func<TBuilder, TBuilder> modifier)
        {
            _list.Skip(_start)
                .Take(_count)
                .ToList()
                .ForEach(b => modifier(b));
            return this;
        }

        /// <summary>
        /// Builds the list of objects by processing all of the builder calls and then calling .Build on all the builders.
        /// </summary>
        /// <returns>The list of generated objects</returns>
        public IList<TObject> BuildList()
        {
            return _list.Select(b => b.Build()).ToArray();
        }

        internal void Execute(IInvocation invocation)
        {
            _list.Skip(_start)
                .Take(_count)
                .ToList()
                .ForEach(b => invocation.Method.Invoke(b, invocation.Arguments));
        }
    }
}
