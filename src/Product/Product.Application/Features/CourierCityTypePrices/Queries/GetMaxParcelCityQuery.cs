using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Postex.SharedKernel.Paginations;
using Product.Application.Dtos.CollectionDistributions;
using Product.Domain.Couriers;
using Product.Domain.Enums;

namespace Product.Application.Features.CourierCityTypePrices.Queries
{
    public class GetMaxParcelCityQuery : PaginationParameters, IRequest<ParcelCityDto>
    {
        public CityType CityType { get; set; }

        public class Handler : IRequestHandler<GetMaxParcelCityQuery, ParcelCityDto>
        {
            private readonly IReadRepository<CourierCityTypePrice> _parcelCityRepository;

            public Handler(IReadRepository<CourierCityTypePrice> parcelCityRepository)
            {
                _parcelCityRepository = parcelCityRepository;
            }

            public async Task<ParcelCityDto> Handle(GetMaxParcelCityQuery request, CancellationToken cancellationToken)
            {
                var parcelCity = await _parcelCityRepository.TableNoTracking.Include(x => x.Courier).Where(x => x.CityType == request.CityType).FirstAsync(cancellationToken);
                var parcelcityDto = new ParcelCityDto()
                {
                    Id = parcelCity.Id,
                    SellPrice = parcelCity.SellPrice,
                    CityType = parcelCity.CityType,
                    Volume = parcelCity.Volume,
                    CreatedOn = parcelCity.CreatedOn
                };

                return parcelcityDto;
            }
        }
    }
}