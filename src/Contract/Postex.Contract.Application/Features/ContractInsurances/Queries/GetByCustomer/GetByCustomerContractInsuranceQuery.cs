using MediatR;
using Postex.Contract.Application.Dtos;

namespace Postex.Contract.Application.Features.ContractInsurances.Queries
{
    public class GetByCustomerContractInsuranceQuery : IRequest<List<ContractInsuranceDto>>
    {
        public int? CustomerId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
    }
}
