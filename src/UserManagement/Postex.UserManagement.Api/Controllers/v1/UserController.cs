using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.SharedKernel.Api;
using Postex.UserManagement.Application.Features.Users.Commands.AuthenticateUser;
using Postex.UserManagement.Application.Features.Users.Commands.CreateUser;
using Postex.UserManagement.Application.Features.Users.Commands.ForgetPassword;
using Postex.UserManagement.Application.Features.Users.Commands.VerifiyUser;

namespace Postex.ProductService.Api.Controllers.v1;

[ApiVersion("1")]
public class UserController : BaseApiControllerWithDefaultRoute
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<ApiResult> Register([FromBody] CreateUserCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPost("verify-code")]
    [AllowAnonymous]
    public async Task<ApiResult> Verify([FromBody] VerifyUserCommand command)
    {
        var result = await _mediator.Send(command);
        if (string.IsNullOrEmpty(result.Token))
        {
            return new ApiResult(false, result.Message!);
        }
        return new ApiResult(true, result.Token);
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

    [AllowAnonymous]
    [HttpPost("forget-password")]
    public async Task<ApiResult> ForgetPassword([FromBody] ForgetPasswordCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok();
    }
}
