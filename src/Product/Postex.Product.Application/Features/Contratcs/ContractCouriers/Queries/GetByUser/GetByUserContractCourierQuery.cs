using MediatR;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractCouriers.Queries.GetByUser
{
    public class GetByUserContractCourierQuery : IRequest<List<ContractCourierDto>>
    {
        public Guid? UserId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
    }
}
