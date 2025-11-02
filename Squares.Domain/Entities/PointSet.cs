namespace Squares.Domain.Entities;

public class PointSet : BaseEntity
{
    public virtual ICollection<Point> Points { get; set; } = [];
}