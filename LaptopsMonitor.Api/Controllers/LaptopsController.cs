using LaptopsMonitor.Application.Entities;
using LaptopsMonitor.Domain.Interfaces;
using LaptopsMonitor.Domain.Options.Primitives;
using LaptopsMonitor.Shared.Results.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LaptopsMonitor.Controllers;

[ApiController]
[Route("api/laptops")]
public class LaptopsController : ControllerBase
{
    private readonly IRepository<Laptop> _repository;

    public LaptopsController(IRepository<Laptop> repository)
    {
        _repository = repository;
    }

    [HttpGet("/{page:int}")]
    public async Task<IEnumerableResult<Laptop>> Do([FromRoute] int page, [FromQuery] int pageSize = 30)
    {
        return await _repository.GetAsync(new PageOptions
        {
            Page = page,
            PageSize = pageSize
        });
    }
}