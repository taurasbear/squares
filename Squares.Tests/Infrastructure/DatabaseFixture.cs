using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Squares.Application.Features.PointSetFeatures.GetSquares;
using Squares.Application.Interfaces.Data;
using Squares.Infrastructure.Data;
using Xunit;

namespace Squares.Tests.Infrastructure;

public class DatabaseFixture<T> : IAsyncLifetime where T : class
{
    public ServiceProvider ServiceProvider { get; private set; } = null!;

    public Task InitializeAsync()
    {
        var services = new ServiceCollection();
        services.AddDbContext<SquaresContext>(
            options => options
                .UseLazyLoadingProxies()
                .UseInMemoryDatabase(databaseName: $"{typeof(T).Name}_{Guid.NewGuid()}"));

        services.AddScoped<IRepository, Repository>();
        services.AddAutoMapper(typeof(GetSquaresQueryHandler).Assembly);

        ServiceProvider = services.BuildServiceProvider();

        return Task.CompletedTask;
    }

    public async Task DisposeAsync()
    {
        if (ServiceProvider != null)
        {
            await ServiceProvider.DisposeAsync();
        }
    }
}