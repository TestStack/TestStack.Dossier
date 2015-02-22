﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NSubstitute;

namespace NTestDataBuilder
{
    /// <summary>
    /// Builds an NSubstitute proxy for the given type that has .Returns values set for the given dictionary of properties.
    /// </summary>
    /// <typeparam name="T">The type being proxied</typeparam>
    public class ProxyBuilder<T> where T : class
    {
        private readonly Dictionary<string, object> _properties;

        /// <summary>
        /// Create a proxy builder to proxy the given property values for the type {T}.
        /// </summary>
        /// <param name="properties"></param>
        public ProxyBuilder(Dictionary<string, object> properties)
        {
            _properties = properties;
        }

        /// <summary>
        /// Build the proxy object and set up the .Returns values for the properties.
        /// </summary>
        /// <returns>The proxy object</returns>
        public T Build()
        {
            var proxy = Substitute.For<T>();
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties.Where(property => _properties.ContainsKey(property.Name)))
            {
                if (property.GetGetMethod().IsVirtual)
                    property.GetValue(proxy, null).Returns(_properties[property.Name]);
            }

            return proxy;
        }
    }
}
