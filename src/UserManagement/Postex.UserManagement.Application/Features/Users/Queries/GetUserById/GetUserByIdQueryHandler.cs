using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Postex.UserManagement.Application.Dtos.Users;
using Postex.UserManagement.Domain.Users;

namespace Postex.UserManagement.Application.Features.Users.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly IReadRepository<User> _readRepository;

    public GetUserByIdQueryHandler(IReadRepository<User> readRepository)
    {
        _readRepository = readRepository;
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _readRepository.TableNoTracking.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        return new UserDto()
        {
            Id = user!.Id,
            Mobile = user.Mobile,
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName,
            NationalCode = user.NationalCode,
            IbanNumber = user.IbanNumber,
            IsVerified = user.IsVerified,
            IsActive = user.IsActive,
        };
    }
}

