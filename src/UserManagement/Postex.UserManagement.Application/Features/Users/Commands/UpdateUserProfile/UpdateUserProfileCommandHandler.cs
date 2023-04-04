using AutoMapper;
using MediatR;
using Postex.SharedKernel.Interfaces;
using Postex.SharedKernel.Utilities;
using Postex.UserManagement.Domain.Users;

namespace Postex.UserManagement.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand>
{
    private readonly IWriteRepository<User> _writeRepository;
    private readonly IReadRepository<User> _readRepository;
    private readonly IMapper _mapper;

    public UpdateUserProfileCommandHandler(IWriteRepository<User> writeRepository, IMapper mapper, IReadRepository<User> readRepository)
    {
        _writeRepository = writeRepository;
        _mapper = mapper;
        _readRepository = readRepository;
    }

    public async Task<Unit> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
    {
        var user = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

        if (!string.IsNullOrEmpty(request.Password) && request.Password.Length > 1)
        {
            var passwordHasher = new PasswordHasher();
            var hashedPassword = passwordHasher.HashPassword(request.Password);
            user.Password = hashedPassword;
        }

        user.IsActive = request.IsActive;
        user.UserName = request.UserName;

        await _writeRepository.UpdateAsync(user);
        await _writeRepository.SaveChangeAsync();

        return Unit.Value;
    }
}
