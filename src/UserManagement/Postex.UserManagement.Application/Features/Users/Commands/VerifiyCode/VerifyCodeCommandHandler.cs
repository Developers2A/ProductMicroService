using MediatR;
using Microsoft.Extensions.Options;
using Postex.SharedKernel.Api;
using Postex.SharedKernel.Interfaces;
using Postex.SharedKernel.Settings;
using Postex.UserManagement.Application.Dtos.Users;
using Postex.UserManagement.Application.Features.Users.Commands.GenerateToken;
using Postex.UserManagement.Domain;

namespace Postex.UserManagement.Application.Features.Users.Commands.VerifiyCode;

public class VerifyCodeCommandHandler : IRequestHandler<VerifyCodeCommand, ApiResult<TokenDto>>
{
    private readonly IReadRepository<User> _userReadRepository;
    private readonly IWriteRepository<User> _userWriteRepository;
    private readonly IReadRepository<VerificationCode> _verificationCodeReadRepository;
    private readonly IWriteRepository<VerificationCode> _verificationCodeWriteRepository;
    private readonly CodeExpirationSetting _codeExpirationSetting;
    private readonly IMediator _mediator;

    private VerifyCodeCommand _command;

    public VerifyCodeCommandHandler(
        IReadRepository<User> userRadRepository,
        IReadRepository<VerificationCode> verificationCodeReadRepository,
        IWriteRepository<User> userWriteRepository,
        IWriteRepository<VerificationCode> verificationCodeWriteRepository,
        IOptions<CodeExpirationSetting> codeExpirationSetting,
        IMediator mediator)
    {
        _userReadRepository = userRadRepository;
        _userWriteRepository = userWriteRepository;
        _verificationCodeReadRepository = verificationCodeReadRepository;
        _verificationCodeWriteRepository = verificationCodeWriteRepository;
        _codeExpirationSetting = codeExpirationSetting.Value;
        _mediator = mediator;
    }

    public async Task<ApiResult<TokenDto>> Handle(VerifyCodeCommand command, CancellationToken cancellationToken)
    {
        _command = command;
        var user = _userReadRepository.Table.FirstOrDefault(x => x.Mobile == _command.Mobile);
        if (user == null)
        {
            return new ApiResult<TokenDto>(false, $"کاربری با شماره موبایل {_command.Mobile} یافت نشد");
        }

        if (_command.VerificationCodeType != VerificationCodeType.Register)
        {
            if (!user.IsVerified)
            {
                return new ApiResult<TokenDto>(false, $"ثبت نام کاربری با شماره موبایل {_command.Mobile} تکمیل نشده است ");
            }
            if (!user.IsActive)
            {
                return new ApiResult<TokenDto>(false, $"این کاربر غیر فعال می باشد ");
            }
        }

        var expirationMinute = GetVerificationExpirationTime();
        var verificationCode = _verificationCodeReadRepository.Table.OrderByDescending(x => x.CreatedOn).FirstOrDefault(x => !x.IsUsed && x.Mobile == _command.Mobile && x.Code == _command.Code && x.VerificationCodeType == _command.VerificationCodeType);
        if (verificationCode == null || verificationCode.CreatedOn.AddMinutes(expirationMinute) < DateTime.Now)
        {
            return new ApiResult<TokenDto>(false, "این کد منقضی شده است");
        }

        await UpdateVerificationCode(verificationCode, user);
        await VerifiyUser(user);
        TokenDto tokenDto = await CreateToken(user);
        return new ApiResult<TokenDto>(true, tokenDto);
    }

    private int GetVerificationExpirationTime()
    {
        if (_command.VerificationCodeType == VerificationCodeType.Register)
        {
            return _codeExpirationSetting.Register;
        }
        if (_command.VerificationCodeType == VerificationCodeType.Otp)
        {
            return _codeExpirationSetting.Otp;
        }
        if (_command.VerificationCodeType == VerificationCodeType.ForgetPassword)
        {
            return _codeExpirationSetting.ForgetPassword;
        }

        return 10;
    }

    private async Task<TokenDto> CreateToken(User user)
    {
        return await _mediator.Send(new GenerateTokenCommand()
        {
            User = user
        });
    }

    private async Task VerifiyUser(User user)
    {
        user.IsVerified = true;
        user.IsActive = true;
        await _userWriteRepository.UpdateAsync(user);
        await _userWriteRepository.SaveChangeAsync();
    }

    private async Task UpdateVerificationCode(VerificationCode verificationCode, User user)
    {
        verificationCode.IsUsed = true;
        verificationCode.UserId = user.Id;
        await _verificationCodeWriteRepository.UpdateAsync(verificationCode);
        await _verificationCodeWriteRepository.SaveChangeAsync();
    }
}

