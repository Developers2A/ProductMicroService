using MediatR;
using Postex.Product.Application.Dtos;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractCollect_Distributes.Queries.GetByCustomerAndBoxType
{
    public class GetByCustomerAndBoxTypeContractCollect_DistributeQuery : IRequest<CollectionDistributionPriceDto>
    {
        public int CourierServiceId { get; set; }
        public int BoxTypeId { get; set; }
        public int? CustomerId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
    }
}
