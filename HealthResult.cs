public class HealthResult
{
    public string Name { get; internal set; }
    public string Status { get; internal set; }
    public TimeSpan Duration { get; internal set; }
    public ICollection<HealthInfo> Info { get; internal set; }
}
