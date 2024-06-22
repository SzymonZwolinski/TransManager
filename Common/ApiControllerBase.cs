using MediatR;

namespace TransManager.Common
{
    public abstract class ApiControllerBase
    {
        protected readonly IMediator _mediator;

        protected ApiControllerBase(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
