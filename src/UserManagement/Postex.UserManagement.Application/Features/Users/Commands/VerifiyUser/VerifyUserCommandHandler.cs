using MediatR;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Postex.UserManagement.Application.Dtos.Users;
using Postex.UserManagement.Application.Features.Users.Commands.AuthenticateUser;
using Postex.UserManagement.Domain;

namespace Postex.UserManagement.Application.Features.Users.Commands.VerifiyUser;

public class VerifyUserCommandHandler : IRequestHandler<VerifyUserCommand, AuthenticateUserDto>
{
    private readonly IReadRepository<User> _userReadRepository;
    private readonly IReadRepository<VerificationCode> _verificationCodeReadRepository;
    private readonly IWriteRepository<User> _userWriteRepository;
    private readonly IWriteRepository<VerificationCode> _verificationCodeWriteRepository;
    private readonly IMediator _mediator;

    public VerifyUserCommandHandler(IReadRepository<User> userRadRepository, IMediator mediator, IReadRepository<VerificationCode> verificationCodeReadRepository, IWriteRepository<User> userWriteRepository, IWriteRepository<VerificationCode> verificationCodeWriteRepository)
    {
        _userReadRepository = userRadRepository;
        _mediator = mediator;
        _verificationCodeReadRepository = verificationCodeReadRepository;
        _userWriteRepository = userWriteRepository;
        _verificationCodeWriteRepository = verificationCodeWriteRepository;
    }

    public async Task<AuthenticateUserDto> Handle(VerifyUserCommand request, CancellationToken cancellationToken)
    {
        var user = _userReadRepository.Table.FirstOrDefault(x => x.Mobile == request.Mobile);
        if (user == null)
        {
            throw new AppException("کاربری با این شماره موبایل وجود ندارد");
        }

        var verificationCode = _verificationCodeReadRepository.Table.OrderByDescending(x => x.CreatedOn).FirstOrDefault(x => !x.IsUsed && x.Mobile == request.Mobile && x.Code == request.Code);
        if (verificationCode == null || verificationCode.CreatedOn.AddMinutes(10) <= DateTime.Now)
        {
            throw new AppException("این کد منقضی شده است");
        }

        await UpdateVerificationCode(verificationCode);
        await VerifiyUser(user);

        return await _mediator.Send(new AuthenticateUserCommand()
        {
            UserName = user.UserName,
            Password = user.Password
        });
    }

    private async Task VerifiyUser(User? user)
    {
        user.IsVerified = true;
        await _userWriteRepository.UpdateAsync(user);
    }

    private async Task UpdateVerificationCode(VerificationCode? verificationCode)
    {
        verificationCode.IsUsed = true;
        await _verificationCodeWriteRepository.UpdateAsync(verificationCode);
    }
}

