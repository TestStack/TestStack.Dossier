using System;

namespace TestStack.Dossier
{
    /// <summary>
    /// Inheritors can supply an anonymous value.
    /// </summary>
    public interface IAnonymousValueSupplier
    {
        /// <summary>
        /// Returns whether or not this supplier can supply an anonymous value for the given property.
        /// </summary>
        /// <param name="type">The type of the property to generate a value for</param>
        /// <param name="propertyName">The name of the property to generate a value for</param>
        /// <returns>Whether or not this supplier can supply an anonymous value</returns>
        bool CanSupplyValue(Type type, string propertyName);

        /// <summary>
        /// Return an anonymous value for the given property and fixture.
        /// </summary>
        /// <param name="type">The type that the property is enclosed in</param>
        /// <param name="any">Anonymous value fixture</param>
        /// <param name="propertyName">The name of the property to return an anonymous value for</param>
        /// <returns>The anonymous value</returns>
        object GenerateAnonymousValue(AnonymousValueFixture any, Type type, string propertyName);
    }
}
