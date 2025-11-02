using Squares.Application.Interfaces.Services;
using Squares.Application.Models;

namespace Squares.Application.Services;

public class SquareService : ISquareService
{
    public ICollection<Square> FindSquares(IEnumerable<PointValue> points)
    {
        var squares = new List<Square>();
        var pointsList = points.ToList();
        var pointHash = new HashSet<PointValue>(pointsList);

        for (int a = 0; a < pointsList.Count; a++)
        {
            for (int c = a + 1; c < pointsList.Count; c++)
            {
                var aPoint = points.ElementAt(a);
                var cPoint = points.ElementAt(c);

                var (bPoint, dPoint) = GetOppositeDiagonal(aPoint, cPoint);

                if (pointHash.Contains(bPoint) && pointHash.Contains(dPoint))
                {
                    var square = new Square([aPoint, bPoint, cPoint, dPoint]);
                    if (!squares.Contains(square))
                        squares.Add(square);
                }
            }
        }

        return squares;
    }

    private static (PointValue b, PointValue d) GetOppositeDiagonal(PointValue a, PointValue c)
    {
        int midX = (a.X + c.X) / 2;
        int midY = (a.Y + c.Y) / 2;

        int Ax = a.X - midX;
        int Ay = a.Y - midY;
        int bX = midX - Ay;
        int bY = midY + Ax;
        var b = new PointValue(bX, bY);

        int cX = c.X - midX;
        int cY = c.Y - midY;
        int dX = midX - cY;
        int dY = midY + cX;
        var d = new PointValue(dX, dY);

        return (b, d);
    }
}