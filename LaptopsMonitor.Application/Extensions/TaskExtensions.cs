namespace LaptopsMonitor.Application.Extensions;

public static class TaskExtensions
{
    public static async Task<bool> WaitAsync(TimeSpan span, CancellationToken cancellationToken)
    {
        await Task.Delay(span, cancellationToken)
            .ConfigureAwait(false);

        return true;
    }
}