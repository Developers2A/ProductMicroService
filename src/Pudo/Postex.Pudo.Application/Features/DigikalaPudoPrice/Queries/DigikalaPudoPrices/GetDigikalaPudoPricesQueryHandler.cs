using MediatR;
using Postex.Pudo.Application.Dtos.DigikalaPudo;
using Postex.Pudo.Application.Features.Digikala.Queries.GetPackages;
using Postex.Pudo.Application.Features.PudoPrice.Queries;
using Postex.SharedKernel.Common;

namespace Postex.Pudo.Application.Features.DigikalaPudoPrice.Queries.DigikalaPudoPrices;

public class GetPudoPriceQueryHandler : IRequestHandler<GetDigikalaPudoPricesQuery, BaseResponse<DigikalaPackageDto>>
{
    private readonly IMediator _mediator;

    public GetPudoPriceQueryHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<BaseResponse<DigikalaPackageDto>> Handle(GetDigikalaPudoPricesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var packages = await _mediator.Send(new GetDigikalaPackagesQuery()
            {
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                ParcelCode = request.ParcelCode
            }, cancellationToken);

            if (!packages.IsSuccess)
            {
                return new(false, packages.Message);
            }
            foreach (var package in packages.Data.Packages)
            {
                var price = await _mediator.Send(new GetPudoPriceQuery()
                {
                    CityName = package.Receiver.City,
                }, cancellationToken);
                if (!price.IsSuccess)
                {
                    return new(false, price.Message);
                }
                package.PudoPrice = Convert.ToInt32(price.Data.Price);
            }

            return new BaseResponse<DigikalaPackageDto>(true, "", packages.Data);

        }
        catch (Exception ex)
        {
            return new(false, "An error has occurred in the Service Pudo Price " + ex.Message);
        }
    }
}
