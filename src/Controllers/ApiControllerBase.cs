using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Conduit.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender _mediator = null!;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>()!;
}
