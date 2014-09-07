namespace NTestDataBuilder
{
    /// <summary>
    /// Inheritors can supply an anonymous value.
    /// </summary>
    public interface IAnonymousValueSupplier
    {
        /// <summary>
        /// Returns whether or not this supplier can supply an anonymous value for the given property.
        /// </summary>
        /// <typeparam name="TObject">The type that the property is enclosed in</typeparam>
        /// <typeparam name="TValue">The type of the target property - the anonymous value will need to be of this type</typeparam>
        /// <param name="propertyName">The name of the property to generate a value for</param>
        /// <returns>Whether or not this supplier can supply an anonymous value</returns>
        bool CanSupplyValue<TObject, TValue>(string propertyName);

        /// <summary>
        /// Return an anonymous value for the given property and fixture.
        /// </summary>
        /// <typeparam name="TObject">The type that the property is enclosed in</typeparam>
        /// <typeparam name="TValue">The type of the target property - the required anonymous value is of this type</typeparam>
        /// <param name="any">Anonymous value fixture</param>
        /// <param name="propertyName">The name of the property to return an anonymous value for</param>
        /// <returns>The anonymous value</returns>
        TValue GenerateAnonymousValue<TObject, TValue>(AnonymousValueFixture any, string propertyName);
    }
}
