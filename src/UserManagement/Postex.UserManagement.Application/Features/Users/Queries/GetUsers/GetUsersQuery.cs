using MediatR;
using Postex.SharedKernel.Paginations;
using Postex.UserManagement.Application.Dtos.Users;

namespace Postex.UserManagement.Application.Features.Users.Queries.GetUsers;

public class GetUsersQuery : PaginationParameters, IRequest<PagedList<UserDto>>
{
    public string? SearchKey { get; set; }
}
