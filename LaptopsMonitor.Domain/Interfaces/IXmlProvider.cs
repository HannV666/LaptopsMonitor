using LaptopsMonitor.Shared.Domain.Results;
using System.Xml;

namespace LaptopsMonitor.Domain.Interfaces;

public interface IXmlProvider<TParam>
{
    Task<XmlResult> GetAsync(TParam param, CancellationToken cancellationToken = default);
}
