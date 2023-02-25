using MediatR;
using Postex.UserManagement.Application.Dtos.Customers;

namespace Postex.UserManagement.Application.Features.Customers.Queries.GetByUserId
{
    public class GetByUserIdQuery : IRequest<CustomerDto>
    {
        public Guid UserId { get; set; }
    }
}
