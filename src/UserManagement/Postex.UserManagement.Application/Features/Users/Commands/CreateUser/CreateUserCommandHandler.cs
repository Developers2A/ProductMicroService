using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Application.Features.VerificationCodes.Commands.CreateVerificationCode;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using Postex.SharedKernel.Utilities;
using Postex.UserManagement.Application.Dtos.Users;
using Postex.UserManagement.Domain;

namespace Postex.UserManagement.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserCreateDto>
{
    private readonly IWriteRepository<User> _writeRepository;
    private readonly IReadRepository<User> _readRepository;
    private readonly IMediator _mediator;

    public CreateUserCommandHandler(IWriteRepository<User> writeRepository, IReadRepository<User> readRepository, IMediator mediator)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
        _mediator = mediator;
    }

    public async Task<UserCreateDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (request.Password != request.RePassword)
        {
            throw new AppException("پسورد و تکرار آن مطابقت ندارند");
        }

        if (!request.Mobile.StartsWith("0"))
        {
            request.Mobile = "0" + request.Mobile;
        }

        var passwordHasher = new PasswordHasher();
        var hashedPassword = passwordHasher.HashPassword(request.Password);
        var user = new User()
        {
            UserName = request.Mobile,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Password = hashedPassword,
            Mobile = request.Mobile,
            IsVerified = false
        };

        var isUserExists = await _readRepository.TableNoTracking.AnyAsync(x => x.Mobile == request.Mobile && x.IsVerified);
        if (isUserExists)
        {
            throw new AppException($"کاربری با این شماره موبایل {request.Mobile} در سیستم وجود دارد");
        }

        await _writeRepository.AddAsync(user);
        await _writeRepository.SaveChangeAsync();
        await CreateAndSendVerificationCode(request);

        return new UserCreateDto()
        {
            Token = Guid.NewGuid().ToString(),
            Mobile = user.Mobile
        };
    }

    private async Task CreateAndSendVerificationCode(CreateUserCommand request)
    {
        await _mediator.Send(new CreateVerificationCodeCommand()
        {
            Mobile = request.Mobile
        });
    }
}

