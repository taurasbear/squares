using MediatR;

namespace Squares.Application.Features.PointSetFeatures.GetSquares;

public sealed record GetSquaresQuery : IRequest<IEnumerable<GetSquaresResponse>>
{
    public Guid PointSetId { get; set; }
}