using MediatR;
using Postex.UserManagement.Application.Dtos.Customers;

namespace Postex.UserManagement.Application.Features.CustomerCods.Queries.GetById
{
    public class GetByIdQuery : IRequest<CustomerCodDto>
    {
        public int Id { get; set; }
    }
}
