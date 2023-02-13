using MediatR;
using Postex.Application.Features.VerificationCodes.Commands.CreateVerificationCode;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Postex.UserManagement.Domain;

namespace Postex.UserManagement.Application.Features.Users.Commands.ForgetPassword;

public class ForgetPasswordCommandHandler : IRequestHandler<ForgetPasswordCommand>
{
    private readonly IReadRepository<User> _userReadRepository;
    private readonly IReadRepository<VerificationCode> _verificationCodeReadRepository;
    private readonly IWriteRepository<User> _userWriteRepository;
    private readonly IWriteRepository<VerificationCode> _verificationCodeWriteRepository;
    private readonly IMediator _mediator;

    public ForgetPasswordCommandHandler(IReadRepository<User> userRadRepository, IMediator mediator, IReadRepository<VerificationCode> verificationCodeReadRepository, IWriteRepository<User> userWriteRepository, IWriteRepository<VerificationCode> verificationCodeWriteRepository)
    {
        _userReadRepository = userRadRepository;
        _mediator = mediator;
        _verificationCodeReadRepository = verificationCodeReadRepository;
        _userWriteRepository = userWriteRepository;
        _verificationCodeWriteRepository = verificationCodeWriteRepository;
    }

    public async Task<Unit> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = _userReadRepository.Table.FirstOrDefault(x => x.Mobile == request.Mobile);
        if (user == null)
        {
            throw new AppException("کاربری با این شماره موبایل وجود ندارد");
        }

        await _mediator.Send(new CreateVerificationCodeCommand()
        {
            Mobile = request.Mobile
        });
        //send sms
        return Unit.Value;
    }
}

