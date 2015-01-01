using System;
using Castle.DynamicProxy;

namespace NTestDataBuilder.Lists
{
    internal class ListBuilderInterceptor<TObject, TBuilder> : IInterceptor
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
}