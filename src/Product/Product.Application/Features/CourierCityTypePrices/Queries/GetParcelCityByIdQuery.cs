using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.CollectionDistributions;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierCityTypePrices.Queries
{
    public class GetParcelCityByIdQuery : IRequest<ParcelCityDto>
    {
        public int Id { get; set; }
        public class Handler : IRequestHandler<GetParcelCityByIdQuery, ParcelCityDto>
        {
            private readonly IReadRepository<CourierCityTypePrice> _parcelCityRepository;

            public Handler(IReadRepository<CourierCityTypePrice> parcelCityRepository)
            {
                _parcelCityRepository = parcelCityRepository;
            }

            public async Task<ParcelCityDto> Handle(GetParcelCityByIdQuery request, CancellationToken cancellationToken)
            {
                var typeOfCityDto = await _parcelCityRepository.Table.Include(x => x.Courier)
                    .Select(c => new ParcelCityDto
                    {
                        Id = c.Id,
                        CityType = c.CityType,
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