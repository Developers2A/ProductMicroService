using MediatR;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractInsurances.Queries.GetByCustomer
{
    public class GetByCustomerContractInsuranceQuery : IRequest<List<ContractInsuranceDto>>
    {
        public int? CustomerId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
    }
}
