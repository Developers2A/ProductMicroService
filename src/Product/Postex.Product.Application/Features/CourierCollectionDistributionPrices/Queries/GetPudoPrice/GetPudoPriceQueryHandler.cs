using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.CollectionDistributionPrices.Basket;
using Postex.Product.Domain.CollectionDistributionPrices;
using Postex.Product.Domain.Offlines;
using Postex.SharedKernel.Common.Enums;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierCollectionDistributionPrices.Queries.GetPudoPrice
{
    public class GetPudoPriceQueryHandler : IRequestHandler<GetPudoPriceQuery, PudoPriceResponseDto>
    {
        private readonly IReadRepository<CourierZoneCityMapping> _courierZoneCityMappingRepository;
        private readonly IReadRepository<CourierZoneCollectionDistributionPrice> _courierZoneCollectionDistributionPriceRepository;

        public GetPudoPriceQueryHandler(IReadRepository<CourierZoneCollectionDistributionPrice> courierZoneCollectionDistributionPriceRepository,
            IReadRepository<CourierZoneCityMapping> courierZoneCityMappingRepository)
        {
            _courierZoneCityMappingRepository = courierZoneCityMappingRepository;
            _courierZoneCollectionDistributionPriceRepository = courierZoneCollectionDistributionPriceRepository;
        }

        public async Task<PudoPriceResponseDto> Handle(GetPudoPriceQuery query, CancellationToken cancellationToken)
        {
            int courierZoneId = 0;
            var courierZoneCity = await _courierZoneCityMappingRepository.TableNoTracking.Include(x => x.City).Include(x => x.CourierZone).FirstOrDefaultAsync(x => x.CourierZone.Courier.Code == CourierCode.Pudo && x.CityId == query.CityId);
            if (courierZoneCity == null)
            {
                throw new AppException("برای این شهر در سرویس پودو زون تعریف نشده است");
            }
            courierZoneId = courierZoneCity.CourierZoneId;
            var price = await _courierZoneCollectionDistributionPriceRepository.TableNoTracking
                 .FirstOrDefaultAsync(x => x.CourierZoneId == courierZoneId);

            if (price == null)
            {
                throw new AppException("برای این شهر در این زون قیمتی تعریف نشده است");
            }

            return new PudoPriceResponseDto()
            {
                City = courierZoneCity!.City.Name,
                Zone = courierZoneCity.CourierZone.Name,
                Price = price.SellPrice
            };
        }
    }
}
