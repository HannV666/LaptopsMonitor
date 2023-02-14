using LaptopsMonitor.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LaptopsMonitor.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly IXmlProvider<int> _xmlProvider;

    public TestController(IXmlProvider<int> xmlProvider)
    {
        _xmlProvider = xmlProvider;
    }

    [HttpGet("test")]
    public async Task Do()
    {
        await _xmlProvider.GetAsync(1);
    }
}
