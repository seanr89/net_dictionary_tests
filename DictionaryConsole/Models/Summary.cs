
public record Summary{
    public int StartCount { get; set; }
    public int DictionaryCount { get; set; }
    public double MemoryAllocation { get; set; }
    //TODO: duration

    public override string ToString()
    {
        var resp = $"StartCount: {StartCount} with Dictionary size: {DictionaryCount} and memory size: {MemoryAllocation}";
        return resp;
    }
}