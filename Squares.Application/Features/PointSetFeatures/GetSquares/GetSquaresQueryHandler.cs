using AutoMapper;
using MediatR;
using Squares.Application.Interfaces.Data;
using Squares.Application.Interfaces.Services;
using Squares.Application.Models;
using Squares.Domain.Entities;

namespace Squares.Application.Features.PointSetFeatures.GetSquares;

public class GetSquaresQueryHandler(
    IRepository repository,
    IMapper mapper,
    ISquareService squareService) : IRequestHandler<GetSquaresQuery, IEnumerable<GetSquaresResponse>>
{
    public async Task<IEnumerable<GetSquaresResponse>> Handle(GetSquaresQuery request, CancellationToken cancellationToken)
    {
        var pointSet = await repository.GetByIdAsync<PointSet>(request.PointSetId, cancellationToken);

        var pointValues = mapper.Map<IEnumerable<PointValue>>(pointSet.Points);

        var squares = squareService.FindSquares(pointValues);

        var response = mapper.Map<IEnumerable<GetSquaresResponse>>(squares);
        return response;
    }
}