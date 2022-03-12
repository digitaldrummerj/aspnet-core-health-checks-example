public class HealthInfo
{
    public string Key { get; set; }
    public string Description { get; internal set; }
    public TimeSpan Duration { get; internal set; }
    public string Status { get; internal set; }
    public string Error { get; internal set; }
    public IReadOnlyDictionary<string, object> Data { get; internal set; }
}
