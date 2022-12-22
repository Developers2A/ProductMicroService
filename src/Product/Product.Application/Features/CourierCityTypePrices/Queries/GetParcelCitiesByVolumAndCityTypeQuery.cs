using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.CollectionDistributions;
using Product.Domain.Couriers;
using Product.Domain.Enums;

namespace Product.Application.Features.CourierCityTypePrices.Queries
{
    public class GetParcelCitiesByVolumAndCityTypeQuery : IRequest<BoxSizeDto>
    {
        public double Volume { get; set; }
        public CityTypeCode CityType { get; set; }

        public class Handler : IRequestHandler<GetParcelCitiesByVolumAndCityTypeQuery, BoxSizeDto>
        {
            private readonly IReadRepository<CourierCityTypePrice> _parcelCityRepository;

            public Handler(IReadRepository<CourierCityTypePrice> parcelCityRepository)
            {
                _parcelCityRepository = parcelCityRepository;
            }

            public async Task<BoxSizeDto> Handle(GetParcelCitiesByVolumAndCityTypeQuery request, CancellationToken cancellationToken)
            {
                var parcelCitiesList = await _parcelCityRepository.TableNoTracking.Where(x => x.CityType == request.CityType).ToListAsync();
                var result = new BoxSizeDto();
                for (int i = 0; i < parcelCitiesList.Count; i++)
                {
                    if (parcelCitiesList[i].Volume >= request.Volume)
                    {
                        result = new BoxSizeDto()
                        {
                            BuyPrice = parcelCitiesList[i].BuyPrice,
                            SellPrice = parcelCitiesList[i].SellPrice,
                        };
                        result.SizeOfBox = parcelCitiesList[i].Volume.ToString("##,###");
                        return result;
                    }
                }

                return null;
            }
        }
    }
}