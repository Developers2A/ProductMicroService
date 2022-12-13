using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierZoneSLAPrices.Queries
{
    public class GetPricesQuery : IRequest<List<CourierZoneSLAPrice>>
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

        public class Handler : IRequestHandler<GetPricesQuery, List<CourierZoneSLAPrice>>
        {
            private readonly IReadRepository<CourierZoneSLAPrice> _courierZoneSLAPriceReadRepository;

            public Handler(IReadRepository<CourierZoneSLAPrice> courierZoneReadRepository)
            {
                _courierZoneSLAPriceReadRepository = courierZoneReadRepository;
            }

            public async Task<List<CourierZoneSLAPrice>> Handle(GetPricesQuery request, CancellationToken cancellationToken)
            {
                var courierZonePricesQuery = _courierZoneSLAPriceReadRepository.TableNoTracking.Include(x => x.CourierZoneSlA)
                    .Where(x => x.CourierZoneSlA.CityFromId == request.SenderCityId && x.CourierZoneSlA.CityToId == request.ReceiverCityId);

                return await courierZonePricesQuery.ToListAsync();
            }
        }
    }
}