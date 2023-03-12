using LaptopsMonitor.Dashboard.Application.DataClients.Laptops;
using LaptopsMonitor.Domain.Interfaces;
using Microsoft.AspNetCore.Components;

namespace LaptopsMonitor.Dashboard.Application.ViewModels;

public class DashboardViewModel : ComponentBase
{
    [Inject]
    public IDataClient<LaptopParam, LaptopViewModel> DataClient { get; set; }
    
    [Parameter]
    public int Page { get; set; }
    
    public IEnumerable<LaptopViewModel>? Laptops { get; private set; } = Enumerable.Empty<LaptopViewModel>();

    protected override async Task OnInitializedAsync()
    { 
        await base.OnInitializedAsync();

        var result = await DataClient.GetAsync(new LaptopParam
        {
            Page = Page,
            PageSize = 30
        });

        if (!result.IsSuccessful)
        {
            
        }

        Laptops = result.Data;
    }
}