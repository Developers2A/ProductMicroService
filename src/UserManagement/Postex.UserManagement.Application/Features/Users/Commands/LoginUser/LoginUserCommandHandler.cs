using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Api;
using Postex.SharedKernel.Interfaces;
using Postex.SharedKernel.Utilities;
using Postex.UserManagement.Application.Dtos.Users;
using Postex.UserManagement.Application.Features.Users.Commands.GenerateToken;
using Postex.UserManagement.Domain.Users;

namespace Postex.UserManagement.Application.Features.Users.Commands.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, ApiResult<TokenDto>>
{
    private readonly IWriteRepository<User> _writeRepository;
    private readonly IReadRepository<User> _readRepository;
    private readonly IMediator _mediator;

    public LoginUserCommandHandler(IWriteRepository<User> writeRepository, IReadRepository<User> readRepository, IMediator mediator)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
        _mediator = mediator;
    }

    public async Task<ApiResult<TokenDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _readRepository.TableNoTracking.FirstOrDefaultAsync(x => x.Mobile == request.Mobile);
        if (user == null)
        {
            return new ApiResult<TokenDto>(false, $"کاربری با این شماره موبایل {request.Mobile} یافت نشد");
        }
        if (!user.IsVerified)
        {
            return new ApiResult<TokenDto>(false, $"کاربری با این شماره موبایل {request.Mobile} فعال نشده است ");
        }

        var passwordHasher = new PasswordHasher();
        bool passwordVerified = passwordHasher.VerifyPassword(user.Password, request.Password);

        if (!passwordVerified)
        {
            return new ApiResult<TokenDto>(false, "کلمه عبور نادرست است");
        }

        TokenDto tokenDto = await _mediator.Send(new GenerateTokenCommand()
        {
            User = user
        });
        return new ApiResult<TokenDto>(true, tokenDto);
    }
}
