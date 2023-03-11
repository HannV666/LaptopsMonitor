using LaptopsMonitor.Application.DataClients.Laptops;
using LaptopsMonitor.Application.Entities;
using LaptopsMonitor.Domain.Interfaces;
using LaptopsMonitor.Shared.Results.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LaptopsMonitor.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly IDataClient<LaptopsParam, Laptop> _dataClient;

    public TestController(IDataClient<LaptopsParam, Laptop> dataClient)
    {
        _dataClient = dataClient;
    }

    [HttpGet]
    public async Task<IEnumerableResult<Laptop>> Do()
    {
        return await _dataClient.GetAsync(new LaptopsParam
        {
            Page = 1
        });
    }
}