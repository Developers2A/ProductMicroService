using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Common.Enums;
using Postex.SharedKernel.Interfaces;
using Postex.SharedKernel.Paginations;
using Product.Application.Dtos.CollectionDistributions;
using Product.Domain.Offlines;

namespace Product.Application.Features.CourierCityTypePrices.Queries
{
    public class GetMaxParcelCityQuery : PaginationParameters, IRequest<ParcelCityDto>
    {
        public CityTypeCode CityType { get; set; }

        public class Handler : IRequestHandler<GetMaxParcelCityQuery, ParcelCityDto>
        {
            private readonly IReadRepository<CourierZoneCollectionDistributionPrice> _parcelCityRepository;

            public Handler(IReadRepository<CourierZoneCollectionDistributionPrice> parcelCityRepository)
            {
                _parcelCityRepository = parcelCityRepository;
            }

            public async Task<ParcelCityDto> Handle(GetMaxParcelCityQuery request, CancellationToken cancellationToken)
            {
                var parcelCity = await _parcelCityRepository.TableNoTracking.Include(x => x.CourierZone).FirstAsync(cancellationToken);
                var parcelcityDto = new ParcelCityDto()
                {
                    Id = parcelCity.Id,
                    SellPrice = parcelCity.SellPrice,
                    //CityType = parcelCity.CityType,
                    Volume = parcelCity.Volume,
                    CreatedOn = parcelCity.CreatedOn
                };

                return parcelcityDto;
            }
        }
    }
}