using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Commons;
using Product.Application.Dtos.Couriers;
using Product.Application.Dtos.CourierServices.Common;
using Product.Application.Features.Cities.Queries;
using Product.Application.Features.CourierStatusMappings.Queries;
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
            _cities = await GetCities(request.SenderCity, request.ReceiverCity);
            _sameState = _cities.Select(x => x.StateId).Distinct().Count() == 1 ? true : false;
            _courierZoneCityMappings = await GetCourierZoneCityMappings();

            if (request.CourierCode == (int)CourierCode.Post)
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

            if (fromZoneId > 0 && toZoneId > 0)
            {
                var postPrice = await _courierZonePriceReadRepository.TableNoTracking.Where(x => x.SameState == _sameState && x.FromCourierZoneId == fromZoneId && x.ToCourierZoneId == toZoneId).ToListAsync();

                return postPrice.Select(x => new ServicePrice()
                {
                    CourierCode = (int)CourierCode.Post,
                    CourierName = "پست",
                    PostexPrice = Convert.ToInt64(x.BuyPrice)
                }).ToList();
            }
            return null;
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

        public async Task<List<CityDto>> GetCities(int senderCity, int receiverCity)
        {
            return await _mediator.Send(new GetCitiesQuery()
            {
                CityCodes = new List<int> { senderCity, receiverCity }
            });
        }
    }
}
