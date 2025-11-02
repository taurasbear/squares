using AutoMapper;
using MediatR;
using Squares.Application.Interfaces;
using Squares.Domain.Entities;

namespace Squares.Application.Features.PointSetFeatures.CreatePointSet;

public class CreatePointSetCommandHandler(IRepository repository, IMapper mapper) : IRequestHandler<CreatePointSetCommand>
{
    public async Task Handle(CreatePointSetCommand request, CancellationToken cancellationToken)
    {
        var pointSet = new PointSet();

        foreach (var requestPoint in request.Points)
        {
            var point = mapper.Map<Point>(requestPoint);
            pointSet.Points.Add(point);
        }

        await repository.CreateAsync(pointSet, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
    }
}