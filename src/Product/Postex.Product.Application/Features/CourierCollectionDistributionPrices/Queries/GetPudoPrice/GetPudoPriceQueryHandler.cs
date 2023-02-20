using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.CollectionDistributionPrices.Basket;
using Postex.Product.Domain.CollectionDistributionPrices;
using Postex.Product.Domain.Offlines;
using Postex.SharedKernel.Common.Enums;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierCollectionDistributionPrices.Queries.GetPudoPrice
{
    public class GetPudoPriceQueryHandler : IRequestHandler<GetPudoPriceQuery, PudoPriceResponseDto>
    {
        private readonly IMediator _mediator;
        private readonly IReadRepository<CourierZoneCityMapping> _courierZoneCityMappingRepository;
        private readonly IReadRepository<CourierZoneCollectionDistributionPrice> _courierZoneCollectionDistributionPriceRepository;
        private readonly IReadRepository<CourierZone> _courierZoneRepository;

        public GetPudoPriceQueryHandler(IMediator mediator, IReadRepository<CourierZoneCollectionDistributionPrice> courierZoneCollectionDistributionPriceRepository,
            IReadRepository<CourierZoneCityMapping> courierZoneCityMappingRepository, IReadRepository<CourierZone> courierZoneRepository)
        {
            _mediator = mediator;
            _courierZoneCityMappingRepository = courierZoneCityMappingRepository;
            _courierZoneCollectionDistributionPriceRepository = courierZoneCollectionDistributionPriceRepository;
            _courierZoneRepository = courierZoneRepository;
        }

        public async Task<PudoPriceResponseDto> Handle(GetPudoPriceQuery query, CancellationToken cancellationToken)
        {
            int courierZoneId = 0;
            var courierZoneCity = await _courierZoneCityMappingRepository.TableNoTracking.FirstOrDefaultAsync(x => x.CourierZone.Courier.Code == CourierCode.Pudo);
            if (courierZoneCity != null)
            {
                courierZoneId = courierZoneCity.CourierZoneId;
            }
            var price = await _courierZoneCollectionDistributionPriceRepository.TableNoTracking
                 .FirstOrDefaultAsync(x => x.CourierZoneId == courierZoneId);

            if (price == null)
            {
                return new PudoPriceResponseDto()
                {
                    City = query.CityName,
                    Price = 0
                };
            }

            return new PudoPriceResponseDto()
            {
                City = query.CityName,
                Price = price.SellPrice
            };
        }
    }
}
