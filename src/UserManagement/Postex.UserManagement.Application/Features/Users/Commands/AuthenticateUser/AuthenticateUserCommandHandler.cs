using AutoMapper;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using Postex.SharedKernel.Interfaces;
using Postex.SharedKernel.Utilities;
using Postex.UserManagement.Application.Dtos.Users;
using Postex.UserManagement.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pouya.Application.Features.Users.Commands;

public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, AuthenticateUserDto>
{
    private readonly IWriteRepository<User> _writeRepository;
    private readonly IReadRepository<User> _readRepository;
    private readonly IMapper _mapper;

    public AuthenticateUserCommandHandler(IWriteRepository<User> writeRepository, IMapper mapper, IReadRepository<User> readRepository)
    {
        _writeRepository = writeRepository;
        _mapper = mapper;
        _readRepository = readRepository;
    }

    public async Task<AuthenticateUserDto> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _readRepository.TableNoTracking.FirstOrDefault(x => x.UserName == request.UserName);
        if (user == null)
        {
            return new AuthenticateUserDto()
            {
                Token = "",
                Message = "کاربر یافت نشد"
            };
        }
        if (!user.IsActive)
        {
            return new AuthenticateUserDto()
            {
                Token = "",
                Message = "کاربر غیرفعال می باشد"
            };
        }

        var passwordHasher = new PasswordHasher();
        bool passwordVerified = passwordHasher.VerifyPassword(user.Password, request.Password);

        if (passwordVerified)
        {
            string token = GenerateJwtToken(user);
            return new AuthenticateUserDto()
            {
                Token = token,
                Message = ""
            };
        }

        return new AuthenticateUserDto()
        {
            Token = "",
            Message = "کلمه عبور نادرست است"
        };
    }

    private string GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("secret");
        var symetricKey = new SymmetricSecurityKey(key);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
            }),
            Expires = DateTime.UtcNow.AddMinutes(70),
            SigningCredentials = new SigningCredentials(symetricKey, SecurityAlgorithms.HmacSha256Signature)
        };

        tokenDescriptor.IssuedAt = DateTime.UtcNow;

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
