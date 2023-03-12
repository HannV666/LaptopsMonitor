using LaptopsMonitor.Application.Entities;
using LaptopsMonitor.Domain.Interfaces;
using LaptopsMonitor.Domain.Options.Primitives;
using LaptopsMonitor.Shared.Results.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LaptopsMonitor.Api.Controllers;

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
    public async Task<IEnumerableResult<Laptop>> Do([FromRoute] int page,
        CancellationToken cancellationToken,
        [FromQuery] int pageSize = 30,
        [FromQuery] string? filter = default)
    {
        var filterOptions = string.IsNullOrEmpty(filter)
            ? default
            : new FilterOptions<Laptop>
            {
                Filter = filter,
                FilterExpression = Laptop.IsMatch(filter.Trim())
            };

        return await _repository.GetAsync(new PageOptions
        {
            Page = page,
            PageSize = pageSize
        }, filterOptions, cancellationToken);
    }
}