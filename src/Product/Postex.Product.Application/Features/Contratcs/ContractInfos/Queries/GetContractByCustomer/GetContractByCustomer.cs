using MediatR;
using Postex.Product.Application.Dtos;

namespace Postex.Product.Application.Features.Contracts.Queries.GetContractByCustomer
{
    public class GetContractByCustomer:IRequest<ContractInfoDto>
    {
        public Guid CustomerId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
    }
}
