using MediatR;
using Postex.SharedKernel.Api;
using Postex.SharedKernel.Interfaces;
using Postex.SharedKernel.Utilities;
using Postex.UserManagement.Application.Dtos.Users;
using Postex.UserManagement.Application.Features.Users.Commands.GenerateToken;
using Postex.UserManagement.Domain;

namespace Postex.UserManagement.Application.Features.Users.Commands.ChangePassword;

public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ApiResult<TokenDto>>
{
    private readonly IReadRepository<User> _userReadRepository;
    private readonly IReadRepository<VerificationCode> _verificationCodeReadRepository;
    private readonly IWriteRepository<User> _userWriteRepository;
    private readonly IWriteRepository<VerificationCode> _verificationCodeWriteRepository;
    private readonly IMediator _mediator;

    public ChangePasswordCommandHandler(IReadRepository<User> userRadRepository, IMediator mediator, IReadRepository<VerificationCode> verificationCodeReadRepository, IWriteRepository<User> userWriteRepository, IWriteRepository<VerificationCode> verificationCodeWriteRepository)
    {
        _userReadRepository = userRadRepository;
        _mediator = mediator;
        _verificationCodeReadRepository = verificationCodeReadRepository;
        _userWriteRepository = userWriteRepository;
        _verificationCodeWriteRepository = verificationCodeWriteRepository;
    }

    public async Task<ApiResult<TokenDto>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var user = _userReadRepository.Table.FirstOrDefault(x => x.Mobile == request.Mobile);
        if (user == null)
        {
            return new ApiResult<TokenDto>(false, $"کاربری با این شماره موبایل {request.Mobile} یافت نشد");
        }
        if (!user.IsVerified)
        {
            return new ApiResult<TokenDto>(false, $"کاربری با این شماره موبایل {request.Mobile} فعال نشده است ");
        }

        await UpdatePassword(request, user);

        TokenDto tokenDto = await _mediator.Send(new GenerateTokenCommand()
        {
            User = user
        });
        return new ApiResult<TokenDto>(true, tokenDto);
    }

    private async Task UpdatePassword(ChangePasswordCommand request, User user)
    {
        var passwordHasher = new PasswordHasher();
        var hashedPassword = passwordHasher.HashPassword(request.NewPassword);
        user.Password = hashedPassword;
        _userWriteRepository.Update(user);
        await _userWriteRepository.SaveChangeAsync();
    }
}

