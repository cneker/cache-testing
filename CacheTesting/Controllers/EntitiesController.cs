using CacheTesting.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CacheTesting.Controllers;

[ApiController]
[Route("api/entities")]
public class EntitiesController : ControllerBase
{
    private readonly IMemoryCacheService _memoryCacheService;
    private readonly IRedisCacheService _redisCacheService;

    public EntitiesController(IMemoryCacheService memoryCacheService,
        IRedisCacheService redisCacheService)
    {
        _memoryCacheService = memoryCacheService;
        _redisCacheService = redisCacheService;
    }

    [HttpGet("Memory")]
    public async Task<IActionResult> GetMemoryEntity(int id)
    {
        var entity = await _memoryCacheService.GetEntityAsync(id);

        return Ok(entity);
    }

    [HttpGet("Redis")]
    public async Task<IActionResult> GetRedisEntity(int id)
    {
        var entity = await _redisCacheService.GetEntityAsync(id);

        return Ok(entity);
    }
}
