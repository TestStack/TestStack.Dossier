using System;

namespace TestStack.Dossier
{
    public class Builder<T> : TestDataBuilder<T, Builder<T>>
        where T : class
    {
        public static Builder<T> CreateNew()
        {
            return new Builder<T>();
        } 
    }
}
