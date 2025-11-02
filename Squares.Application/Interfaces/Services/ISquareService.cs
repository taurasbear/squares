using Squares.Application.Models;

namespace Squares.Application.Interfaces.Services;

public interface ISquareService
{
    public ICollection<Square> FindSquares(IEnumerable<PointValue> points);
}