using MediatR;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractCollect_Distributes.Queries.GetByUser
{
    public class GetByUserContractCollect_DistributeQuery : IRequest<List<ContractCollectionDistributionDto>>
    {
        public int CourierServiceId { get; set; }
        public Guid? UserId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
    }
}
