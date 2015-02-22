using System.Collections.Generic;
using System.Dynamic;

namespace NTestDataBuilder
{
    // http://stackoverflow.com/questions/6291704/net-dynamicobject-implementation-that-returns-null-for-missing-properties-rathe
    internal class NullingExpandoObject : DynamicObject
    {
        private readonly Dictionary<string, object> _values
            = new Dictionary<string, object>();

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            // We don't care about the return value...
            _values.TryGetValue(binder.Name, out result);
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _values[binder.Name] = value;
            return true;
        }
    }
}
