using MediatR;
using Postex.Product.Application.Dtos;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.ContractCollect_Distributes.Queries
{
    public class GetByCustomerAndBoxTypeContractCollect_DistributeQuery : IRequest<List<ContractCollectionDistributionDto>>
    {
        public int BoxTypeId { get; set; }
        public int? CustomerId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
    }
}
