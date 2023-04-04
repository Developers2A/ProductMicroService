using MediatR;
using Postex.UserManagement.Application.Dtos.Users;

namespace Postex.UserManagement.Application.Features.UserInvoiceInfos.Queries.GetByUserId
{
    public class GetByUserIdQuery : IRequest<UserInvoiceInfoDto>
    {
        public Guid UserId { get; set; }
    }
}
