using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.CollectionDistributions;
using Product.Domain.Offlines;

namespace Product.Application.Features.CourierCityTypePrices.Queries
{
    public class GetParcelCityByIdQuery : IRequest<ParcelCityDto>
    {
        public int Id { get; set; }
        public class Handler : IRequestHandler<GetParcelCityByIdQuery, ParcelCityDto>
        {
            private readonly IReadRepository<CourierZoneCollectionDistributionPrice> _parcelCityRepository;

            public Handler(IReadRepository<CourierZoneCollectionDistributionPrice> parcelCityRepository)
            {
                _parcelCityRepository = parcelCityRepository;
            }

            public async Task<ParcelCityDto> Handle(GetParcelCityByIdQuery request, CancellationToken cancellationToken)
            {
                var typeOfCityDto = await _parcelCityRepository.Table.Include(x => x.CourierZone)
                    .Select(c => new ParcelCityDto
                    {
                        Id = c.Id,
                        //CityType = c.CityType,
                        BuyPrice = c.BuyPrice,
                        SellPrice = c.SellPrice,
                        Volume = c.Volume,
                        CreatedOn = c.CreatedOn
                    })
                    .FirstOrDefaultAsync(c => c.Id == request.Id);

                return typeOfCityDto;
            }
        }
    }
}