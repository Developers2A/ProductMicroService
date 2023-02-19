using MediatR;
using Postex.SharedKernel.Interfaces;
using Postex.SharedKernel.Paginations;
using Postex.UserManagement.Application.Dtos.Users;
using Postex.UserManagement.Domain;
using Postex.UserManagement.Infrastructure;

namespace Postex.UserManagement.Application.Features.Users.Queries.GetUsers;

public class Handler : IRequestHandler<GetUsersQuery, PagedList<UserDto>>
{
    private readonly IReadRepository<User> _readRepository;
    public Handler(IReadRepository<User> readRepository)
    {
        _readRepository = readRepository;
    }

    public async Task<PagedList<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = _readRepository.TableNoTracking;
        if (!string.IsNullOrEmpty(request.SearchKey))
        {
            users = users.Where(x => x.UserName.Contains(request.SearchKey));
        }

        return await users.Select(x => new UserDto
        {
            Id = x.Id,
            Mobile = x.Mobile,
            UserName = x.UserName,
            FirstName = x.FirstName,
            LastName = x.LastName,
            NationalCode = x.NationalCode,
            IbanNumber = x.IbanNumber,
            IsVerified = x.IsVerified,
            IsActive = x.IsActive,
        }).OrderByDescending(x => x.Id)
        .ToPagedListAsync(request.PageIndex, request.PageSize);
    }
}

