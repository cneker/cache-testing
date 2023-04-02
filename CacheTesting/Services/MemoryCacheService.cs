using CacheTesting.Contracts;
using CacheTesting.Models;
using Microsoft.Extensions.Caching.Memory;

namespace CacheTesting.Services;

public class MemoryCacheService : IMemoryCacheService
{
    private readonly IEntityRepository _entityRepository;
    private readonly IMemoryCache _memoryCache;

    public MemoryCacheService(IEntityRepository entityRepository, IMemoryCache memoryCache)
    {
        this._entityRepository = entityRepository;
        _memoryCache = memoryCache;
    }

    public async Task<Entity> GetEntityAsync(int id)
    {
        _memoryCache.TryGetValue(id, out Entity? entity);

        if(entity == null)
        {
            entity = await _entityRepository.GetEntityAsync(id);
            _memoryCache.Set(id, entity);

            await Console.Out.WriteLineAsync($"{entity.Name} retrived from the database");
        }
        else
            await Console.Out.WriteLineAsync($"{entity.Name} retrived from memory cache");

        return entity;
    }
}
