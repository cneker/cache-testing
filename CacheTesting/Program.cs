using CacheTesting.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.ConfigureSqlDbConnection(builder.Configuration);
builder.Services.ConfigureServices();

builder.Services.ConfigureMemoryCache();
builder.Services.ConfigureRedisCache(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
