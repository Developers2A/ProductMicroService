using MediatR;
using Postex.UserManagement.Application.Dtos.Customers;

namespace Postex.UserManagement.Application.Features.CustomerInvoiceInfos.Queries.GetByCustomerId
{
    public class GetByCustomerIdQuery : IRequest<CustomerInvoiceInfoDto>
    {
        public Guid CustomerId { get; set; }
    }
}
