using MediatR;
using Postex.SharedKernel.Interfaces;
using Postex.UserManagement.Application.Features.Messages.Commands;
using Postex.UserManagement.Domain.Users;

namespace Postex.UserManagement.Application.Features.VerificationCodes.Commands.CreateVerificationCode;

public class CreateVerificationCodeCommandHandler : IRequestHandler<CreateVerificationCodeCommand>
{
    private readonly IWriteRepository<VerificationCode> _writeRepository;
    private readonly IReadRepository<VerificationCode> _readRepository;
    private readonly IMediator _mediator;

    public CreateVerificationCodeCommandHandler(IWriteRepository<VerificationCode> writeRepository, IReadRepository<VerificationCode> readRepository, IMediator mediator)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
        _mediator = mediator;
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
        await _mediator.Send(new SendSmsCommand()
        {
            Code = code.ToString(),
            Mobile = request.Mobile,
            Template = request.VerificationCodeType.ToString()
        });
    }
}

