using MediatR;
using Postex.ProfileManagement.Application.Dtos;

namespace Postex.ProfileManagement.Application.Features.CustomerInvoiceInfos.Queries
{
    public class GetByIdQuery:IRequest<CustomerInvoiceInfoDto>
    {
        public int Id { get; set; }
    }
}
