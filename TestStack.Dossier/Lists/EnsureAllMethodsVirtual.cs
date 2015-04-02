using System;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;

namespace TestStack.Dossier.Lists
{
    internal class EnsureAllMethodsVirtual : IProxyGenerationHook
    {
        public void MethodsInspected()
        {
        }

        public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
        {
            if (new[]{"get_Any", "set_Any", "Build", "AsProxy", "Get", "GetOrDefault", "Set", "Has", "get_ListBuilder", "set_ListBuilder"}.Contains(memberInfo.Name))
                return;
            throw new InvalidOperationException(string.Format("Tried to build a list with a builder who has non-virtual method. Please make {0} on type {1} virtual.", memberInfo.Name, type.Name));
        }

        public bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
        {
            return true;
        }
    }
}