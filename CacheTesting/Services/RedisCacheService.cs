using CacheTesting.Contracts;
using CacheTesting.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace CacheTesting.Services
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IEntityRepository _entityRepository;
        private readonly IDistributedCache _distributedCache;

        public RedisCacheService(IEntityRepository entityRepository, IDistributedCache distributedCache)
        {
            _entityRepository = entityRepository;
            _distributedCache = distributedCache;
        }

        public async Task<Entity> GetEntityAsync(int id)
        {
            var entityString = (await _distributedCache.GetStringAsync(id.ToString())) ?? string.Empty;

            var entity = JsonConvert.DeserializeObject<Entity>(entityString);

            if(entity == null)
            {
                entity = await _entityRepository.GetEntityAsync(id);
                entityString = JsonConvert.SerializeObject(entity);

                await _distributedCache.SetStringAsync(id.ToString(), entityString);

                await Console.Out.WriteLineAsync($"{entity.Name} retrived from the database");
            }
            else
                await Console.Out.WriteLineAsync($"{entity.Name} retrived from redis");

            return entity;
        }
    }
}
