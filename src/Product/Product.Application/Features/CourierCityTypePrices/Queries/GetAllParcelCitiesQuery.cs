using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.CollectionDistributions;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierCityTypePrices.Queries
{
    public class GetAllParcelCitiesQuery : IRequest<List<ParcelCityDto>>
    {
        public class Handler : IRequestHandler<GetAllParcelCitiesQuery, List<ParcelCityDto>>
        {
            private readonly IReadRepository<CourierCityTypePrice> _parcelCityRepository;

            public Handler(IReadRepository<CourierCityTypePrice> parcelCityRepository)
            {
                _parcelCityRepository = parcelCityRepository;
            }

            public async Task<List<ParcelCityDto>> Handle(GetAllParcelCitiesQuery request, CancellationToken cancellationToken)
            {
                var parcelCities = await _parcelCityRepository.TableNoTracking.Include(x => x.Courier)
                    .Select(c => new ParcelCityDto
                    {
                        Id = c.Id,
                        SellPrice = c.SellPrice,
                        BuyPrice = c.BuyPrice,
                        CityType = c.CityType,
                        Volume = c.Volume,
                        CreatedOn = c.CreatedOn
                    })
                    .OrderBy(c => c.Volume).ToListAsync();

                return parcelCities;
            }
        }
    }
}