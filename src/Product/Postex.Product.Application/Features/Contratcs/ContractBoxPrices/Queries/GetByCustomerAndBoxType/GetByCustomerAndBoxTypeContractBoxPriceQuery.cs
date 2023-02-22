using MediatR;
using Postex.Product.Application.Dtos;

namespace Postex.Product.Application.Features.ContractBoxPrices.Queries
{
    public class GetByCustomerAndBoxTypeContractBoxPriceQuery : IRequest<List<ContractBoxPriceDto>>
    {
        public int BoxTypeId { get; set; }
        public int? CustomerId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }

    }
}
