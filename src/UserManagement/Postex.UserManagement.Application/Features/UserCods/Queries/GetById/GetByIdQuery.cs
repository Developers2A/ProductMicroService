using MediatR;
using Postex.UserManagement.Application.Dtos.Users;

namespace Postex.UserManagement.Application.Features.UserCods.Queries.GetById
{
    public class GetByIdQuery : IRequest<UserCodDto>
    {
        public int Id { get; set; }
    }
}
