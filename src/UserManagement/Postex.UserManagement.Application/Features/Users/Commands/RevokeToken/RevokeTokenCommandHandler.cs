using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Postex.UserManagement.Domain.Users;

namespace Postex.UserManagement.Application.Features.Users.Commands.RevokeToken;

public class RevokeTokenCommandHandler : IRequestHandler<RevokeTokenCommand>
{
    private readonly IWriteRepository<User> _userWriteRepository;
    private readonly IReadRepository<User> _userReadRepository;

    public RevokeTokenCommandHandler(IWriteRepository<User> userWriteRepository, IReadRepository<User> userReadRepository)
    {
        _userWriteRepository = userWriteRepository;
        _userReadRepository = userReadRepository;
    }

    public async Task<Unit> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
    {
        var user = await _userReadRepository.Table.FirstOrDefaultAsync(x => x.Id == request.UserId);
        user!.RefreshToken = null;
        user!.RefreshTokenExpiryTime = null;
        _userWriteRepository.Update(user);

        return Unit.Value;
    }
}

