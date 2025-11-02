using Squares.Application.Common.Exceptions;

namespace Squares.Application.Models;

public record Square
{
    public IReadOnlyList<PointValue> Points { get; } = [];

    public Square(IEnumerable<PointValue> points)
    {
        if (points.Count() != 4)
        {
            throw new InvalidSquareException("A square must have exactly 4 points.");
        }

        Points = [.. points];
    }

    public virtual bool Equals(Square? other)
    {
        if (other == null) return false;

        var thisSet = new HashSet<PointValue>(Points);
        var otherSet = new HashSet<PointValue>(other.Points);

        return thisSet.SetEquals(otherSet);
    }

    public override int GetHashCode()
    {
        return Points.Aggregate(0, (hash, point) => hash ^ point.GetHashCode());
    }
}