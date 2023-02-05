using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.SharedKernel.Api;

namespace Postex.ProductService.Api.Controllers.v1
{
    [ApiVersion("1")]
    public class UserController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
