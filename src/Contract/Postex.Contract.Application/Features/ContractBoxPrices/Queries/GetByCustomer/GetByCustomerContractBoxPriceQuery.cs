using MediatR;
using Postex.Contract.Application.Dtos;

namespace Postex.Contract.Application.Features.ContractBoxPrices.Queries
{
    public class GetByCustomerContractBoxPriceQuery : IRequest<List<ContractBoxPriceDto>>
    {
        public int? CustomerId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
    }
}
