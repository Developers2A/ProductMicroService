using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.CollectionDistributions;
using Product.Domain.Enums;
using Product.Domain.Offlines;

namespace Product.Application.Features.CourierCityTypePrices.Queries
{
    public class GetCourierCityTypePricesQuery : IRequest<List<CourierCityTypePriceDto>>
    {
        public int CourierCode { get; set; }
        public int CityType { get; set; }
        public int Volume { get; set; }

        public class Handler : IRequestHandler<GetCourierCityTypePricesQuery, List<CourierCityTypePriceDto>>
        {
            private readonly IReadRepository<CourierZoneCollectionDistributionPrice> _courierCityTypePriceRepository;

            public Handler(IReadRepository<CourierZoneCollectionDistributionPrice> courierCityTypePriceRepository)
            {
                _courierCityTypePriceRepository = courierCityTypePriceRepository;
            }

            public async Task<List<CourierCityTypePriceDto>> Handle(GetCourierCityTypePricesQuery request, CancellationToken cancellationToken)
            {
                List<CourierCityTypePriceDto> typeOfCityDto = new();
                var courierCity = _courierCityTypePriceRepository.TableNoTracking.Include(x => x.CourierZone).ThenInclude(x => x.Courier)
                    //.Where(x => x.CityType == (CityTypeCode)request.CityType)
                    ;
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