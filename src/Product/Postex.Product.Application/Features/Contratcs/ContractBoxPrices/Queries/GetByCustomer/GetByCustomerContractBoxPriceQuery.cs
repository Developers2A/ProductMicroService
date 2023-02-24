using MediatR;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractBoxPrices.Queries.GetByCustomer
{
    public class GetByCustomerContractBoxPriceQuery : IRequest<List<ContractBoxPriceDto>>
    {
        public int? CustomerId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
    }
}
