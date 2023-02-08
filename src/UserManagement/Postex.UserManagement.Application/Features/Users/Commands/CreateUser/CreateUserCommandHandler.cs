using AutoMapper;
using MediatR;
using Postex.SharedKernel.Interfaces;
using Postex.SharedKernel.Utilities;
using Postex.UserManagement.Domain;

namespace Pouya.Application.Features.Users.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    private readonly IWriteRepository<User> _writeRepository;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IWriteRepository<User> writeRepository, IMapper mapper)
    {
        _writeRepository = writeRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHasher = new PasswordHasher();
        var hashedPassword = passwordHasher.HashPassword(request.Password);

        var user = new User()
        {
            UserName = request.UserName,
            Password = hashedPassword,
            IsActive = request.IsActive
        };
        await _writeRepository.AddAsync(user);
        await _writeRepository.SaveChangeAsync();
        return Unit.Value;
    }
}

