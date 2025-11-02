using MediatR;
using Microsoft.AspNetCore.Mvc;
using Squares.Application.Features.PointSetFeatures.CreatePointSet;
using Squares.Application.Features.PointSetFeatures.GetSquares;

namespace Squares.Server.Controllers;

public class PointSetController(IMediator mediator) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePointSetCommand command, CancellationToken cancellationToken)
    {
        await mediator.Send(command, cancellationToken);
        return Created();
    }

    [HttpGet]
    public async Task<ActionResult<GetSquaresResponse>> GetSquares([FromQuery] GetSquaresQuery query, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(query, cancellationToken);
        return Ok(response);
    }
}