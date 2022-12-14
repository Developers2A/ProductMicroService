using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierServiceZonePrices.Queries
{
    public class GetPricesQuery : IRequest<List<CourierServiceZonePrice>>
    {
        public int SenderCountryId { get; set; }
        public int SenderCityId { get; set; }
        public int ReceiverCountryId { get; set; }
        public int ReceiverCityId { get; set; }
        public float Weight { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool NeedCollection { get; set; }
        public bool NeedDistribution { get; set; }

        public class Handler : IRequestHandler<GetPricesQuery, List<CourierServiceZonePrice>>
        {
            private readonly IReadRepository<CourierServiceZonePrice> _courierServiceZonePriceReadRepository;

            public Handler(IReadRepository<CourierServiceZonePrice> courierServiceZonePriceReadRepository)
            {
                _courierServiceZonePriceReadRepository = courierServiceZonePriceReadRepository;
            }

            public async Task<List<CourierServiceZonePrice>> Handle(GetPricesQuery request, CancellationToken cancellationToken)
            {
                var courierZonePricesQuery = _courierServiceZonePriceReadRepository.TableNoTracking.Include(x => x.CourierServiceZone)
                    .Where(x => x.CourierServiceZone.CityFromId == request.SenderCityId && x.CourierServiceZone.CityToId == request.ReceiverCityId);

                return await courierZonePricesQuery.ToListAsync();
            }
        }
    }
}