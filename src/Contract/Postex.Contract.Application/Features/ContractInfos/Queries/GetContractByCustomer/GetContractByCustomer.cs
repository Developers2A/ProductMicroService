using MediatR;
using Postex.Contract.Application.Dtos;

namespace Postex.Contract.Application.Features.ContractInfos.Queries.GetContractByCustomer
{
    public class GetContractByCustomer : IRequest<ContractInfoDto>
    {
        public Guid CustomerId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
    }
}
