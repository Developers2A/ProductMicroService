using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.Common;

namespace Postex.Product.Application.Features.Common.Queries.GetValueAddedPrices;

public class GetValueAddedPricesQuery : ITransactionRequest<List<ContractValueAddedPriceDto>>
{
    public int CustomerId { get; set; }
    public int StateId { get; set; }
    public int CityId { get; set; }
    public List<int>? ValueAddedIds { get; set; }
}
