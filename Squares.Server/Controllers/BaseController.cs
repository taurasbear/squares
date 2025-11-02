using Microsoft.AspNetCore.Mvc;

namespace Squares.Server.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class BaseController : ControllerBase;