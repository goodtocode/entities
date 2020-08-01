using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace GoodToCode.Extensions.Mvc
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class ControllerMediator : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    }
}
