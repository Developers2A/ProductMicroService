using MediatR;
using Postex.UserManagement.Application.Dtos.Users;

namespace Postex.UserManagement.Application.Features.Users.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<UserDto>
{
    public Guid Id { get; set; }
}
