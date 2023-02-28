using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Commons;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Application.Dtos.ServiceProviders.Common;
using Postex.Product.Application.Features.Cities.Queries;
using Postex.Product.Application.Features.CourierZoneCityMappings.Queries;
using Postex.Product.Domain.Couriers;
using Postex.Product.Domain.Offlines;
using Postex.SharedKernel.Common.Enums;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierZonePrices.Queries.GetOfflinePrices
{
    public class GetOfflinePricesQueryHandler : IRequestHandler<GetOfflinePricesQuery, GetQuickPriceResponse>
    {
        private readonly IReadRepository<CourierZonePrice> _courierZonePriceReadRepository;
        private readonly IMediator _mediator;
        private List<CityDto> _cities;
        private List<CourierZoneCityMappingDto> _courierZoneCityMappings;
        private GetOfflinePricesQuery _query;
        private bool _sameState = false;

        public GetOfflinePricesQueryHandler(IReadRepository<CourierZonePrice> courierZonePriceReadRepository, IMediator mediator)
        {
            _courierZonePriceReadRepository = courierZonePriceReadRepository;
            _mediator = mediator;
        }

        public async Task<GetQuickPriceResponse> Handle(GetOfflinePricesQuery request, CancellationToken cancellationToken)
        {
            _query = request;
            GetQuickPriceResponse response = new();
            response.ServicePrices = new();
            _cities = await GetCities();
            _sameState = _cities.Select(x => x.StateId).Distinct().Count() == 1 ? true : false;
            _courierZoneCityMappings = await GetCourierZoneCityMappings();

            if (request.CourierCode == (int)CourierCode.All || request.CourierCode == (int)CourierCode.Post)
            {
                var postPrices = await PostPrice();
                if (postPrices != null)
                {
                    response.ServicePrices.AddRange(postPrices);
                }
            }

            if (request.CourierCode == (int)CourierCode.All || request.CourierCode == (int)CourierCode.Chapar)
            {
                var postPrices = await PostPrice();
                if (postPrices != null)
                {
                    response.ServicePrices.AddRange(postPrices);
                }
            }

            return response;
        }

        public async Task<List<CityDto>> GetCities()
        {
            return await _mediator.Send(new GetCitiesQuery()
            {
                CityCodes = new List<int> { _query.SenderCity, _query.ReceiverCity }
            });
        }

        private async Task<List<CourierZoneCityMappingDto>> GetCourierZoneCityMappings()
        {
            return await _mediator.Send(new GetCourierZoneCityMappingsQuery()
            {
                CityIds = _cities.Select(x => x.Id).Distinct().ToList()
            });
        }

        private async Task<List<ServicePrice>> PostPrice()
        {
            int fromCityId = GetCityId(CourierCode.Post, _query.SenderCity);
            var toCityId = GetCityId(CourierCode.Post, _query.ReceiverCity);
            int fromZoneId = GetZoneId(CourierCode.Post, fromCityId);
            int toZoneId = GetZoneId(CourierCode.Post, toCityId);
            SetFromAndToZoneDefaultIfZero(ref fromZoneId, ref toZoneId);

            if (fromZoneId > 0 && toZoneId > 0)
            {
                var postPrice = await _courierZonePriceReadRepository.TableNoTracking.Include(x => x.CourierService).Where(x => x.SameState == _sameState && x.FromCourierZoneId == fromZoneId && x.ToCourierZoneId == toZoneId && x.Weight >= _query.Weight).GroupBy(x => x.CourierServiceId)
                    .Select(group => new
                    {
                        CourierServiceId = group.Key,
                        group.FirstOrDefault().CourierService,
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

        private async Task<List<ServicePrice>> ChaparPrice()
        {
            int fromCityId = GetCityId(CourierCode.Post, _query.SenderCity);
            var toCityId = GetCityId(CourierCode.Post, _query.ReceiverCity);
            int fromZoneId = GetZoneId(CourierCode.Post, fromCityId);
            int toZoneId = GetZoneId(CourierCode.Post, toCityId);
            SetFromAndToZoneDefaultIfZero(ref fromZoneId, ref toZoneId);

            if (fromZoneId > 0 && toZoneId > 0)
            {
                var postPrice = await _courierZonePriceReadRepository.TableNoTracking.Include(x => x.CourierService).Where(x => x.FromCourierZoneId == fromZoneId && x.ToCourierZoneId == toZoneId && x.Weight >= _query.Weight).GroupBy(x => x.CourierServiceId)
                    .Select(group => new
                    {
                        CourierServiceId = group.Key,
                        group.FirstOrDefault().CourierService,
                        Price = group.FirstOrDefault(x => x.Weight == group.Min(x => x.Weight))
                    }).ToListAsync();

                return postPrice.Select(x => new ServicePrice()
                {
                    CourierCode = (int)CourierCode.Chapar,
                    CourierName = "چاپار",
                    PostexPrice = Convert.ToInt64(x.Price.BuyPrice),
                    TotalPrice = ChangePrice(x.CourierService, Convert.ToInt64(x.Price.BuyPrice))
                }).ToList();
            }
            return null;
        }

        private long ChangePrice(CourierService courierService, long price)
        {
            double taxChangePercent = 0;
            if (courierService == null)
            {
                return price;
            }
            else
            {
                double changePrice = price;
                changePrice = price * courierService.PostexPercent / 100; // 4800
                taxChangePercent = changePrice * 9 / 100; // 432  
                changePrice = price + changePrice + taxChangePercent;

                return Convert.ToInt64(changePrice);
            }
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

        private static void SetFromAndToZoneDefaultIfZero(ref int fromZoneId, ref int toZoneId)
        {
            fromZoneId = fromZoneId == 0 ? 11 : fromZoneId;
            toZoneId = toZoneId == 0 ? 11 : toZoneId;
        }

        private long CalculatePostTotalPrice(CourierService courierService, long price, long insurancePrice = 0)
        {
            double A = courierService.DiscountPercent; // 20
            var B = price; // totalprice
            double C = insurancePrice;
            long D = courierService.FixBasePrice;
            double E = courierService.PriceHasTax ? B / 1.09 : B; // totalPrice : hastax = true ;
            double F = E - C - D;
            double G = courierService.PriceHasDiscount ? 100 / (100 - A) * F : F;
            var I = courierService.PostexPercent;
            var J = courierService.PostexFixPrice;

            var X = (G + G * I / 100 + C + D) * 1.09 + J;

            return Convert.ToInt64(X);
        }
    }
}
