using CacheTesting.Contracts;
using CacheTesting.Models;
using Microsoft.EntityFrameworkCore;

namespace CacheTesting.Repositories;

public class EntityRepository : RepositoryBase<Entity>, IEntityRepository
{
    public EntityRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Entity> GetEntityAsync(int id) =>
        await GetByCondition(e => e.Id.Equals(id)).SingleAsync();
}
