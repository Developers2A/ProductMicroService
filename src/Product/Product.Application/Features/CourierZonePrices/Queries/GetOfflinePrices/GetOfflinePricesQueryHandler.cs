using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Commons;
using Product.Application.Dtos.Couriers;
using Product.Application.Dtos.CourierServices.Common;
using Product.Application.Features.Cities.Queries;
using Product.Application.Features.CourierZoneCityMappings.Queries;
using Product.Domain.Couriers;
using Product.Domain.Enums;
using Product.Domain.Offlines;

namespace Product.Application.Features.CourierZonePrices.Queries.GetOfflinePrices
{
    public class GetOfflinePricesQueryHandler : IRequestHandler<GetOfflinePricesQuery, GetPriceResponse>
    {
        private readonly IReadRepository<CourierZonePrice> _courierZonePriceReadRepository;
        private readonly IMediator _mediator;
        private List<CityDto> _cities;
        private List<CourierZoneCityMappingDto> _courierZoneCityMappings;
        private bool _sameState = false;

        public GetOfflinePricesQueryHandler(IReadRepository<CourierZonePrice> courierZonePriceReadRepository, IMediator mediator)
        {
            _courierZonePriceReadRepository = courierZonePriceReadRepository;
            _mediator = mediator;
        }

        public async Task<GetPriceResponse> Handle(GetOfflinePricesQuery request, CancellationToken cancellationToken)
        {
            GetPriceResponse response = new();
            response.ServicePrices = new();
            _cities = await GetCities(request.SenderCity, request.ReceiverCity);
            _sameState = _cities.Select(x => x.StateId).Distinct().Count() == 1 ? true : false;
            _courierZoneCityMappings = await GetCourierZoneCityMappings();

            if (request.CourierCode == (int)CourierCode.All || request.CourierCode == (int)CourierCode.Post)
            {
                var postPrices = await PostPrice(request);
                if (postPrices != null)
                {
                    response.ServicePrices.AddRange(postPrices);
                }
            }

            return response;
        }

        private async Task<List<CourierZoneCityMappingDto>> GetCourierZoneCityMappings()
        {
            return await _mediator.Send(new GetCourierZoneCityMappingsQuery()
            {
                CityIds = _cities.Select(x => x.Id).Distinct().ToList()
            });
        }

        private async Task<List<ServicePrice>> PostPrice(GetOfflinePricesQuery request)
        {
            int fromCityId = GetCityId(CourierCode.Post, request.SenderCity);
            var toCityId = GetCityId(CourierCode.Post, request.ReceiverCity);
            int fromZoneId = GetZoneId(CourierCode.Post, fromCityId);
            int toZoneId = GetZoneId(CourierCode.Post, toCityId);
            SetFromAndToZoneDefaultIfZero(ref fromZoneId, ref toZoneId);

            if (fromZoneId > 0 && toZoneId > 0)
            {
                var postPrice = await _courierZonePriceReadRepository.TableNoTracking.Include(x => x.CourierService).Where(x => x.SameState == _sameState && x.FromCourierZoneId == fromZoneId && x.ToCourierZoneId == toZoneId && x.Weight >= request.Weight).GroupBy(x => x.CourierServiceId)
                    .Select(group => new
                    {
                        CourierServiceId = group.Key,
                        CourierService = group.FirstOrDefault().CourierService,
                        Price = group.FirstOrDefault(x => x.Weight == group.Min(x => x.Weight))
                    }).ToListAsync();

                return postPrice.Select(x => new ServicePrice()
                {
                    CourierCode = (int)CourierCode.Post,
                    CourierName = "پست",
                    PostexPrice = Convert.ToInt64(x.Price.BuyPrice),
                    TotalPrice = CalculatePostTotalPrice(x.CourierService, Convert.ToInt64(x.Price.BuyPrice))
                }).ToList();
            }
            return null;
        }

        private static void SetFromAndToZoneDefaultIfZero(ref int fromZoneId, ref int toZoneId)
        {
            fromZoneId = fromZoneId == 0 ? 11 : fromZoneId;
            toZoneId = toZoneId == 0 ? 11 : toZoneId;
        }

        private int GetZoneId(CourierCode courierCode, int cityId)
        {
            var zone = _courierZoneCityMappings.FirstOrDefault(x => x.CourierCode == courierCode && x.CityId == cityId);
            if (zone == null)
            {
                return 0;
            }
            return zone.CourierZoneId;
        }

        private int GetCityId(CourierCode courierCode, int cityCode)
        {
            var city = _cities.FirstOrDefault(x => x.Code == cityCode);
            if (city == null)
            {
                return 0;
            }
            return city.Id;
        }

        private long CalculatePostTotalPrice(CourierService courierService, long price, long insurancePrice = 0)
        {
            double A = courierService.DiscountPercent; // 20
            var B = price; // totalprice
            double C = insurancePrice;
            long D = courierService.FixBasePrice;
            double E = courierService.PriceHasTax ? B / 1.09 : B; // totalPrice : hastax = true ;
            double F = E - C - D;
            double G = courierService.PriceHasDiscount ? (100 / (100 - A)) * F : F;
            var I = courierService.PostexPercent;
            var J = courierService.PostexFixPrice;

            var X = ((G + (G * I / 100) + C + D) * 1.09) + J;

            return Convert.ToInt64(X);
        }

        public async Task<List<CityDto>> GetCities(int senderCity, int receiverCity)
        {
            return await _mediator.Send(new GetCitiesQuery()
            {
                CityCodes = new List<int> { senderCity, receiverCity }
            });
        }
    }
}
