using CacheTesting.Contracts;
using CacheTesting.Repositories;
using CacheTesting.Services;
using Microsoft.EntityFrameworkCore;

namespace CacheTesting.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureSqlDbConnection(this IServiceCollection services, IConfiguration configuration)
    {
        var sqlConnectionString = configuration.GetConnectionString("SqlConntection");
        if(sqlConnectionString == null)
            throw new ArgumentNullException(nameof(sqlConnectionString));

        services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlServer(sqlConnectionString));
    }

    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IEntityRepository, EntityRepository>();

        services.AddScoped<IMemoryCacheService, MemoryCacheService>();
        services.AddScoped<IRedisCacheService, RedisCacheService>();
    }

   public static void ConfigureMemoryCache(this IServiceCollection services)
    {
        services.AddMemoryCache();
    }

    public static void ConfigureRedisCache(this IServiceCollection services, IConfiguration configuration)
    {
        var redisCachingSettings = configuration.GetRequiredSection("DistributedCaching")
            .GetRequiredSection("Redis");

        services.AddStackExchangeRedisCache(opt =>
        {
            opt.Configuration = redisCachingSettings.GetRequiredSection("Configuration").Value;
            opt.InstanceName = redisCachingSettings.GetRequiredSection("InstanceName").Value;
        });
    }

}
