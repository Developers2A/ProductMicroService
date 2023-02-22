using MediatR;
using Postex.Product.Application.Dtos;

namespace Postex.Product.Application.Features.ContractInsurances.Queries
{
    public class GetByCustomerContractInsuranceQuery : IRequest<List<ContractInsuranceDto>>
    {
        public int? CustomerId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
    }
}
