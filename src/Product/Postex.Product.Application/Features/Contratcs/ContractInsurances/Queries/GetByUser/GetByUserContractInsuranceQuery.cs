using MediatR;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractInsurances.Queries.GetByUser
{
    public class GetByUserContractInsuranceQuery : IRequest<List<ContractInsuranceDto>>
    {
        public Guid? UserId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
    }
}
