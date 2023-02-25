using MediatR;
using Postex.UserManagement.Application.Dtos.Customers;

namespace Postex.UserManagement.Application.Features.Customers.Queries.GetById
{
    public class GetByIdQuery : IRequest<CustomerDto>
    {
        public int Id { get; set; }
    }
}
