using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.Couriers;

namespace Product.Application.Features.CourierServiceZones.Queries
{
    public class GetCourierServiceZonesQuery : IRequest<List<CourierServiceZoneDto>>
    {
        public class Handler : IRequestHandler<GetCourierServiceZonesQuery, List<CourierServiceZoneDto>>
        {
            private readonly IReadRepository<CourierServiceZone> _courierZoneReadRepository;

            public Handler(IReadRepository<CourierServiceZone> courierZoneReadRepository)
            {
                _courierZoneReadRepository = courierZoneReadRepository;
            }

            public async Task<List<CourierServiceZoneDto>> Handle(GetCourierServiceZonesQuery request, CancellationToken cancellationToken)
            {
                var courierServiceZoneDtos = await _courierZoneReadRepository.TableNoTracking
                    .Select(c => new CourierServiceZoneDto
                    {
                        Id = c.Id,
                        StateFromId = c.StateFromId,
                        StateToId = c.StateToId,
                        CityFromId = c.CityFromId,
                        CityToId = c.CityToId,
                        CourierId = c.CourierId,
                        CourierServiceId = c.CourierServiceId
                    })
                    .OrderByDescending(c => c.Id)
                    .ToListAsync(cancellationToken);

                return courierServiceZoneDtos;
            }
        }
    }
}