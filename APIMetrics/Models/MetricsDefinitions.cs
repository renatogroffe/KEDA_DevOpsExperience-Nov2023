using System.Runtime.InteropServices;

namespace APIMetrics.Models;

public class MetricsDefinitions
{
    public string InitializationTime => $"{DateTime.UtcNow.AddHours(-3):HH:mm:ss}";
    public Counter Counter { get; init; } = new();
    public string Local => Environment.MachineName;
    public string Kernel => Environment.OSVersion.VersionString;
    public string Framework => RuntimeInformation.FrameworkDescription;
}

public class Counter
{
    public int TargetValue { get; set; } = 1;
    public DateTime LastUpdate { get; set; } = DateTime.UtcNow.AddHours(-3);
}