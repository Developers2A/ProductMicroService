using MediatR;
using Postex.ProfileManagement.Application.Dtos;

namespace Postex.ProfileManagement.Application.Features.CustomerInvoiceInfos.Queries
{
    public class GetByCustomerIdQuery : IRequest<CustomerInvoiceInfoDto>
    {
        public int CustomerId { get; set; }
    }
}
