using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;
using FizzWare.NBuilder;

namespace NTestDataBuilder.Lists
{
    public static class ListBuilderGenerator
    {
        static ListBuilderGenerator()
        {
            Generator = new ProxyGenerator(true);
        }

        public static ProxyGenerator Generator { get; private set; } 
    }

    public static class ListBuilderExtensions
    {
        public static TBuilder TheFirst<TObject, TBuilder>(this TestDataBuilder<TObject, TBuilder> b, int howMany)
            where TObject : class
            where TBuilder : TestDataBuilder<TObject, TBuilder>, new()
        {
            return b.ListBuilder.TheFirst(howMany);
        }

        public static TBuilder TheNext<TObject, TBuilder>(this TestDataBuilder<TObject, TBuilder> b, int howMany)
            where TObject : class
            where TBuilder : TestDataBuilder<TObject, TBuilder>, new()
        {
            return b.ListBuilder.TheNext(howMany);
        }

        public static TBuilder TheLast<TObject, TBuilder>(this TestDataBuilder<TObject, TBuilder> b, int howMany)
            where TObject : class
            where TBuilder : TestDataBuilder<TObject, TBuilder>, new()
        {
            return b.ListBuilder.TheLast(howMany);
        }

        public static TBuilder ThePrevious<TObject, TBuilder>(this TestDataBuilder<TObject, TBuilder> b, int howMany)
            where TObject : class
            where TBuilder : TestDataBuilder<TObject, TBuilder>, new()
        {
            return b.ListBuilder.ThePrevious(howMany);
        }

        public static TBuilder All<TObject, TBuilder>(this TestDataBuilder<TObject, TBuilder> b)
            where TObject : class
            where TBuilder : TestDataBuilder<TObject, TBuilder>, new()
        {
            return b.ListBuilder.All();
        }

        public static ListBuilder<TObject, TBuilder> With<TObject, TBuilder>(this TestDataBuilder<TObject, TBuilder> b, Func<TBuilder, TBuilder> modifier)
            where TObject : class
            where TBuilder : TestDataBuilder<TObject, TBuilder>, new()
        {
            return b.ListBuilder.With(modifier);
        }

        public static IList<TObject> BuildList<TObject, TBuilder>(this TestDataBuilder<TObject, TBuilder> b)
            where TObject : class
            where TBuilder : TestDataBuilder<TObject, TBuilder>, new()
        {
            return b.ListBuilder.BuildList();
        }
    }

    public class ListBuilderInterceptor<TObject, TBuilder> : IInterceptor
        where TBuilder : TestDataBuilder<TObject, TBuilder>, new()
        where TObject : class
    {
        private readonly ListBuilder<TObject, TBuilder> _builder;

        public ListBuilderInterceptor(ListBuilder<TObject, TBuilder> builder)
        {
            _builder = builder;
        }

        public void Intercept(IInvocation invocation)
        {
            if (invocation.Method.ReturnType != typeof (TBuilder))
            {
                throw new InvalidOperationException("Non-fluent builder method invoked while creating a list of builders: " + invocation.Method.Name);
            }

            _builder.Execute(invocation);
            invocation.ReturnValue = _builder.BuilderProxy;
        }
    }

    public class ListBuilder<TObject, TBuilder>
        where TBuilder : TestDataBuilder<TObject, TBuilder>, new()
        where TObject : class
    {
        private int _start = 0;
        private int _count = 0;
        private readonly List<TBuilder> _list;

        public ListBuilder(int size)
        {
            BuilderProxy = (TBuilder) ListBuilderGenerator.Generator
                .CreateClassProxy(typeof (TBuilder), new ProxyGenerationOptions(new EnsureAllMethodsVirtual()), new ListBuilderInterceptor<TObject, TBuilder>(this));
            BuilderProxy.ListBuilder = this;
            _list = new List<TBuilder>();
            for (var i = 0; i < size; i++)
                _list.Add(new TBuilder());
        }

        public TBuilder BuilderProxy { get; private set; }

        public TBuilder TheFirst(int howMany)
        {
            _start = 0;
            _count = howMany;
            return BuilderProxy;
        }

        public TBuilder TheNext(int howMany)
        {
            _start += _count;
            _count = howMany;
            return BuilderProxy;
        }

        public TBuilder ThePrevious(int howMany)
        {
            _start -= howMany;
            _count = howMany;
            return BuilderProxy;
        }

        public TBuilder TheLast(int howMany)
        {
            _start = _list.Count - howMany;
            _count = howMany;
            return BuilderProxy;
        }

        public TBuilder All()
        {
            _start = 0;
            _count = _list.Count;
            return BuilderProxy;
        }

        public ListBuilder<TObject, TBuilder> With(Func<TBuilder, TBuilder> modifier)
        {
            _list.Skip(_start)
                .Take(_count)
                .ToList()
                .ForEach(b => modifier(b));
            return this;
        }

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

    public class EnsureAllMethodsVirtual : IProxyGenerationHook
    {
        public void MethodsInspected()
        {
        }

        public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
        {
            if (new[]{"get_Any", "Build", "AsProxy", "Get", "GetOrDefault", "Set", "Has"}.Contains(memberInfo.Name))
                return;
            throw new InvalidOperationException(string.Format("Tried to build a list with a builder who has non-virtual method. Please make {0} on type {1} virtual.", memberInfo.Name, type.Name));
        }

        public bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
        {
            return true;
        }
    }
}
