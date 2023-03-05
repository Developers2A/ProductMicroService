using MediatR;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractCods.Queries.GetByCustomer
{
    public class GetByCustomerContractCodQuery : IRequest<List<ContractCodDto>>
    {
        public int? CustomerId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
    }
}
