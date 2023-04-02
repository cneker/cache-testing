using CacheTesting.Models;

namespace CacheTesting.Contracts;

public interface IEntityRepository
{
    Task<Entity> GetEntityAsync(int id);
}
