namespace TestStack.Dossier
{
    /// <summary>
    /// Base class definining infrastructure for a class that generates objects of type {TObject}.
    /// </summary>
    /// <typeparam name="TObject">The type of object this class generates</typeparam>
    public interface ITestDataBuilder<out TObject> where TObject : class
    {
        /// <summary>
        /// Build the object.
        /// </summary>
        /// <returns>The built object</returns>
        TObject Build();
    }
}
