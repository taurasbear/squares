using Microsoft.AspNetCore.Mvc;

namespace Squares.Server.Controllers;

public class PointController : BaseController
{
    [HttpPost]
    public IActionResult Create(CancellationToken cancellationToken)
    {
        return Created();
    }
}