using MediatR;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractInfos.Queries.GetContractByCustomer
{
    public class GetContractByCustomer : IRequest<ContractInfoDto>
    {
        public int CustomerId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
    }
}
