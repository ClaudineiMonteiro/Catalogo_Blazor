using Catalogo_Blazor.Server.Context;
using Microsoft.EntityFrameworkCore;

namespace Catalogo_Blazor.Server.Configurations;

public static class DataConfig
{
    public static IServiceCollection AddDataConfig(this IServiceCollection services, string Connection)
    {
        services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(Connection));

        return services;
    }
}
