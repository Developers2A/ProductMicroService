using MediatR;
using Microsoft.Extensions.Options;
using Postex.SharedKernel.Interfaces;
using Postex.SharedKernel.Settings;
using Postex.UserManagement.Application.Features.Messages.Commands;
using Postex.UserManagement.Domain.Users;

namespace Postex.UserManagement.Application.Features.VerificationCodes.Commands.CreateVerificationCode;

public class CreateVerificationCodeCommandHandler : IRequestHandler<CreateVerificationCodeCommand>
{
    private readonly IWriteRepository<VerificationCode> _writeRepository;
    private readonly IReadRepository<VerificationCode> _readRepository;
    private readonly TemplateSetting _templateSetting;
    private readonly IMediator _mediator;

    public CreateVerificationCodeCommandHandler(
        IWriteRepository<VerificationCode> writeRepository,
        IReadRepository<VerificationCode> readRepository,
        IMediator mediator,
        IOptions<TemplateSetting> templateSetting)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
        _mediator = mediator;
        _templateSetting = templateSetting.Value;
    }

    public async Task<Unit> Handle(CreateVerificationCodeCommand request, CancellationToken cancellationToken)
    {
        Random generator = new Random();
        int code = generator.Next(1000, 10000);

        if (!request.Mobile.StartsWith("0"))
        {
            request.Mobile = "0" + request.Mobile;
        }
        var verificationCode = new VerificationCode()
        {
            Code = code,
            Mobile = request.Mobile,
            VerificationCodeType = request.VerificationCodeType,
            IsUsed = false
        };

        await _writeRepository.AddAsync(verificationCode);
        await _writeRepository.SaveChangeAsync();
        await SendSms(request, code);
        return Unit.Value;
    }

    private async Task SendSms(CreateVerificationCodeCommand request, int code)
    {
        string template = GetSmsTemplate(request);
        var smsParameters = new Dictionary<string, string>();
        smsParameters.Add("code", code.ToString());

        await _mediator.Send(new SendSmsCommand()
        {
            Parameters = smsParameters,
            Mobile = request.Mobile,
            TemplateName = template
        });
    }

    private string GetSmsTemplate(CreateVerificationCodeCommand request)
    {
        if (request.VerificationCodeType == VerificationCodeType.Register)
        {
            return _templateSetting.SmsRegister;
        }
        if (request.VerificationCodeType == VerificationCodeType.Otp)
        {
            return _templateSetting.SmsOtp;
        }
        if (request.VerificationCodeType == VerificationCodeType.ForgetPassword)
        {
            return _templateSetting.SmsForgetPassword;
        }
        return "";
    }
}

