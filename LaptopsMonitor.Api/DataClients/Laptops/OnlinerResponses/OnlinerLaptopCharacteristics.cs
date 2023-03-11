using LaptopsMonitor.Shared.Entities.Interfaces;

namespace LaptopsMonitor.DataClients.Laptops.OnlinerResponses;

public class OnlinerLaptopCharacteristics : ILaptopCharacteristics
{
    private string[]? _characteristics;

    private string[] Characteristics
    {
        get
        {
            _characteristics ??= Description.Split(',');
            return _characteristics;
        }
    }
    
    public string Description { get; init; } = string.Empty;

    public string Resolution => SafeGet(0);

    public string DisplayMatrix => SafeGet(1);
    
    public string DisplayRefreshRate => SafeGet(2);
    
    public string Cpu => SafeGet(3);
    
    public string Ram => SafeGet(4);
    
    public string Dd => SafeGet(5);
    
    public string Gpu => SafeGet(6);
    
    public string Color => SafeGet(7);

    private string SafeGet(int index)
    {
        return index >= Characteristics.Length
            ? string.Empty
            : Characteristics[index];
    }
}