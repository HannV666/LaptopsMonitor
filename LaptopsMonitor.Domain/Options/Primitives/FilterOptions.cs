using System.Linq.Expressions;

namespace LaptopsMonitor.Domain.Options.Primitives;

public class FilterOptions<T>
{
    public required string Filter { get; init; }
    
    public required Expression<Func<T, bool>> FilterExpression { get; init; }
}