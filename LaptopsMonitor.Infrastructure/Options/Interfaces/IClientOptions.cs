namespace LaptopsMonitor.Infrastructure.Options.Interfaces;

public interface IClientOptions<in TIn>
{
    string BuildRoute(TIn @in);
}