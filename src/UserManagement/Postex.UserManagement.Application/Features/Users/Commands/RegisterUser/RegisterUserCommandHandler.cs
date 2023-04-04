using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Api;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Postex.SharedKernel.Utilities;
using Postex.UserManagement.Application.Dtos.Users;
using Postex.UserManagement.Application.Features.VerificationCodes.Commands.CreateVerificationCode;
using Postex.UserManagement.Domain.Users;

namespace Postex.UserManagement.Application.Features.Users.Commands.CreateUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ApiResult<MobileDto>>
{
    private readonly IWriteRepository<User> _userWriteRepository;
    private readonly IReadRepository<User> _userReadRepository;
    private readonly IMediator _mediator;
    private RegisterUserCommand _command;

    public RegisterUserCommandHandler(IWriteRepository<User> userWriteRepository, IReadRepository<User> userReadRepository, IMediator mediator)
    {
        _userWriteRepository = userWriteRepository;
        _userReadRepository = userReadRepository;
        _mediator = mediator;
    }

    public async Task<ApiResult<MobileDto>> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        _command = command;
        if (_command.Password != _command.RePassword)
        {
            throw new AppException("پسورد و تکرار آن مطابقت ندارند");
        }

        if (!_command.Mobile.StartsWith("0"))
        {
            _command.Mobile = "0" + _command.Mobile;
        }

        await CreateUser();
        await CreateAndSendVerificationCode();

        var mobileDto = new MobileDto()
        {
            Mobile = _command.Mobile
        };

        return new ApiResult<MobileDto>(true, mobileDto, "کد تایید ثبت نام از طریق پیامک ارسال شد");
    }

    private async Task<User> CreateUser()
    {
        var user = await _userReadRepository.TableNoTracking.FirstOrDefaultAsync(x => x.Mobile == _command.Mobile);
        if (user != null && user.IsVerified)
        {
            throw new AppException($"کاربری با این شماره موبایل {_command.Mobile} در سیستم وجود دارد");
        }

        var passwordHasher = new PasswordHasher();
        var hashedPassword = passwordHasher.HashPassword(_command.Password);
        if (user == null)
        {
            user = new User()
            {
                UserName = _command.Mobile,
                FirstName = _command.FirstName,
                LastName = _command.LastName,
                Password = hashedPassword,
                Mobile = _command.Mobile,
                IsVerified = false,
                IsActive = false
            };
        }
        else
        {
            user.UserName = _command.Mobile;
            user.Password = hashedPassword;
            user.FirstName = _command.FirstName;
            user.LastName = _command.LastName;
            user.IsVerified = false;
        }

        _userWriteRepository.Update(user);
        await _userWriteRepository.SaveChangeAsync();
        return user;
    }

    private async Task CreateAndSendVerificationCode()
    {
        await _mediator.Send(new CreateVerificationCodeCommand()
        {
            Mobile = _command.Mobile,
            VerificationCodeType = VerificationCodeType.Register
        });
    }
}

