using MediatR;
using Postex.Contract.Application.Dtos;

namespace Postex.Contract.Application.Features.ContractCods.Queries.GetByCustomer
{
    public class GetByCustomerContractCodQuery : IRequest<List<ContractCodDto>>
    {
        public Guid? CustomerId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
    }
}
