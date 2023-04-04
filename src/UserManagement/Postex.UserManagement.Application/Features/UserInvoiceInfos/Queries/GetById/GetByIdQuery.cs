using MediatR;
using Postex.UserManagement.Application.Dtos.Users;

namespace Postex.UserManagement.Application.Features.UserInvoiceInfos.Queries.GetById
{
    public class GetByIdQuery : IRequest<UserInvoiceInfoDto>
    {
        public int Id { get; set; }
    }
}
