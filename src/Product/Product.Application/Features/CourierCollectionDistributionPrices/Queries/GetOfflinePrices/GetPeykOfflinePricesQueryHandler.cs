﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Common.Enums;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Commons;
using Product.Application.Dtos.Couriers;
using Product.Application.Dtos.CourierServices.Common;
using Product.Application.Features.Cities.Queries;
using Product.Application.Features.CourierZoneCityMappings.Queries;
using Product.Domain.Offlines;

namespace Product.Application.Features.CourierCityTypePrices.Queries.GetOfflinePrices
{
    public class GetPeykOfflinePricesQueryHandler : IRequestHandler<GetPeykOfflinePricesQuery, GetPriceResponse>
    {
        private readonly IReadRepository<CourierZoneCollectionDistributionPrice> _readRepository;
        private readonly IMediator _mediator;
        private List<CityDto> _cities;
        private List<CourierZoneCityMappingDto> _courierZoneCityMappings;
        private GetPeykOfflinePricesQuery _query;

        public GetPeykOfflinePricesQueryHandler(
            IReadRepository<CourierZoneCollectionDistributionPrice> readRepository,
            IMediator mediator)
        {
            _readRepository = readRepository;
            _mediator = mediator;
        }

        public async Task<GetPriceResponse> Handle(GetPeykOfflinePricesQuery request, CancellationToken cancellationToken)
        {
            _query = request;
            GetPriceResponse response = new();
            response.ServicePrices = new();
            _cities = await GetCities();
            _courierZoneCityMappings = await GetCourierZoneCityMappings();

            if (request.CourierCode == (int)CourierCode.All || request.CourierCode == (int)CourierCode.Link)
            {
                var prices = await GetPrice(CourierCode.Link);
                if (prices != null)
                {
                    response.ServicePrices.AddRange(prices);
                }
            }

            if (request.CourierCode == (int)CourierCode.All || request.CourierCode == (int)CourierCode.Paykhub)
            {
                var prices = await GetPrice(CourierCode.Paykhub);
                if (prices != null)
                {
                    response.ServicePrices.AddRange(prices);
                }
            }

            if (request.CourierCode == (int)CourierCode.All || request.CourierCode == (int)CourierCode.Speed)
            {
                var prices = await GetPrice(CourierCode.Speed);
                if (prices != null)
                {
                    response.ServicePrices.AddRange(prices);
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

        private async Task<List<ServicePrice>> GetPrice(CourierCode courierCode)
        {
            int fromCityId = GetCityId(courierCode, _query.SenderCity);
            var toCityId = GetCityId(courierCode, _query.ReceiverCity);
            int fromZoneId = GetZoneId(courierCode, fromCityId);
            int toZoneId = GetZoneId(courierCode, toCityId);
            SetFromAndToZoneDefaultIfZero(ref fromZoneId, ref toZoneId);

            if (fromZoneId > 0 && toZoneId > 0)
            {
                var postPrice = await _readRepository.TableNoTracking.Where(x => x.CourierZoneId == fromZoneId && x.Volume >= _query.Weight).GroupBy(x => x.CourierZone.CourierId)
                    .Select(group => new
                    {
                        CourierServiceId = group.Key,
                        CourierService = group.FirstOrDefault().CourierZone,
                        Price = group.FirstOrDefault(x => x.Volume == group.Min(x => x.Volume))
                    }).ToListAsync();

                return postPrice.Select(x => new ServicePrice()
                {
                    CourierCode = (int)courierCode,
                    CourierName = courierCode.ToString(),
                    PostexPrice = Convert.ToInt64(x.Price.BuyPrice),
                    TotalPrice = Convert.ToInt64(x.Price.BuyPrice),
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

        public async Task<List<CityDto>> GetCities()
        {
            return await _mediator.Send(new GetCitiesQuery()
            {
                CityCodes = new List<int> { _query.SenderCity, _query.ReceiverCity }
            });
        }
    }
}
