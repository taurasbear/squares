using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Squares.Application.Features.PointFeatures.CreatePoint;
using Squares.Application.Interfaces.Data;
using Squares.Domain.Entities;
using Squares.Infrastructure.Data;
using Squares.Tests.Infrastructure;

namespace Squares.Tests.Features.HandlerTests.PointHandlerTests;

public class CreatePointCommandHandlerTests(
    DatabaseFixture<CreatePointCommandHandlerTests> fixture)
    : IClassFixture<DatabaseFixture<CreatePointCommandHandlerTests>>
{

    [Fact]
    public async Task Handle_ValidCreatePointCommand_ShouldCreatePoint()
    {
        // Arrange
        var dbContext = fixture.ServiceProvider.GetRequiredService<SquaresContext>();
        var repository = fixture.ServiceProvider.GetRequiredService<IRepository>();
        var mapper = fixture.ServiceProvider.GetRequiredService<IMapper>();
        var handler = new CreatePointCommandHandler(repository, mapper);

        var pointSet = new PointSet();

        await dbContext.AddAsync(pointSet);
        await dbContext.SaveChangesAsync();

        const int expectedX = 10;
        const int expectedY = -10;
        var command = new CreatePointCommand
        {
            X = expectedX,
            Y = expectedY,
            PointSetId = pointSet.Id,
        };

        // Act
        await handler.Handle(command, CancellationToken.None);

        // Assert
        const int expectedPointCount = 1;

        var points = await dbContext.Set<Point>().ToListAsync();

        points.Count.Should().Be(expectedPointCount);
        points.First().X.Should().Be(expectedX);
        points.First().Y.Should().Be(expectedY);
        points.First().PointSetId.Should().Be(pointSet.Id);
    }
}