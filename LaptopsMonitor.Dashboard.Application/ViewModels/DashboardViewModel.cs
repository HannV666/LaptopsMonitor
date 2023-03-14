using System.Text.Json;
using LaptopsMonitor.Dashboard.Application.DataClients.Laptops;
using LaptopsMonitor.Domain.Interfaces;
using LaptopsMonitor.Shared.Results.Primitives;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace LaptopsMonitor.Dashboard.Application.ViewModels;

public class DashboardViewModel : ComponentBase
{
    public int TotalPages { get; set; }
    
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    
    [Inject]
    public IDataClient<LaptopParam, LaptopViewModel> DataClient { get; set; }
    
    [Inject]
    public ILogger<DashboardViewModel> Logger { get; set; }

    public int Page { get; set; } = 1;
    
    public string? Filter { get; set; }
    
    public List<LaptopViewModel> Laptops { get; private set; } 
        = new();
    
    public string? Message { get; set; }

    public async Task MoveNext()
    {
        if (Page >= TotalPages)
        {
            return;
        }
        
        Page++;
        await FetchAsync();
        
        StateHasChanged();
    }
    
    public async Task MovePrev()
    {
        if (Page <= 1)
        {
            return;
        }
        
        Page--;
        await FetchAsync();
        
        StateHasChanged();
    }

    private async Task FetchAsync()
    {
        Message = string.Empty;
        Laptops.Clear();
        Page = Page == 0 ? 1 : Page;

        var param = new LaptopParam
        {
            Page = Page,
            PageSize = 30,
            Filter = Filter
        };
        
        Logger.LogInformation("Params: {Params}", JsonSerializer.Serialize(param));
        
        var result = await DataClient.GetAsync(param) as PagedResult<LaptopViewModel> ??
                     new PagedResult<LaptopViewModel>();

        Message = result.Message;
        Laptops.AddRange(result.Data ?? new List<LaptopViewModel>());
        TotalPages = result.TotalPages;
    }

    protected override async Task OnInitializedAsync()
    { 
        await FetchAsync();
    }

    public async void OnFilterChanged(ChangeEventArgs args)
    {
        Filter = args.Value as string;
        Page = 1;

        await FetchAsync();
        
        StateHasChanged();
    }
}