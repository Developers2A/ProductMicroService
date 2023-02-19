using MediatR;
using Postex.Product.Application.Dtos;

namespace Postex.Product.Application.Features.ContractBoxPrices.Queries
{
    public class GetByCustomerContractBoxPriceQuery : IRequest<List<ContractBoxPriceDto>>
    {
        public Guid? CustomerId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
    }
}
