using MediatR;
using Microsoft.Extensions.Configuration;
using Postex.SharedKernel.Interfaces;
using Postex.SharedKernel.Settings;
using Postex.UserManagement.Application.Features.Messages.Commands;
using Postex.UserManagement.Domain.Users;

namespace Postex.UserManagement.Application.Features.VerificationCodes.Commands.CreateVerificationCode;

public class CreateVerificationCodeCommandHandler : IRequestHandler<CreateVerificationCodeCommand>
{
    private readonly IWriteRepository<VerificationCode> _writeRepository;
    private readonly IReadRepository<VerificationCode> _readRepository;
    private readonly IConfiguration _configuration;
    private readonly TemplateSetting _templateSetting;
    private readonly IMediator _mediator;

    public CreateVerificationCodeCommandHandler(IWriteRepository<VerificationCode> writeRepository, IReadRepository<VerificationCode> readRepository, IMediator mediator, IConfiguration configuration)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
        _mediator = mediator;
        _configuration = configuration;
        _templateSetting = _configuration.GetSection(nameof(TemplateSetting)).Get<TemplateSetting>();
    }

    public async Task<Unit> Handle(CreateVerificationCodeCommand request, CancellationToken cancellationToken)
    {
        Random generator = new Random();
        int code = generator.Next(100000, 1000000);

        if (!request.Mobile.StartsWith("0"))
        {
            request.Mobile = "0" + request.Mobile;
        }
        var verificationCode = new VerificationCode()
        {
            Code = 1111,
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
        int template = GetSmsTemplate(request);
        var smsParameters = new Dictionary<string, string>();
        smsParameters.Add("code", code.ToString());

        await _mediator.Send(new SendSmsCommand()
        {
            Parameters = smsParameters,
            Mobile = request.Mobile,
            Template = template
        });
    }

    private int GetSmsTemplate(CreateVerificationCodeCommand request)
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
        return 1;
    }
}

