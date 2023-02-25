using MediatR;
using Postex.SharedKernel.Api;
using Postex.SharedKernel.Interfaces;
using Postex.UserManagement.Application.Dtos.Users;
using Postex.UserManagement.Application.Features.VerificationCodes.Commands.CreateVerificationCode;
using Postex.UserManagement.Domain.Users;

namespace Postex.UserManagement.Application.Features.Users.Commands.ForgetPassword;

public class ForgetPasswordCommandHandler : IRequestHandler<ForgetPasswordCommand, ApiResult<MobileDto>>
{
    private readonly IReadRepository<User> _userReadRepository;
    private readonly IMediator _mediator;

    private ForgetPasswordCommand _command;

    public ForgetPasswordCommandHandler(IReadRepository<User> userRadRepository, IMediator mediator)
    {
        _userReadRepository = userRadRepository;
        _mediator = mediator;
    }

    public async Task<ApiResult<MobileDto>> Handle(ForgetPasswordCommand command, CancellationToken cancellationToken)
    {
        _command = command;
        var user = _userReadRepository.TableNoTracking.FirstOrDefault(x => x.Mobile == _command.Mobile);
        if (user == null)
        {
            return new ApiResult<MobileDto>(false, $"کاربری با این شماره موبایل {_command.Mobile} فعال نشده است ");
        }
        if (!user.IsVerified)
        {
            return new ApiResult<MobileDto>(false, $"کاربری با این شماره موبایل {_command.Mobile} فعال نشده است ");
        }

        await CreateAndSendVerificationCode();
        var mobileDto = new MobileDto()
        {
            Mobile = user.Mobile
        };

        return new ApiResult<MobileDto>(true, mobileDto, "کد تایید فراموزشی رمز عبور از طریق پیامک ارسال شد");
    }

    private async Task CreateAndSendVerificationCode()
    {
        await _mediator.Send(new CreateVerificationCodeCommand()
        {
            Mobile = _command.Mobile,
            VerificationCodeType = VerificationCodeType.ForgetPassword
        });
    }
}

