using LaptopsMonitor.Shared.Results.Interfaces;

namespace LaptopsMonitor.Domain.Interfaces;

public interface IDataClient<in TIn, TOut> : IDisposable
{
    Task<IEnumerableResult<TOut>> GetAsync(TIn @in, CancellationToken cancellationToken = default);
}