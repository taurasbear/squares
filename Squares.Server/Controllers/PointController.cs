using MediatR;
using Microsoft.AspNetCore.Mvc;
using Squares.Application.Features.PointFeatures.CreatePoint;
using Squares.Application.Features.PointFeatures.DeletePoint;

namespace Squares.Server.Controllers;

public class PointController(IMediator mediator) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePointCommand command, CancellationToken cancellationToken)
    {
        await mediator.Send(command, cancellationToken);
        return Created();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeletePointCommand command, CancellationToken cancellationToken)
    {
        await mediator.Send(command, cancellationToken);
        return NoContent();
    }
}