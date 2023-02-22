using MediatR;
using Postex.Product.Application.Dtos;

namespace Postex.Product.Application.Features.ContractCods.Queries
{
    public class GetByCustomerContractCodQuery : IRequest<List<ContractCodDto>>
    {
        public int? CustomerId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
    }
}
