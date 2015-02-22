using Castle.DynamicProxy;

namespace NTestDataBuilder.Lists
{
    internal static class ListBuilderGenerator
    {
        static ListBuilderGenerator()
        {
            Generator = new ProxyGenerator(true);
        }

        public static ProxyGenerator Generator { get; private set; } 
    }
}