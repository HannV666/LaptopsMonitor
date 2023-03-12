using System.Text.Json;
using LaptopsMonitor.Dashboard.Application.DataClients.Laptops;
using LaptopsMonitor.Domain.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace LaptopsMonitor.Dashboard.Application.ViewModels;

public class DashboardViewModel : ComponentBase
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    
    [Inject]
    public IDataClient<LaptopParam, LaptopViewModel> DataClient { get; set; }
    
    [Inject]
    public ILogger<DashboardViewModel> Logger { get; set; }
    
    [Parameter]
    public int Page { get; set; }
    
    [Parameter]
    public string? Filter { get; set; }
    
    public IEnumerable<LaptopViewModel>? Laptops { get; private set; } 
        = Enumerable.Empty<LaptopViewModel>();
    
    public string? Message { get; set; }

    public async Task FilterAsync()
    {
        NavigationManager.NavigateTo($"dashboard/{++Page}?filter={Filter}");
        await FetchAsync();
    }

    public async Task MoveNext()
    {
        NavigationManager.NavigateTo($"dashboard/{++Page}");
        await FetchAsync();
    }
    
    public async Task MovePrev()
    {
        NavigationManager.NavigateTo($"dashboard/{--Page}");
        await FetchAsync();
    }

    private async Task FetchAsync()
    {
        Message = string.Empty;

        var param = new LaptopParam
        {
            Page = Page,
            PageSize = 30,
            Filter = Filter
        };
        
        Logger.LogInformation("Params: {Params}", JsonSerializer.Serialize(param));
        
        var result = await DataClient.GetAsync(param);

        if (!result.IsSuccessful)
        {
            Message = result.Message;
        }

        Laptops = result.Data;
    }

    protected override async Task OnInitializedAsync()
    { 
        await base.OnInitializedAsync();

        await FetchAsync();
    }
}