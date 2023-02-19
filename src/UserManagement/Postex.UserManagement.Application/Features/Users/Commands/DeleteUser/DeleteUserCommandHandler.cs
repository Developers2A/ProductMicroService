using AutoMapper;
using MediatR;
using Postex.SharedKernel.Interfaces;
using Postex.UserManagement.Domain;

namespace Postex.UserManagement.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IWriteRepository<User> _writeRepository;
    private readonly IReadRepository<User> _readRepository;
    private readonly IMapper _mapper;

    public DeleteUserCommandHandler(IWriteRepository<User> writeRepository, IMapper mapper, IReadRepository<User> readRepository)
    {
        _writeRepository = writeRepository;
        _mapper = mapper;
        _readRepository = readRepository;
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _readRepository.GetByIdAsync(request.Id, cancellationToken);
        user.IsRemoved = true;
        user.RemovedOn = DateTime.Now;

        await _writeRepository.UpdateAsync(user);
        await _writeRepository.SaveChangeAsync();

        return Unit.Value;
    }
}
