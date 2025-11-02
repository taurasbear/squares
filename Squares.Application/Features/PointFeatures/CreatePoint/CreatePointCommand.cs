using MediatR;

namespace Squares.Application.Features.PointFeatures.CreatePoint;

public sealed record CreatePointCommand : IRequest
{
    public Guid PointSetId { get; set; }

    public int X { get; set; }

    public int Y { get; set; }
};