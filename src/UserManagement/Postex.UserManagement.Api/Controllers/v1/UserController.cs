using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.SharedKernel.Api;
using Pouya.Application.Features.Users.Commands;

namespace Postex.ProductService.Api.Controllers.v1;

[ApiVersion("1")]
public class UserController : BaseApiControllerWithDefaultRoute
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ApiResult> Post([FromBody] CreateUserCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPut]
    public async Task<ApiResult> Put([FromBody] UpdateUserCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public async Task<ApiResult> Authenticate([FromBody] AuthenticateUserCommand command)
    {
        var result = await _mediator.Send(command);
        if (string.IsNullOrEmpty(result.Token))
        {
            return new ApiResult(false, result.Message!);
        }
        return new ApiResult(true, result.Token);
    }
}
