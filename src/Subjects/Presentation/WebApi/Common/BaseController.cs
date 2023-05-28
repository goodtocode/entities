using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Goodtocode.Subjects.WebApi.Common;

/// <summary>
///     Base Controller
/// </summary>
[ApiController]
[Route("api/[controller]/[action]")]
public abstract class BaseController : ControllerBase
{
    private IMediator _mediator;

    /// <summary>
    ///     Defines a mediator to encapsulate request/response and publishing interaction
    /// </summary>
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}