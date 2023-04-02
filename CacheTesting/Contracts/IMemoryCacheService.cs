using CacheTesting.Models;

namespace CacheTesting.Contracts;

public interface IMemoryCacheService
{
    Task<Entity> GetEntityAsync(int id);
}
