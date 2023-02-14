using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.SharedKernel.Api;
using Postex.UserManagement.Application.Dtos.Users;
using Postex.UserManagement.Application.Features.Users.Commands.ChangePassword;
using Postex.UserManagement.Application.Features.Users.Commands.CreateUser;
using Postex.UserManagement.Application.Features.Users.Commands.ForgetPassword;
using Postex.UserManagement.Application.Features.Users.Commands.LoginUser;
using Postex.UserManagement.Application.Features.Users.Commands.LoginUserWithOtp;
using Postex.UserManagement.Application.Features.Users.Commands.RefreshToken;
using Postex.UserManagement.Application.Features.Users.Commands.RevokeToken;
using Postex.UserManagement.Application.Features.Users.Commands.VerifiyCode;
using System.Security.Claims;

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
    public async Task<ApiResult<MobileDto>> Register([FromBody] CreateUserCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPost("verify-code")]
    [AllowAnonymous]
    public async Task<ApiResult<TokenDto>> Verify([FromBody] VerifyCodeCommand command)
    {
        return await _mediator.Send(command);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ApiResult<TokenDto>> Login([FromBody] LoginUserCommand command)
    {
        return await _mediator.Send(command);
    }

    [AllowAnonymous]
    [HttpPost("login-otp")]
    public async Task<ApiResult<MobileDto>> LoginWitOtp([FromBody] LoginUserWithOtpCommand command)
    {
        return await _mediator.Send(command);
    }

    [AllowAnonymous]
    [HttpPost("forget-password")]
    public async Task<ApiResult> ForgetPassword([FromBody] ForgetPasswordCommand command)
    {
        return await _mediator.Send(command);
    }

    [AllowAnonymous]
    [HttpPost("change-password")]
    public async Task<ApiResult<TokenDto>> ChangePassword([FromBody] ChangePasswordCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPost]
    [Route("refresh-token")]
    public async Task<ApiResult<TokenDto>> RefreshToken(RefreshTokenCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPost("revoke")]
    [Authorize]
    public async Task<ApiResult> Revoke()
    {
        var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var command = new RevokeTokenCommand()
        {
            UserId = int.Parse(userId)
        };
        await _mediator.Send(command);
        return Ok();
    }
}

