using MediatR;
using Postex.UserManagement.Application.Dtos.Users;

namespace Postex.UserManagement.Application.Features.UserCods.Queries.GetByUserId
{
    public class GetByUserIdQuery : IRequest<UserCodDto>
    {
        public Guid UserId { get; set; }
    }
}
