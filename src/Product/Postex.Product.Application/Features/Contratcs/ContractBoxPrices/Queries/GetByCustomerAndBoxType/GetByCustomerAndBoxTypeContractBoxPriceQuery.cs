using MediatR;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractBoxPrices.Queries.GetByCustomerAndBoxType
{
    public class GetByCustomerAndBoxTypeContractBoxPriceQuery : IRequest<List<ContractBoxPriceDto>>
    {
        public int BoxTypeId { get; set; }
        public int? CustomerId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }

    }
}
