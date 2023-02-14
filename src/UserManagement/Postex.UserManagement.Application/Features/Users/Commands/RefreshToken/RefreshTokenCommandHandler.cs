using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Postex.SharedKernel.Api;
using Postex.SharedKernel.Interfaces;
using Postex.SharedKernel.Settings;
using Postex.UserManagement.Application.Dtos.Users;
using Postex.UserManagement.Application.Features.Users.Commands.GenerateToken;
using Postex.UserManagement.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Postex.UserManagement.Application.Features.Users.Commands.RefreshToken;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, ApiResult<TokenDto>>
{
    private readonly JwtSetting _jwtSetting;
    private readonly IReadRepository<User> _userReadRepository;
    private readonly IMediator _mediator;

    public RefreshTokenCommandHandler(IOptions<JwtSetting> jwtSetting, IReadRepository<User> userReadRepository, IMediator mediator)
    {
        _jwtSetting = jwtSetting.Value;
        _userReadRepository = userReadRepository;
        _mediator = mediator;
    }

    public async Task<ApiResult<TokenDto>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var principal = GetPrincipalFromExpiredToken(request.Token);
        if (principal == null)
        {
            return new ApiResult<TokenDto>(false, "Invalid access token or refresh token");
        }

        string username = principal.Identity!.Name!;

        var user = await _userReadRepository.Table.FirstOrDefaultAsync(x => x.Id == int.Parse(username));

        if (user == null || user.RefreshToken != request.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
        {
            return new ApiResult<TokenDto>(false, "Invalid access token or refresh token");
        }

        var tokenDto = await _mediator.Send(new GenerateTokenCommand()
        {
            User = user
        });

        return new ApiResult<TokenDto>(false, tokenDto);
    }

    private ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.Key)),
            ValidateLifetime = false
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
        if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("توکن درست نمی باشد");

        return principal;
    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}

