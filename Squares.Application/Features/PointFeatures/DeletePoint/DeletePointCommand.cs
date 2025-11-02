using MediatR;

namespace Squares.Application.Features.PointFeatures.DeletePoint;

public sealed record DeletePointCommand : IRequest
{
    public Guid Id { get; set; }
}