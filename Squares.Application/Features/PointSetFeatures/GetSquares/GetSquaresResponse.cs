using Squares.Application.Models;

namespace Squares.Application.Features.PointSetFeatures.GetSquares;

public sealed record GetSquaresResponse
{
    public ICollection<PointValue> Points { get; set; } = [];
}