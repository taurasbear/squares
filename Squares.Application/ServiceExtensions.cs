using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Squares.Application.Interfaces.Services;
using Squares.Application.Services;

namespace Squares.Application;

public static class ServiceExtensions
{
    public static void ConfigureApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<ISquareService, SquareService>();
    }
}