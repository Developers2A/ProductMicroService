using MediatR;
using Postex.Contract.Application.Dtos;

namespace Postex.Contract.Application.Features.ContractItems.Queries.GetByCustomer
{
    public class GetByCustomerContractItemQuery : IRequest<List<ContractItemDto>>
    {
        public Guid? CustomerId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
    }
}
