using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Postex.SharedKernel.Interfaces;
using Postex.SharedKernel.Settings;
using Postex.UserManagement.Application.Dtos.Users;
using Postex.UserManagement.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Postex.UserManagement.Application.Features.Users.Commands.GenerateToken;

public class GenerateTokenCommandHandler : IRequestHandler<GenerateTokenCommand, TokenDto>
{
    private readonly JwtSetting _jwtSetting;
    private readonly IWriteRepository<User> _userWriteRepository;

    public GenerateTokenCommandHandler(IOptions<JwtSetting> jwtSetting, IWriteRepository<User> userWriteRepository)
    {
        _jwtSetting = jwtSetting.Value;
        _userWriteRepository = userWriteRepository;
    }

    public async Task<TokenDto> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
    {
        var refreshToken = GenerateRefreshToken();
        request.User.RefreshToken = refreshToken;
        request.User.RefreshTokenExpiryTime = DateTime.Now.AddDays(_jwtSetting.RefreshTokenValidityInDays);
        _userWriteRepository.Update(request.User);

        return new TokenDto()
        {
            Token = GenerateJwtToken(request.User),
            RefreshToken = refreshToken
        };
    }

    private string GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Id.ToString())
            }),
            Expires = DateTime.UtcNow.AddMinutes(_jwtSetting.DurationInMinutes),
            SigningCredentials = signingCredentials,
            IssuedAt = DateTime.UtcNow
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
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

