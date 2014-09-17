namespace NTestDataBuilder.DataSources.Generators
{
    public interface IGenerator
    {
        int Generate();
        int StartIndex { get; set; }
        int ListSize { get; set; }
    }
}