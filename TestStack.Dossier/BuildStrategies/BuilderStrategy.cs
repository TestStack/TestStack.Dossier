using System;
using System.Collections.Generic;
using System.Linq;

namespace TestStack.Dossier.BuildStrategies
{
    /// <summary>
    /// A static registry of object builder factories.
    /// </summary>
    public static class BuilderStrategy
    {
        private static List<Tuple<Type, IBuildStrategy>> _factories = new List<Tuple<Type, IBuildStrategy>>
        {
            new Tuple<Type, IBuildStrategy>(typeof(AllProperties), new AllProperties()),
            new Tuple<Type, IBuildStrategy>(typeof(PublicProperties), new PublicProperties()),
            new Tuple<Type, IBuildStrategy>(typeof(UseConstructor), new UseConstructor()),
            new Tuple<Type, IBuildStrategy>(typeof(AutoFixture), new AutoFixture())
        };  

        /// <summary>
        /// Provides access to specified factory.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>The requested Factory</returns>
        public static IBuildStrategy Apply<T>() where T : IBuildStrategy
        {
            return _factories.Where(x => x.Item1 == typeof (T))
                .Select(x => x.Item2)
                .First();
        }
    }
}