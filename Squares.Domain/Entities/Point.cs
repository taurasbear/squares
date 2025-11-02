namespace Squares.Domain.Entities;

public class Point : BaseEntity
{
    public int X { get; set; }

    public int Y { get; set; }

    public virtual PointSet PointSet { get; set; } = null!;
}