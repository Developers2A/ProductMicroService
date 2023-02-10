using MediatR;
using Postex.ProfileManagement.Application.Dtos;

namespace Postex.ProfileManagement.Application.Features.Customers.Queries
{
    public class GetByUserIdQuery : IRequest<CustomerDto>
    {
        public int UserId { get; set; }
    }
}
