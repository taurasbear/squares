using MediatR;

namespace Squares.Application.Features.PointSetFeatures.CreatePointSet;

public sealed record CreatePointSetCommand : IRequest
{
    public ICollection<Point> Points { get; set; } = [];

    public sealed record Point
    {
        public int X { get; set; }

        public int Y { get; set; }
    }
}