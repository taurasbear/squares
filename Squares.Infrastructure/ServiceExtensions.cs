using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Squares.Application.Interfaces.Data;
using Squares.Infrastructure.Data;

namespace Squares.Infrastructure;

public static class ServiceExtensions
{
    public static void ConfigureInfrastructure(this IServiceCollection services, string? connectionString)
    {
        services.AddDbContext<SquaresContext>(
            opt => opt
                .UseLazyLoadingProxies()
                .UseNpgsql(connectionString)
        );

        services.AddScoped<IRepository, Repository>();
    }
}