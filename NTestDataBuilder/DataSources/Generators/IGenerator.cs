namespace NTestDataBuilder.DataSources.Generators
{
    /// <summary>
    /// A strategy to determine the index of the next item to be selected from a list
    /// </summary>
    public interface IGenerator
    {
        /// <summary>
        /// Derives the next item to be selected in the list
        /// </summary>
        /// <returns>The index of the next item to be selected in the list</returns>
        int Generate();

        /// <summary>
        /// The first index that can be selected in a list. Ranges from 0 to one less than the number of items in the list
        /// </summary>
        int StartIndex { get; set; }

        /// <summary>
        /// The number of items in the list
        /// </summary>
        int ListSize { get; set; }
    }
}