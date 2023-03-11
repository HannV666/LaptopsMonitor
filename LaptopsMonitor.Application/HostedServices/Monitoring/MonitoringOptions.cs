namespace LaptopsMonitor.Application.HostedServices.Monitoring;

public class MonitoringOptions
{
    public int DaysDelay { get; init; } = default;
    
    public int HoursDelay { get; init; } = default;
    
    public int MinutesDelay { get; init; } = default;
    
    public int PagesToRead { get; init; } = default;
    
    public TimeSpan ToTimeSpan() => TimeSpan.Zero
        .Add(TimeSpan.FromDays(DaysDelay))
        .Add(TimeSpan.FromHours(HoursDelay))
        .Add(TimeSpan.FromMinutes(MinutesDelay));
}