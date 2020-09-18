using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace GoodToCode.Extensions.Mvc
{
    [ApiController]
    public abstract class ControllerMediator : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ?? HttpContext.RequestServices.GetService<IMediator>();

        protected ControllerMediator(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
