using System.Xml;

namespace LaptopsMonitor.Domain.Interfaces;

public interface IXmlParser<T>
{
    IEnumerable<T> Parse(XmlDocument xml);
}
