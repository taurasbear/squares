using MediatR;
using Microsoft.AspNetCore.Mvc;
using Squares.Application.Features.PointSetFeatures.CreatePointSet;

namespace Squares.Server.Controllers;

public class PointSetController(IMediator mediator) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePointSetCommand command, CancellationToken cancellationToken)
    {
        await mediator.Send(command, cancellationToken);
        return Created();
    }
}