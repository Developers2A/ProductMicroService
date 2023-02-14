using MediatR;
using Postex.Application.Features.VerificationCodes.Commands.CreateVerificationCode;
using Postex.SharedKernel.Api;
using Postex.SharedKernel.Interfaces;
using Postex.UserManagement.Application.Dtos.Users;
using Postex.UserManagement.Domain;

namespace Postex.UserManagement.Application.Features.Users.Commands.LoginUserWithOtp;

public class LoginUserWithOtpCommandHandler : IRequestHandler<LoginUserWithOtpCommand, ApiResult<MobileDto>>
{
    private readonly IReadRepository<User> _userReadRepository;
    private readonly IMediator _mediator;
    private LoginUserWithOtpCommand _command;

    public LoginUserWithOtpCommandHandler(IReadRepository<User> userReadRepository, IMediator mediator)
    {
        _userReadRepository = userReadRepository;
        _mediator = mediator;
    }

    public async Task<ApiResult<MobileDto>> Handle(LoginUserWithOtpCommand command, CancellationToken cancellationToken)
    {
        _command = command;
        var user = _userReadRepository.TableNoTracking.FirstOrDefault(x => x.Mobile == _command.Mobile);
        if (user == null)
        {
            return new ApiResult<MobileDto>(false, $"کاربری با شماره موبایل {_command.Mobile} یافت نشد");
        }
        if (!user.IsVerified)
        {
            return new ApiResult<MobileDto>(false, $"کاربری با شماره موبایل {_command.Mobile} فعال نشده است ");
        }
        if (!user.IsActive)
        {
            return new ApiResult<MobileDto>(false, $"این کاربر غیرفعال شده است");
        }

        await CreateAndSendVerificationCode(user);

        var mobileDto = new MobileDto()
        {
            Mobile = user.Mobile
        };

        return new ApiResult<MobileDto>(true, mobileDto, "کد ورود به سیستم از طریق پیامک ارسال شد");
    }

    private async Task CreateAndSendVerificationCode(User user)
    {
        await _mediator.Send(new CreateVerificationCodeCommand()
        {
            Mobile = _command.Mobile,
            VerificationCodeType = VerificationCodeType.Otp,
            UserId = user.Id
        });
    }
}
