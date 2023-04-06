using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.CollectionDistributionPrices;
using Postex.Product.Domain.CollectionDistributionPrices;
using Postex.SharedKernel.Common.Enums;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierCollectionDistributionPrices.Queries
{
    public class GetCourierZoneCollectionDistributionPricesFilterQuery : IRequest<List<CollectionDistributionPriceDto>>
    {
        public CityTypeCode? CityType { get; set; }
        public SharedKernel.Common.Enums.CourierCode? CourierCode { get; set; }

        public class Handler : IRequestHandler<GetCourierZoneCollectionDistributionPricesFilterQuery, List<CollectionDistributionPriceDto>>
        {
            private readonly IReadRepository<CourierZoneCollectionDistributionPrice> _courierCityTypePriceRepository;

            public Handler(IReadRepository<CourierZoneCollectionDistributionPrice> courierCityTypePriceRepository)
            {
                _courierCityTypePriceRepository = courierCityTypePriceRepository;
            }

            public async Task<List<CollectionDistributionPriceDto>> Handle(GetCourierZoneCollectionDistributionPricesFilterQuery request, CancellationToken cancellationToken)
            {
                List<CourierCityTypePriceDto> typeOfCityDto = new();
                var courierCity = _courierCityTypePriceRepository.TableNoTracking;
                if (request.CourierCode > 0)
                {
                    courierCity = courierCity.Where(x => x.CourierZone.Courier.Code == request.CourierCode);
                }
                if (request.CityType > 0)
                {
                    courierCity = courierCity.Where(x => x.CourierZone.CityType == request.CityType);
                }
                var courierCityTypePrices = await courierCity.Include(x => x.CourierZone)
                    .OrderBy(c => c.Volume).ToListAsync();

                return courierCityTypePrices.Select(x => new CollectionDistributionPriceDto()
                {
                    BuyPrice = x.BuyPrice,
                    SellPrice = x.SellPrice,
                    Volume = x.Volume,
                    CityType = x.CourierZone.CityType
                }).ToList();
            }
        }
    }
}