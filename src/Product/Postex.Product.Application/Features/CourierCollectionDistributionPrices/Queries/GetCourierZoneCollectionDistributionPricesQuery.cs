using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.CollectionDistributionPrices;
using Postex.Product.Domain.CollectionDistributionPrices;
using Postex.SharedKernel.Common.Enums;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierCollectionDistributionPrices.Queries
{
    public class GetCourierZoneCollectionDistributionPricesQuery : IRequest<List<CourierCityTypePriceDto>>
    {
        public int CourierCode { get; set; }
        public int CourierZoneId { get; set; }
        public int Volume { get; set; }

        public class Handler : IRequestHandler<GetCourierZoneCollectionDistributionPricesQuery, List<CourierCityTypePriceDto>>
        {
            private readonly IReadRepository<CourierZoneCollectionDistributionPrice> _courierCityTypePriceRepository;

            public Handler(IReadRepository<CourierZoneCollectionDistributionPrice> courierCityTypePriceRepository)
            {
                _courierCityTypePriceRepository = courierCityTypePriceRepository;
            }

            public async Task<List<CourierCityTypePriceDto>> Handle(GetCourierZoneCollectionDistributionPricesQuery request, CancellationToken cancellationToken)
            {
                List<CourierCityTypePriceDto> typeOfCityDto = new();
                var courierCity = _courierCityTypePriceRepository.TableNoTracking
                    .Where(x => x.CourierZoneId == request.CourierZoneId);
                if (request.CourierCode > 0)
                {
                    courierCity.Where(x => x.CourierZone.Courier.Code == (CourierCode)request.CourierCode);
                }
                var courierCityTypePrices = await courierCity.Where(x => x.Volume >= request.Volume)
                    .OrderBy(c => c.Volume).ToListAsync();
                var couriers = courierCityTypePrices.Select(x => x.CourierZone.CourierId).Distinct();
                foreach (var item in couriers)
                {
                    var courierCityTypePrice = courierCityTypePrices.FirstOrDefault(x => x.CourierZone.CourierId == item);
                    if (courierCityTypePrice != null)
                    {
                        typeOfCityDto.Add(new CourierCityTypePriceDto()
                        {
                            BuyPrice = courierCityTypePrice.BuyPrice,
                            CourierName = courierCityTypePrice.CourierZone.Courier.Name,
                            //CityType = courierCityTypePrice.CityType,
                            SellPrice = courierCityTypePrice.SellPrice,
                            Volume = courierCityTypePrice.Volume,
                            Id = courierCityTypePrice.Id
                        });
                    }
                }

                return typeOfCityDto;
            }
        }
    }
}