using MediatR;
using Postex.Application.Features.VerificationCodes.Commands.UpdateVerificationCode;
using Postex.SharedKernel.Interfaces;
using Postex.UserManagement.Domain;

namespace Postex.UserManagement.Application.Features.VerificationCodes.Commands.UpdateVerificationCode;

public class UpdateVerificationCodeCommandHandler : IRequestHandler<UpdateVerificationCodeCommand>
{
    private readonly IWriteRepository<VerificationCode> _writeRepository;
    private readonly IReadRepository<VerificationCode> _readRepository;

    public UpdateVerificationCodeCommandHandler(IWriteRepository<VerificationCode> writeRepository, IReadRepository<VerificationCode> readRepository)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
    }

    public async Task<Unit> Handle(UpdateVerificationCodeCommand request, CancellationToken cancellationToken)
    {
        var verificationCode = _readRepository.Table.FirstOrDefault(x => x.Mobile == request.Mobile && x.Code == request.Code);
        verificationCode.IsUsed = request.IsUsed;
        await _writeRepository.UpdateAsync(verificationCode);
        await _writeRepository.SaveChangeAsync();
        return Unit.Value;
    }
}

