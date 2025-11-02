using MediatR;
using Squares.Application.Interfaces.Data;
using Squares.Domain.Entities;

namespace Squares.Application.Features.PointFeatures.DeletePoint;

public class DeletePointCommandHandler(IRepository repository) : IRequestHandler<DeletePointCommand>
{
    public async Task Handle(DeletePointCommand request, CancellationToken cancellationToken)
    {
        var point = await repository.GetByIdAsync<Point>(request.Id, cancellationToken);

        repository.DeleteAsync(point, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
    }
}