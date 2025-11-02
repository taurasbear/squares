using AutoMapper;
using MediatR;
using Squares.Application.Interfaces.Data;
using Squares.Domain.Entities;

namespace Squares.Application.Features.PointFeatures.CreatePoint;

public class CreatePointCommandHandler(IRepository repository, IMapper mapper) : IRequestHandler<CreatePointCommand>
{
    public async Task Handle(CreatePointCommand request, CancellationToken cancellationToken)
    {
        var point = mapper.Map<Point>(request);

        await repository.CreateAsync(point, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
    }
}