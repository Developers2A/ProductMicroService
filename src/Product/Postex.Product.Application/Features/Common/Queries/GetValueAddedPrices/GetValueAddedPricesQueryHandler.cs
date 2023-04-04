using MediatR;
using Postex.Product.Application.Dtos.ServiceProviders.Common;
using Postex.Product.Application.Features.Contratcs.ContractValueAddeds.Queries.GetByUserAndValueAdded;

namespace Postex.Product.Application.Features.Common.Queries.GetValueAddedPrices;

public class GetValueAddedPricesQueryHandler : IRequestHandler<GetValueAddedPricesQuery, List<ContractValueAddedPriceDto>>
{
    private readonly IMediator _mediator;

    private GetValueAddedPricesQuery _query;

    public GetValueAddedPricesQueryHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<List<ContractValueAddedPriceDto>> Handle(GetValueAddedPricesQuery query, CancellationToken cancellationToken)
    {
        _query = query;
        return await GetValueAddedPrices();
    }

    private async Task<List<ContractValueAddedPriceDto>> GetValueAddedPrices()
    {
        //دریافت لیست مبالغ پیشفرض و کانترکت ارزش های افزوده درخواستی برحسب شهر، استان و مشتری
        List<ContractValueAddedPriceDto> valueAddedPriceGetDtos = new();
        if (_query.ValueAddedIds != null && _query.ValueAddedIds.Any())
        {
            foreach (var item in _query.ValueAddedIds)
            {
                var valueAddedPrice = await _mediator.Send(new GetByUserAndValueAddedContractValueAddedQuery()
                {
                    UserId = _query.UserId,
                    CityId = _query.CityId,
                    ProvinceId = _query.ProvinceId,
                    ValueAddedId = item
                });

                valueAddedPriceGetDtos.Add(new ContractValueAddedPriceDto()
                {
                    ContractId = valueAddedPrice.ContractId,
                    ContractValueAddedId = valueAddedPrice.ContractValueAddedId,
                    ValueTypeName = valueAddedPrice.ValueAddedTypeName,
                    DefaultBuyPrice = valueAddedPrice.DefaultBuyPrice,
                    DefaultSalePrice = valueAddedPrice.DefaultSalePrice,
                    ContractBuyPrice = valueAddedPrice.ContractBuyPrice,
                    ContractSalePrice = valueAddedPrice.ContractSalePrice,
                });
            }
        }

        return valueAddedPriceGetDtos;
    }
}
