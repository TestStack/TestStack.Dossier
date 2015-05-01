using System;
using System.Collections.Generic;
using System.Linq;

namespace TestStack.Dossier.ObjectBuilders
{
    /// <summary>
    /// A static registry of object builder factories.
    /// </summary>
    public static class ObjectBuilderRegistry
    {
        private static List<Tuple<Type, IObjectBuilder>> _factories = new List<Tuple<Type, IObjectBuilder>>
        {
            new Tuple<Type, IObjectBuilder>(typeof(AllPropertiesObjectBuilder), new AllPropertiesObjectBuilder()),
            new Tuple<Type, IObjectBuilder>(typeof(PublicPropertiesObjectBuilder), new PublicPropertiesObjectBuilder()),
            new Tuple<Type, IObjectBuilder>(typeof(ConstructorObjectBuilder), new ConstructorObjectBuilder()),
            new Tuple<Type, IObjectBuilder>(typeof(AutoFixtureObjectBuilder), new AutoFixtureObjectBuilder())
        };  

        /// <summary>
        /// Provides access to specified factory.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>The requested Factory</returns>
        public static IObjectBuilder Get<T>() where T : IObjectBuilder
        {
            return _factories.Where(x => x.Item1 == typeof (T))
                .Select(x => x.Item2)
                .First();
        }
    }
}