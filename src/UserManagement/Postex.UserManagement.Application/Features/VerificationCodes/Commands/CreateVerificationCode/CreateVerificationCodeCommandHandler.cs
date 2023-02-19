using MediatR;
using Postex.Application.Features.VerificationCodes.Commands.CreateVerificationCode;
using Postex.SharedKernel.Interfaces;
using Postex.UserManagement.Domain;

namespace Postex.UserManagement.Application.Features.VerificationCodes.Commands.CreateVerificationCode;

public class CreateVerificationCodeCommandHandler : IRequestHandler<CreateVerificationCodeCommand>
{
    private readonly IWriteRepository<VerificationCode> _writeRepository;
    private readonly IReadRepository<VerificationCode> _readRepository;

    public CreateVerificationCodeCommandHandler(IWriteRepository<VerificationCode> writeRepository, IReadRepository<VerificationCode> readRepository)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
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

        return Unit.Value;
    }
}

