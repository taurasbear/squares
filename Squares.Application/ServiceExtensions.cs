using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Squares.Application.Common.Behaviors;
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
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<ISquareService, SquareService>();
    }
}