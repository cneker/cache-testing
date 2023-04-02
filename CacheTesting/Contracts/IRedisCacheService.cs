using CacheTesting.Models;

namespace CacheTesting.Contracts;

public interface IRedisCacheService
{
    Task<Entity> GetEntityAsync(int id);
}
