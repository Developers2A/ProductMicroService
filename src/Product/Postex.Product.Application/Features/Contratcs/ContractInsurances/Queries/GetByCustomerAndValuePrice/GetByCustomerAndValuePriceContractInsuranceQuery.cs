using MediatR;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractInsurances.Queries.GetByCustomerAndValuePrice
{
    public class GetByCustomerAndValuePriceContractInsuranceQuery : IRequest<InsurancePriceDto>
    {
        public double ValuePrice { get; set; }
        public int? CustomerId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
    }
}
